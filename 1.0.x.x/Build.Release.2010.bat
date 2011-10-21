@echo off
call "C:\Program Files\Microsoft Visual Studio 10.0\VC\vcvarsall.bat"
@echo on

echo Building 001.Freetime.Framework.2010.sln
echo.
devenv /build release "1Solution.2010\001.Freetime.Framework.2010.sln"
echo. 
echo Done Building 001.Freetime.Framework.2010.sln
echo.

echo Building 002.Freetime.Data.2010.sln
echo.
devenv /build release "1Solution.2010\002.Freetime.Data.2010.sln"
echo. 
echo Done Building 002.Freetime.Data.2010.sln
echo.

echo Building 003.Freetime.Util.2010.sln
echo.
devenv /build release "1Solution.2010\003.Freetime.Util.2010.sln"
echo. 
echo Done Building 003.Freetime.Util.2010.sln
echo.

echo Building 004.Freetime.PluginManagement.2010.sln
echo.
devenv /build release "1Solution.2010\004.Freetime.PluginManagement.2010.sln"
echo. 
echo Done Building 004.Freetime.PluginManagement.2010.sln
echo.

echo Building 005.Freetime.Data.Services.2010.sln
echo.
devenv /build release "1Solution.2010\005.Freetime.Data.Services.2010.sln"
echo. 
echo Done Building 005.Freetime.Data.Services.2010.sln
echo.

echo Building 006.Freetime.Business.2010.sln
echo.
devenv /build release "1Solution.2010\006.Freetime.Business.2010.sln"
echo. 
echo Done Building 005.Freetime.Data.Services.2010.sln
echo.

echo Building 007.Freetime.Data.Services.Client.2010.sln
echo.
devenv /build release "1Solution.2010\007.Freetime.Data.Services.Client.2010.sln"
echo. 
echo Done Building 007.Freetime.Data.Services.Client.2010.sln
echo.

echo Building 008.Freetime.Web.Base.2010.sln
echo.
devenv /build release "1Solution.2010\008.Freetime.Web.Base.2010.sln"
echo. 
echo Done Building 008.Freetime.Web.Base.2010.sln
echo.

echo Building 009.Freetime.Web.2010.sln
echo.
devenv /build release "1Solution.2010\009.Freetime.Web.2010.sln"
echo. 
echo Done Building 009.Freetime.Web.2010.sln
echo.

echo Building 900.Freetime.Unit.Test.2010.sln
echo.
devenv /build release "1Solution.2010\900.Freetime.Unit.Test.2010.sln"
echo. 
echo Done Building 009.Freetime.Web.2010.sln
echo.

pause