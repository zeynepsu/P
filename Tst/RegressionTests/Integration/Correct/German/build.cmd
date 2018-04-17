pc /generate:C# /shared German.p /t:German.4ml

if NOT errorlevel 0 goto :eof

pc /generate:C# /link /shared TestScript.p /r:German.4ml

if NOT errorlevel 0 goto :eof

pt /psharp Test0.dll

