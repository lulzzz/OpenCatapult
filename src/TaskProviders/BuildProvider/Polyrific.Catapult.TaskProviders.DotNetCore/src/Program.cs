﻿// Copyright (c) Polyrific, Inc 2018. All rights reserved.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Polyrific.Catapult.TaskProviders.Core;
using Polyrific.Catapult.TaskProviders.DotNetCore.Helpers;

namespace Polyrific.Catapult.TaskProviders.DotNetCore
{
    public class Program : BuildProvider
    {
        private const string TaskProviderName = "Polyrific.Catapult.TaskProviders.DotNetCore";

        private IBuilder _builder;

        public override string Name => TaskProviderName;
        
        public Program(string[] args) : base(args)
        {
        }
        
        public override async Task<(string outputArtifact, Dictionary<string, string> outputValues, string errorMessage)> Build()
        {
            var (outputVersion, err) = await CommandHelper.Execute("dotnet", "--list-sdks");
            if (string.IsNullOrWhiteSpace(outputVersion) || !string.IsNullOrEmpty(err))
            {
                return (null, null, $"Task Provider {TaskProviderName} require dotnet sdk to be installed");
            }

            var csprojLocation = Path.Combine(Config.SourceLocation ?? Config.WorkingLocation, ProjectName, $"{ProjectName}.csproj");
            if (AdditionalConfigs != null && AdditionalConfigs.ContainsKey("CsprojLocation") && !string.IsNullOrEmpty(AdditionalConfigs["CsprojLocation"]))
                csprojLocation = AdditionalConfigs["CsprojLocation"];
            if (!Path.IsPathRooted(csprojLocation))
                csprojLocation = Path.Combine(Config.WorkingLocation, csprojLocation);

            var buildConfiguration = "Release";
            if (AdditionalConfigs != null && AdditionalConfigs.ContainsKey("Configuration") && !string.IsNullOrEmpty(AdditionalConfigs["Configuration"]))
                buildConfiguration = AdditionalConfigs["Configuration"];

            var buildOutputLocation = Path.Combine(Config.WorkingLocation, "publish");

            var artifactLocation = "artifact";
            if (!string.IsNullOrEmpty(Config.OutputArtifactLocation))
                artifactLocation = Config.OutputArtifactLocation;
            if (!Path.IsPathRooted(artifactLocation))
                artifactLocation = Path.Combine(Config.WorkingLocation, artifactLocation);

            if (_builder == null)
                _builder = new Builder();

            var error = await _builder.Build(csprojLocation, buildOutputLocation, buildConfiguration);
            if (!string.IsNullOrEmpty(error))
                return ("", null, error);

            var destinationArtifact = Path.Combine(artifactLocation, $"{ProjectName}.zip");
            error = await _builder.CreateArtifact(buildOutputLocation, destinationArtifact);
            if (!string.IsNullOrEmpty(error))
                return ("", null, error);

            return (destinationArtifact, null, "");
        }

        private static async Task Main(string[] args)
        {
            var app = new Program(args);
            
            var result = await app.Execute();
            app.ReturnOutput(result);
        }
        
        
    }
}
