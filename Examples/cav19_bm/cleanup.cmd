@echo off

REM thorough cleanup, including dlls

@call clean

del *.dll *~ 2> nul
