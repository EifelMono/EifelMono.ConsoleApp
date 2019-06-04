using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EifelMono.CommandLine;
using EifelMono.Fluent;
using EifelMono.Fluent.Extensions;
using EifelMono.Fluent.IO;

namespace ConsoleApp1
{
    class Program
    {
        static string s_DefaultSample = "Wiki";
        static Task<int> Main(string[] args)
            => DirectoryPath.OS.Current.CloneToFilePath("sample.txt")
                .ReadAllText(s_DefaultSample).Replace("\r", "").Replace("\n", "") switch
                {
                    "Wiki" => MainFromWiki(args),
                    "WikiStuff" => MainFromWikiWithAdditionalStuff(args),
                    "Main1" => Main1(args),
                    "Main2" => Main2(args),
                    _ => Task.FromResult(4711),
                };


        // https://github.com/dotnet/command-line-api/wiki/Your-first-app-with-System.CommandLine
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


        static Task<int> Main1(string[] args)
            => args.ArgsCommandBuilder(nameof(Main1))
                .WriteLine($"{nameof(ConsoleApp1)} {nameof(Main1)} {fluent.App.Version}")
                .HorizontalLine().ArgsLine().HorizontalLine().NewLine()
                .Option<string>("--string-a", default, "c# => stringa")
                .Option<int>("--int-x", default, "c# => intx")
                .Option<DayOfWeek>("--dow", default, "c# => dow")
                .OnRootCommand((stringa, intx, dow) =>
                {
                    Console.WriteLine($"RootCommand stringa={stringa} intx={intx} dow={dow}");
                })
                .RunAsync();

        static Task<int> Main2(string[] args)
            => args.ArgsCommandBuilder()
                .WriteLine($"{nameof(ConsoleApp1)} {nameof(Main2)} {fluent.App.Version}")
                .HorizontalLine().ArgsLine().HorizontalLine().NewLine()
                    .Command("command1")
                        .Alias("-c1")
                        .Command("command1.1")
                        .Option<int>("--int-1a", 1, "c# name => int1a")
                        .Option<int>("--int-1b", 1, "c# name => int1b")
                        .OnCommand((int1a, int1b) =>
                        {
                            Console.WriteLine($"command1 command1.1 int1a={int1a} intb={int1b}");
                        })
                        .Command("command1.2")
                        .Option<int>("--int-2a", 2, "c# name => int2a")
                        .OnCommand((int2a) =>
                        {
                            Console.WriteLine($"command1 command1.2 inta={int2a}");
                        })
                    .Option<int>("--int-3a", 3, "c# name => int3a")
                    .Option<string>("--string-3b", default, "c# name => string3b")
                    .Option<double>("--double-3c", default, "c# name => double3c")
                    .OnCommand((int3a, string3b, double3c) =>
                    {
                        Console.WriteLine($"command1 int3a={int3a} string3b={string3b} double3c={double3c}");
                    })
                    .Command("command2")
                        .Alias("-c2")
                        .Option<DayOfWeek>("--dow", default, "c# name => dow")
                    .OnCommand((dow) =>
                    {
                        Console.WriteLine($"command2 {dow}");
                    })
                .OnRootCommand(() =>
                {
                    Console.WriteLine("RootCommand");
                })
                .RunAsync();
    }
}
