@echo off

set pc=%PHOME%\bld\drops\Debug\x64\Binaries\pc.exe

echo %pc% /generate:C# german.p /t:german.4ml
call %pc% /generate:C# german.p /t:german.4ml

if NOT errorlevel 0 goto :eof

echo %pc% /generate:C# /link /r:german.4ml
call %pc% /generate:C# /link /r:german.4ml

echo now consider running something like "pt /os linker.dll"

