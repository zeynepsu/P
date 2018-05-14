@echo off

REM clean all intermediate files, and files produced during execution

del *.4ml      2> nul
del *.cs       2> nul
del linker.pdb 2> nul

del vis*             2> nul
del vs.txt           2> nul
del vs_succ_cand.txt 2> nul
