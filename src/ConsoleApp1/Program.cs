using System;
using System.Threading.Tasks;
using EifelMono.Commandline;
using EifelMono.Fluent;

namespace ConsoleApp1
{
    class Program
    {
        static async Task<int> Main(string[] args)
            => await MainXxX(args);

        static Task<int> MainX(string[] args)
            => args.ArgsBuilder(nameof(MainX))
                .WriteLine($"{nameof(ConsoleApp1)} {nameof(MainX)} {fluent.App.Version}")
                .SplitLine().ArgsLine().SplitLine().NewLine()
                .Option<string>("--string-a", default, "c# => stringa")
                .Option<int>("--int-x", default, "c# => intx")
                .Option<DayOfWeek>("--dow", default, "c# => dow")
                .OnCommand((stringa, intx, dow) =>
                {
                    Console.WriteLine($"RootCommand stringa={stringa} intx={intx} dow={dow}");
                })
                .RunAsync();

        static Task<int> MainXxX(string[] args)
            => args.ArgsBuilder()
                .WriteLine($"{nameof(ConsoleApp1)} {nameof(MainXxX)} {fluent.App.Version}")
                .SplitLine().ArgsLine().SplitLine().NewLine()
                .Command("command1")
                    .Alias("-c1")
                    .Command("command1.1")
                        .Option<int>("--int-a", default, "c# name => inta")
                        .OnCommand((inta) =>
                        {
                            Console.WriteLine($"command1.1 {inta}");
                        })
                    .Command("command1.2")
                        .Option<int>("--int-a", 4711, "c# name => inta")
                        .OnCommand((inta) =>
                        {
                            Console.WriteLine($"command1.2 {inta}");
                        })
                    .Option<int>("--int-a", default, "c# name => inta")
                    .Option<string>("--string-b", default, "c# name => stringb")
                    .Option<double>("--double-c", default, "c# name => doublec")
                    .OnCommand((inta, stringb, doublec) =>
                    {
                        Console.WriteLine($"command1 {inta} {stringb} {doublec}");
                    })
                .Command("command2")
                    .Alias("-c2")
                    .Option<DayOfWeek>("--dow", default, "c# name => dow")
                    .OnCommand((dow) =>
                    {
                        Console.WriteLine($"command2 {dow}");
                    })
                .OnCommand(() =>
                {
                    Console.WriteLine("RootCommand");
                })
                .RunAsync();
    }
}
