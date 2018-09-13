﻿// Copyright (c) Polyrific, Inc 2018. All rights reserved.

using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Polyrific.Catapult.Shared.Service;
using System.ComponentModel.DataAnnotations;

namespace Polyrific.Catapult.Cli.Commands.Member
{
    [Command(Description = "Remove a project member")]
    public class RemoveCommand : BaseCommand
    {
        private readonly IProjectMemberService _projectMemberService;
        private readonly IProjectService _projectService;
        private readonly IAccountService _accountService;

        public RemoveCommand(IConsole console, ILogger<RemoveCommand> logger,
            IProjectMemberService projectMemberService, IProjectService projectService, IAccountService accountService) : base(console, logger)
        {
            _projectMemberService = projectMemberService;
            _projectService = projectService;
            _accountService = accountService;
        }

        [Required]
        [Option("-p|--project <PROJECT>", "Name of the project", CommandOptionType.SingleValue)]
        public string Project { get; set; }

        [Required]
        [Option("-u|--user <USER>", "Username (email) of the user", CommandOptionType.SingleValue)]
        public string User { get; set; }

        public override string Execute()
        {
            string message = string.Empty;

            var project = _projectService.GetProjectByName(Project).Result;
            var user = _accountService.GetUserByUserName(User).Result;

            if (project != null && user != null)
            {
                var projectMember = _projectMemberService.GetProjectMemberByUserId(project.Id, int.Parse(user.Id)).Result;

                if (projectMember != null)
                {
                    _projectMemberService.RemoveProjectMember(project.Id, projectMember.Id).Wait();
                    message = $"User {User} was removed from project {Project}";
                    Logger.LogInformation(message);
                    return message;
                }
            }
            else
            {
                message = $"Failed removing user {User}. Make sure the project name and user email are correct.";
            }

            return message;
        }
    }
}