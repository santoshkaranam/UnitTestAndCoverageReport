
# before running this file make sure all the nuggets in solution are resported and packages folder path is updated.
$rawCoverageFolder = "$PSScriptRoot\Nunit.Demo.Test\TestResults";

dotnet build Nunit.Demo.sln

# delete old results
Remove-Item -Path C:\code\nunit-demo\Nunit.Demo\Reports -Recurse -Force

#create folders
New-Item -Path C:\code\nunit-demo\Nunit.Demo\Reports -ItemType "directory"
New-Item -Path C:\code\nunit-demo\Nunit.Demo\Reports\coverage -ItemType "directory"

# run tests and collect coverage stats
dotnet test --logger:nunit --collect:"Code Coverage" --settings:C:\code\nunit-demo\Nunit.Demo\CodeCoverage.runsettings.xml

#Get raw coverage file
$recentCoverageFile = Get-ChildItem -File -Filter *.coverage -Path $rawCoverageFolder -Recurse | Select-Object -First 1;

#Generate xml coverage report
C:\Users\hrida\.nuget\packages\microsoft.codecoverage\16.5.0\build\netstandard1.0\CodeCoverage\CodeCoverage.exe analyze /output:C:\code\nunit-demo\Nunit.Demo\Reports\coverage\coverage.xml $recentCoverageFile.FullName

#copy xml TestResults.xml report to results folder
Copy-Item -Path "$PSScriptRoot\Nunit.Demo.Test\TestResults\TestResults.xml" -Destination "$PSScriptRoot\Reports"

#Generate html coverage report
C:\Users\hrida\.nuget\packages\reportgenerator\4.5.6\tools\netcoreapp3.0\ReportGenerator.exe -reports:"$PSScriptRoot\Reports\coverage\coverage.xml" -vernosity:Info -targetdir:"$PSScriptRoot\Reports\coverage"

#Generate html test cases report
.\extent.exe -i .\Reports\TestResults.xml -o .\Reports

# remove raw coverage report files 
Remove-Item -Path $rawCoverageFolder -Recurse -Force
   