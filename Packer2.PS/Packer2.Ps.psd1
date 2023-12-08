#
# Module manifest for module 'Packer.PS'
#
# Generated by: Antonio Nakic-Alfirevic
#
# Generated on: 10/11/2022
#

@{

# Script module or binary module file associated with this manifest.
RootModule = 'packer2.ps.dll'

# Version number of this module.
ModuleVersion = '0.0.46'

# Supported PSEditions
# CompatiblePSEditions = @()

# ID used to uniquely identify this module
GUID = '1a78e90a-4c05-4575-bb6f-b6d678cad66e'

# Author of this module
Author = 'Antonio Nakic-Alfirevic'

# Company or vendor of this module
CompanyName = 'SSG Health'

# Copyright statement for this module
Copyright = '(c) Antonio Nakic-Alfirevic. All rights reserved.'

# Description of the functionality provided by this module
Description = 'A module containing commandlets for working with PowerBI reports and data sources. Namely, the commandlets allow unpacking a pbit report, extracting the data model from it, pushing the data model to an SSAS instance and repointing a pbix file to an SSAS databsorce. Both the report layout as well as the data model schema can be extracted to folders that are git-friendly allowing for version control.'

# Minimum version of the PowerShell engine required by this module
PowerShellVersion = '7.0'

# Name of the PowerShell host required by this module
# PowerShellHostName = ''

# Minimum version of the PowerShell host required by this module
# PowerShellHostVersion = ''

# Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
# DotNetFrameworkVersion = ''

# Minimum version of the common language runtime (CLR) required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
# ClrVersion = ''

# Processor architecture (None, X86, Amd64) required by this module
# ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
# RequiredModules = @()

# Assemblies that must be loaded prior to importing this module
# RequiredAssemblies = @('Microsoft.AnalysisServices.Core.dll','Microsoft.AnalysisServices.dll','Microsoft.AnalysisServices.Runtime.Core.dll','Microsoft.AnalysisServices.Runtime.Windows.dll','Microsoft.AnalysisServices.Tabular.dll','Microsoft.AnalysisServices.Tabular.Json.dll','Microsoft.ApplicationInsights.dll','Microsoft.Extensions.Logging.Abstractions.dll','Microsoft.Identity.Client.dll','Microsoft.Win32.Registry.AccessControl.dll','Microsoft.Win32.SystemEvents.dll','Newtonsoft.Json.dll','Packer2.Library.dll','Packer2.PS.dll','System.CodeDom.dll','System.Configuration.ConfigurationManager.dll','System.Data.SqlClient.dll','System.Diagnostics.EventLog.dll','System.DirectoryServices.dll','System.Drawing.Common.dll','System.Management.dll','System.Security.Cryptography.Pkcs.dll','System.Security.Cryptography.ProtectedData.dll','System.Security.Permissions.dll','System.Windows.Extensions.dll')

# Script files (.ps1) that are run in the caller's environment prior to importing this module.
# ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
# TypesToProcess = @()

# Format files (.ps1xml) to be loaded when importing this module
# FormatsToProcess = @()

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
# NestedModules = @()

# Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
FunctionsToExport = @()

# Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no cmdlets to export.
CmdletsToExport = @('Read-PbiReport' ,'Switch-PbiReportDataSource' ,'Write-PbiReport' ,'Export-TabularModelDataSources' ,'Find-TabularModelDaxErrors' ,'Import-TabularModelDataSources' ,'Read-TabularModel' ,'Register-TabularModelMExpressions' ,'Register-TabularModelDataSources' ,'Remove-TabularModelAutoTimeIntelligence' ,'Remove-TabularModelCultures' ,'Resolve-TabularModelPasswords' ,'Switch-TabularModelCompatibilityLevel' ,'Write-TabularModel', 'Write-TabularModelToPbiService' ,'Compress-PbiReport' ,'Expand-PbiReport' , 'Expand-PbiReport' ,'Export-TabularModelDataSources' ,'Find-TabularModelDaxErrors' ,'Import-TabularModelDataSources' ,'Read-PbiReport' ,'Read-TabularModel' ,'Register-TabularModelDataSources' ,'Register-TabularModelMExpressions' ,'Remove-TabularModelAutoTimeIntelligence' ,'Remove-TabularModelCultures' ,'Resolve-TabularModelPasswords' ,'Switch-PbiReportDataSource' ,'Switch-TabularModelCompatibilityLevel' ,'Write-PbiReport' ,'Write-TabularModel', 'Test-PbiReportDataModelReferences', 'Switch-PbiReportDataModelReference', 'Switch-PbiReportToLocalDataModel')

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no aliases to export.
AliasesToExport = @()

# DSC resources to export from this module
# DscResourcesToExport = @()

# List of all modules packaged with this module
# ModuleList = @()

# List of all files packaged with this module
# FileList = @()

# Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
PrivateData = @{

    PSData = @{

        # Tags applied to this module. These help with module discovery in online galleries.
        # Tags = @()

        # A URL to the license for this module.
        # LicenseUri = ''

        # A URL to the main website for this project.
        # ProjectUri = ''

        # A URL to an icon representing this module.
        # IconUri = ''

        # ReleaseNotes of this module
        # ReleaseNotes = ''

        # Prerelease string of this module
        # Prerelease = ''

        # Flag to indicate whether the module requires explicit user acceptance for install/update/save
        # RequireLicenseAcceptance = $false

        # External dependent modules of this module
        # ExternalModuleDependencies = @()

    } # End of PSData hashtable

} # End of PrivateData hashtable

# HelpInfo URI of this module
# HelpInfoURI = ''

# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
# DefaultCommandPrefix = ''

}

