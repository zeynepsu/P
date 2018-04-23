@REM set THISDIR=%~dp0
@REM pushd %THISDIR%

@set pc=..\..\..\..\..\bld\drops\Debug\x64\Binaries\pc.exe
@if not exist "%pc%" goto :noP

@set pt=..\..\..\..\..\bld\drops\Debug\x64\Binaries\pt.exe
@if not exist "%pt%" goto :noPT

@echo generating C# code ...

%pc% /generate:C# /shared German.p /t:German.4ml

@echo done

@if errorlevel 0  (
  @echo building dll ...
  %pc% /generate:C# /link /shared TestScript.p /r:German.4ml
) else (
  @echo generating C# code: something went wrong
)

@echo done

@echo skipping the rest

@goto :eof

if NOT errorlevel 0 goto :eof

%pt% /psharp Test0.dll

goto :eof

:noP
echo please run ..\..\..\..\..\bld\build release x64
exit /b 1

:noPT
echo please build PTester
exit /b 1
