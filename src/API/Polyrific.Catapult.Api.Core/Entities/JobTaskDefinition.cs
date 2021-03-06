﻿// Copyright (c) Polyrific, Inc 2018. All rights reserved.

namespace Polyrific.Catapult.Api.Core.Entities
{
    public class JobTaskDefinition : BaseEntity
    {
        /// <summary>
        /// Id of the job definition
        /// </summary>
        public int JobDefinitionId { get; set; }

        /// <summary>
        /// Related job definition object
        /// </summary>
        public virtual JobDefinition JobDefinition { get; set; }

        /// <summary>
        /// Name of the job task definition
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Type of the job task definition
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Provider of the job task definition
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Config string of the job task definition
        /// </summary>
        public string ConfigString { get; set; }

        /// <summary>
        /// Additional configurations which are required by specific providers in json string format
        /// </summary>
        public string AdditionalConfigString { get; set; }

        /// <summary>
        /// Sequence of the job task definition
        /// </summary>
        public int? Sequence { get; set; }

        /// <summary>
        /// Is the job task definition valid?
        /// </summary>
        public bool? Valid { get; set; }

        /// <summary>
        /// Validation error message
        /// </summary>
        public string ValidationError { get; set; }
    }
}
