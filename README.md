# EifelMono.CommandLine


EifelMono.Commandline added a fluent interface on top of the

* System.CommandLine.Experimental
* System.Interactive.Async

##### [Sample from the github wiki](https://github.com/dotnet/command-line-api/wiki/Your-first-app-with-System.CommandLine) in fluent form
```csharp
static Task<int> MainFromWiki(string[] args)
    => args.ArgsCommandBuilder("My sample app")
        .Option<int>("--int-option", 42, "An option whose argument is parsed as an int")
        .Option<bool>("--bool-option", default, "An option whose argument is parsed as a bool")
        .Option<FileInfo>("--file-option", default, "An option whose argument is parsed as a FileInfo")
        .OnRootCommand((intOption, boolOption, fileOption) =>
        {
            Console.WriteLine($"The value for --int-option is: {intOption}");
            Console.WriteLine($"The value for --bool-option is: {boolOption}");
            Console.WriteLine($"The value for --file-option is: {fileOption?.FullName ?? "null"}");
        })
        .RunAsync();
```

#### or with Text output before RunAsync (only if no "[suggest" exist in the args) 
```csharp
static Task<int> MainFromWikiWithAdditionalStuff(string[] args)
    => args.ArgsCommandBuilder("My sample app")
        .WriteLine($"{nameof(ConsoleApp1)} {nameof(MainFromWiki)} {fluent.App.Version}")
        .HorizontalLine()
        .ArgsLine()
        .HorizontalLine()
        .NewLine()
        .Option<int>("--int-option", 42, "An option whose argument is parsed as an int")
        .Option<bool>("--bool-option", default, "An option whose argument is parsed as a bool")
        .Option<FileInfo>("--file-option", default, "An option whose argument is parsed as a FileInfo")
        .OnRootCommand((intOption, boolOption, fileOption) =>
        {
            Console.WriteLine($"The value for --int-option is: {intOption}");
            Console.WriteLine($"The value for --bool-option is: {boolOption}");
            Console.WriteLine($"The value for --file-option is: {fileOption?.FullName ?? "null"}");
        })
        .RunAsync();
```

#### The command level depth is 7
```csharp
    var value = await args.ArgsCommandBuilder()
    .HorizontalLine().WriteLine(GetMethodName()).ArgsLine().HorizontalLine().UseTerminal(TestTerminal)
        .Command("--Level1-1")
            .Command("--Level1-2")
                .Command("--Level1-3")
                    .Command("--Level1-4")
                        .Command("--Level1-5")
                            .Command("--Level1-6")
                            .OnCommand(() => commandResult += "--Level1-6")
                        .OnCommand(() => commandResult += "--Level1-5")
                    .OnCommand(() => commandResult += "--Level1-4")
                .OnCommand(() => commandResult += "--Level1-3")
            .OnCommand(() => commandResult += "--Level1-2")
        .OnCommand(() => commandResult += "--Level1-1")
    .OnRootCommand(() => commandResult += "RootCommand")
    .RunAsync();
```

 
The options depth is also 7 
```csharp

var value = await args.ArgsCommandBuilder()
        .Command("com1")
        .Option<Type1>("--var1")
        .Option<Type2>("--var2")
        .Option<Type3>("--var3")
        .Option<Type4>("--var4")
        .OnCommand((var1, var2, var3, var4) =>
        {
        })
    .OnRootCommand(() => commandResult += "InCommandRoot")
    .RunAsync();


 var value = await args.ArgsCommandBuilder()
        .Command("com1")
            .Command("com2")
                .Command("com3")
                    .Command("com4")
                        .Command("com5")
                            .Command("com6")
                            .Option<Type1>("--var1")
                            .Option<Type2>("--var2")
                            .Option<Type3>("--var3")
                            .Option<Type4>("--var4")
                            .Option<Type5>("--var5")
                            .Option<Type6>("--var6")
                            .OnCommand((var1, var2, var3, var4, var5, var6) =>
                            {
                            })
                        .OnCommand(() => commandResult += "InCommand5")
                    .OnCommand(() => commandResult += "InCommand4")
                .OnCommand(() => commandResult += "InCommand3")
            .OnCommand(() => commandResult += "InCommand2")
        .OnCommand(() => commandResult += "InCommand1")
    .OnRootCommand(() => commandResult += "InCommandRoot")
    .RunAsync();
``` 
