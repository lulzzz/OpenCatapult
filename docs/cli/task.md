# Task

## Add

Add a new job task definition

Usage: 
`dotnet pc.dll task add --project [project] --job [job] --name [name] --type [type] --property [propname]:[propvalue]`

**Options**
* project (mandatory)
    * Name of the project
    * Usage: `--project` (alias: `-p`)
* job (mandatory)
    * Name of the job definition
    * Usage: `--job` (alias: `-j`)
* name (mandatory)
    * Name of the new job task definition
    * Usage: `--name` (alias: `-n`)
* type
    * Type of the task
    * Usage: `--type` (alias: `-t`)
    * Allowed values: `generate` | `push` | `build` | `deploy` | `deploydb`
    * Default value: `generate`
* property
    * Property of the task
    * Usage: `--property [propname]:[propvalue]` (alias: `-prop`)
    * Allows multiple values

# List
List job task definitions

Usage: 
`dotnet pc.dll task list --project [project] --job [job]`

**Options**
* project (mandatory)
    * Name of the project
    * Usage: `--project` (alias: `-p`)
* job (mandatory)
    * Name of the job definition
    * Usage: `--job` (alias: `-j`)

# Remove
Remove a job task definition

Usage: 
`dotnet pc.dll task remove --project [project] --job [job] --name [name]`

**Options**
* project (mandatory)
    * Name of the project
    * Usage: `--project` (alias: `-p`)
* job (mandatory)
    * Name of the job definition
    * Usage: `--job` (alias: `-j`)
* name (mandatory)
    * Name of the new job task definition
    * Usage: `--name` (alias: `-n`)

# Update
Update a job task definition

Usage: 
`dotnet pc.dll task update --project [project] --job [job] --name [name] --rename [newname] --type [type] --property [propname]:[propvalue]`

**Options**
* project (mandatory)
    * Name of the project
    * Usage: `--project` (alias: `-p`)
* job (mandatory)
    * Name of the job definition
    * Usage: `--job` (alias: `-j`)
* name (mandatory)
    * Name of the new job task definition
    * Usage: `--name` (alias: `-n`)
* rename
    * New name of the new job task definition
    * Usage: `--rename` (alias: `-r`)
* type
    * Type of the task
    * Usage: `--type` (alias: `-t`)
    * Allowed values: `generate` | `push` | `build` | `deploy` | `deploydb`
    * Default value: `generate`
* property
    * Property of the task
    * Usage: `--property [propname]:[propvalue]` (alias: `-prop`)
    * Allows multiple values