@echo off

set pc=%PHOME%\bld\drops\Debug\x64\Binaries\pc.exe

echo %pc% /generate:C# test.p /t:test.4ml
call %pc% /generate:C# test.p /t:test.4ml

if NOT errorlevel 0 goto :eof

echo %pc% /generate:C# /link /r:test.4ml
call %pc% /generate:C# /link /r:test.4ml

echo now consider running something like "pt /dfs linker.dll"

