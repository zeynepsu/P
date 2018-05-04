@echo pc /generate:C# Timer.p /t:Timer.4ml
@call pc /generate:C# Timer.p /t:Timer.4ml

@echo pc /generate:C# Main.p /t:Main.4ml /r:Timer.4ml
@call pc /generate:C# Main.p /t:Main.4ml /r:Timer.4ml

@echo pc /generate:C# /link /r:Timer.4ml /r:Main.4ml
@call pc /generate:C# /link /r:Timer.4ml /r:Main.4ml

@echo now consider running something like "pt /dfs linker.dll"
