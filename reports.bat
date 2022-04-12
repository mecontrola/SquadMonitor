@echo off

if not exist "%~dp0BuildReports" mkdir "%~dp0BuildReports"

rd /s /q %~dp0BuildReports

dotnet restore --force %~dp0Stefanini.sln

dotnet build %~dp0Stefanini.sln

dotnet test %~dp0Stefanini.sln ^
            --results-directory %~dp0BuildReports/UnitTests ^
            --collect:"XPlat Code Coverage" ^
            --no-restore ^
            --no-build ^
            --verbosity=minimal ^
            /p:CollectCoverage=true ^
            /p:CoverletOutput="%~dp0BuildReports/Coverage/" ^
            /p:CoverletOutputFormat=cobertura ^
            /p:Exclude="[xunit.*]*

dotnet "%~dp0tools\ReportGenerator.dll" ^
           -reports:%~dp0BuildReports\UnitTests\**\*.cobertura.xml ^
           -targetdir:%~dp0BuildReports\Coverage ^
           -reporttypes:HTML;HTMLSummary
pause
start "report" "%~dp0BuildReports\Coverage\index.html"