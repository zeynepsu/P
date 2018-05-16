@echo off

REM thorough cleanup, including dlls

@call clean

del *~         2> nul
del linker.dll 2> nul
