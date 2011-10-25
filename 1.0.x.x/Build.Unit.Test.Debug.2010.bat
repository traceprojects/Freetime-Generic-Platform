call "C:\Program Files\Microsoft Visual Studio 10.0\VC\vcvarsall.bat"


echo Building 900.Freetime.Unit.Test.2010.sln
echo.
devenv /build debug "1Solution.2010\900.Freetime.Unit.Test.2010.sln"
echo. 
echo Done Building 900.Freetime.Unit.Test.2010.sln
echo.

pause