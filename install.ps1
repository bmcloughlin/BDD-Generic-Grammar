param($installPath, $toolsPath, $package, $project)

# delete Class1.cs
$project.ProjectItems | Where-Object { $_.Name -eq 'Class1.cs' } | ForEach-Object { $_.Delete() }

# Add the Post Build Event
$project.Properties.Item("PostBuildEvent").Value = 'start xcopy /Y "$(ProjectDir)Drivers" "$(ProjectDir)$(OutDir)"'


# set routes.json 'Copy To Output Directory' to 'Copy if newer'
$routesItem = $project.ProjectItems.Item("routes.json")
$copyToOutput = $routesItem.Properties.Item("CopyToOutputDirectory")
$copyToOutput.Value = 1

# remove unused references
$project.Object.References | Where-Object { $_.Name -eq 'System.Data' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'System.Data.DataSetExtensions' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'System.Drawing' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'System.Xml' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'System.Xml.Linq' } | ForEach-Object { $_.Remove() }



