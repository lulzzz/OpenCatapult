﻿// Copyright (c) Polyrific, Inc 2018. All rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
using CorrelationId;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Polyrific.Catapult.Api.Core.Entities;
using Polyrific.Catapult.Api.Hubs;
using Polyrific.Catapult.Api.Identity;
using Polyrific.Catapult.Api.Infrastructure;
using Polyrific.Catapult.Shared.Common;
using Polyrific.Catapult.Shared.Common.Interface;
using Polyrific.Catapult.Shared.Dto.Constants;
using Swashbuckle.AspNetCore.Swagger;

namespace Polyrific.Catapult.Api
{
    public class Startup
    {
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _allowSpecificOriginsPolicy = "_allowSpecificOriginsPolicy";

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _logger = loggerFactory.CreateLogger<Startup>();
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            string baseUrl = _hostingEnvironment.IsDevelopment() ? Path.Combine(_hostingEnvironment.ContentRootPath, "bin") : _hostingEnvironment.WebRootPath;
            services.Configure<ApplicationSettingValue>(Configuration);
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<ApplicationSettingValue>>().Value);
            
            var localTextWriter = new LocalTextWriter(baseUrl);
            services.AddSingleton<ITextWriter>(localTextWriter);

            services.RegisterDbContext(Configuration.GetConnectionString("DefaultConnection"), Configuration["DatabaseProvider"]);

            services.RegisterRepositories();
            services.RegisterServices();
            services.RegisterSecretVault(Configuration["Security:Vault:Provider"]);
            
            services.AddAppIdentity(Configuration["DatabaseProvider"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Security:Tokens:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Security:Tokens:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Security:Tokens:Key"])),
                        RequireExpirationTime = false
                    };
                });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCorrelationId();

            services.AddAutoMapper();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizePolicy.ProjectAccess, policy => policy.Requirements.Add(new ProjectAccessRequirement()));
                options.AddPolicy(AuthorizePolicy.ProjectOwnerAccess, policy => policy.Requirements.Add(new ProjectAccessRequirement(MemberRole.Owner)));
                options.AddPolicy(AuthorizePolicy.ProjectMaintainerAccess, policy => policy.Requirements.Add(new ProjectAccessRequirement(MemberRole.Maintainer)));
                options.AddPolicy(AuthorizePolicy.ProjectContributorAccess, policy => policy.Requirements.Add(new ProjectAccessRequirement(MemberRole.Contributor)));
                options.AddPolicy(AuthorizePolicy.ProjectMemberAccess, policy => policy.Requirements.Add(new ProjectAccessRequirement(MemberRole.Member)));
                options.AddPolicy(AuthorizePolicy.UserRoleAdminAccess, policy => policy.RequireRole(UserRole.Administrator));
                options.AddPolicy(AuthorizePolicy.UserRoleBasicAccess, policy => policy.RequireRole(UserRole.Administrator, UserRole.Basic));
                options.AddPolicy(AuthorizePolicy.UserRoleGuestAccess, policy => policy.RequireRole(UserRole.Administrator, UserRole.Basic, UserRole.Guest));
                options.AddPolicy(AuthorizePolicy.UserRoleEngineAccess, policy => policy.RequireRole(UserRole.Administrator, UserRole.Engine));
                options.AddPolicy(AuthorizePolicy.UserRoleBasicEngineAccess, policy => policy.RequireRole(UserRole.Administrator, UserRole.Basic, UserRole.Engine));
            });
            
            services.AddSingleton<IAuthorizationHandler, ProjectAccessHandler>();
            services.AddSingleton<IAuthorizationHandler, ProjectEngineAccessHandler>();

            services.AddSignalR();

            services.AddNotifications(Configuration);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "OpenCatapult API", Version = "v1" });
                c.CustomSchemaIds(x => x.FullName);
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddCors(options =>
            {
                options.AddPolicy(_allowSpecificOriginsPolicy, builder => builder
                    .WithOrigins(Configuration["AllowedOrigin"].Split(","))
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenCatapult API V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseHsts();
                app.UseDefaultFiles(new DefaultFilesOptions
                {
                    DefaultFileNames = new List<string>
                    {
                        "Default.html"
                    }
                });
                app.UseStaticFiles();
            }

            app.UseCorrelationId();
            app.UseAuthentication();

            // enrich log with request context
            app.UseMiddleware<SerilogRequestLogger>();

            app.ConfigureExceptionHandler(_logger, env.IsDevelopment());

            app.UseCors(_allowSpecificOriginsPolicy);

            app.UseMvc();

            app.UseSignalR(routes =>
            {
                routes.MapHub<JobQueueHub>("/jobQueueHub");
            });
        }
    }
}
