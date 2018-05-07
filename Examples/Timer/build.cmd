@echo off

set pc=%PHOME%\bld\drops\Debug\x64\Binaries\pc.exe

echo %pc% /generate:C# Timer.p /t:Timer.4ml
call %pc% /generate:C# Timer.p /t:Timer.4ml

if NOT errorlevel 0 goto :eof

echo %pc% /generate:C# Main.p /t:Main.4ml /r:Timer.4ml
call %pc% /generate:C# Main.p /t:Main.4ml /r:Timer.4ml

if NOT errorlevel 0 goto :eof

echo %pc% /generate:C# /link /r:Timer.4ml /r:Main.4ml
call %pc% /generate:C# /link /r:Timer.4ml /r:Main.4ml

echo now consider running something like "pt /dfs linker.dll"

