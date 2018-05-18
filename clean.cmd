@echo off

REM clean all intermediate files, and files produced during execution

del *.4ml         2> nul
del *.cs          2> nul
del linker.pdb    2> nul

del concrete*     2> nul
del abstract*     2> nul
del ab_succs*     2> nul
del ab_s.txt      2> nul
del ab_s_succ.txt 2> nul
