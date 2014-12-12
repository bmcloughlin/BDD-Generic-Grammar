@echo Off
set config=%1

if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0

if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=

if "%nuget%" == "" (
	set nuget=nuget
)

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild BDD-Generic-Grammar.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net40

%nuget% pack " BDD-Generic-Grammar.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"






<!--C:\work\BDD-Generic-Grammar>nuget pack "BDD-Generic-Grammar.nuspec" -NoPackageAnalysis -verbosity detailed  -Version 1.0.0.0 -p Configuration="debug"-->