@echo off

REM clean all intermediate files, and files produced during execution

del *.4ml      2> nul
del *.cs       2> nul
del linker.pdb 2> nul

del concretes*      2> nul
del abstracts*      2> nul
del abstract_succs* 2> nul
del s.txt           2> nul
del succ.txt        2> nul
