@echo off
call "C:\Program Files\Microsoft Visual Studio 9.0\VC\vcvarsall.bat"
@echo on

echo Building 001.Freetime.Framework.2008.sln
echo.
devenv /build release "1Solution.2008\001.Freetime.Framework.2008.sln"
echo. 
echo Done Building 001.Freetime.Framework.2008.sln
echo.

echo Building 002.Freetime.Data.2008.sln
echo.
devenv /build release "1Solution.2008\002.Freetime.Data.2008.sln"
echo. 
echo Done Building 002.Freetime.Data.2008.sln
echo.

echo Building 003.Freetime.Util.2008.sln
echo.
devenv /build release "1Solution.2008\003.Freetime.Util.2008.sln"
echo. 
echo Done Building 003.Freetime.Util.2008.sln
echo.

echo Building 004.Freetime.PluginManagement.2008.sln
echo.
devenv /build release "1Solution.2008\004.Freetime.PluginManagement.2008.sln"
echo. 
echo Done Building 004.Freetime.PluginManagement.2008.sln
echo.

echo Building 005.Freetime.Data.Services.2008.sln
echo.
devenv /build release "1Solution.2008\005.Freetime.Data.Services.2008.sln"
echo. 
echo Done Building 005.Freetime.Data.Services.2008.sln
echo.

echo Building 006.Freetime.Business.2008.sln
echo.
devenv /build release "1Solution.2008\006.Freetime.Business.2008.sln"
echo. 
echo Done Building 005.Freetime.Data.Services.2008.sln
echo.

echo Building 007.Freetime.Data.Services.Client.2008.sln
echo.
devenv /build release "1Solution.2008\007.Freetime.Data.Services.Client.2008.sln"
echo. 
echo Done Building 007.Freetime.Data.Services.Client.2008.sln
echo.

pause