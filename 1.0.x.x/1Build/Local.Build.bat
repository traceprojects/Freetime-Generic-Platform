echo off

..\Libs\nant-0.91\bin\NAnt.exe -buildfile:Freetime-Generic-Platform.build > build.log

@echo **** done.  check build.log for errors ****
pause
start notepad.exe build.log