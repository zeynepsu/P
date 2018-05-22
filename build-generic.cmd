@echo off

if %1.==. goto no-file

set src=%1

set pc=%PHOME%\bld\drops\Debug\x64\Binaries\pc.exe

echo %pc% /generate:C# %src%.p /t:%src%.4ml
call %pc% /generate:C# %src%.p /t:%src%.4ml

if NOT errorlevel 0 goto eof

echo %pc% /generate:C# /link /r:%src%.4ml
call %pc% /generate:C# /link /r:%src%.4ml

move linker.dll %src%.dll

echo now consider running something like "pt /dfs %src%.dll"

goto eof

:no-file
  echo must provide .P file argument, *without* suffix .P, e.g. "build german"

:eof
