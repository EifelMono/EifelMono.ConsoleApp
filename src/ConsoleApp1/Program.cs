using System;
using System.Threading.Tasks;
using EifelMono.Commandline;
using EifelMono.Fluent;

namespace ConsoleApp1
{
    class Program
    {
        static readonly int s_useTest = 1;
        static Task<int> Main(string[] args)
            => s_useTest switch
            {
                1 => Main1(args),
                2 => Main2(args),
                _ => Task.FromResult(4711),
            };

        static Task<int> Main1(string[] args)
            => args.ArgsCommandBuilder(nameof(Main1))
                .WriteLine($"{nameof(ConsoleApp1)} {nameof(Main1)} {fluent.App.Version}")
                .SplitLine().ArgsLine().SplitLine().NewLine()
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
                .OnRootCommand(() =>
                {
                    Console.WriteLine("RootCommand");
                })
                .RunAsync();
    }
}
