@echo off

%~dp0quadeq -RegServer
regsvr32 /s %~dp0quadeqps.dll
regsvr32 /s %~dp0finance.dll
echo.
:done
