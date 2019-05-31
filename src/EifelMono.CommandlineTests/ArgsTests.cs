using EifelMono.CommandlineTests.XunitTests;
using Xunit;
using Xunit.Abstractions;
using EifelMono.Commandline;
using System;

namespace EifelMono.CommandlineTests
{
    public class ArgTests : XunitCore
    {

        public ArgTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async void RootTests()
        {
            var args = new string[] { };
            var value = await args.CommandBuilder()
                .RunAsync(() =>
                {
                    WriteLine("RootCommand");
                });
        }

        [Fact]
        public async void RootCommand1Tests()
        {
            var args = new string[] { };
            var value = await args.CommandBuilder()
                .Command("command1")
                    .Alias("-c1")
                    .Option<int>("--int-a", default, "c# name => inta")
                    .Option<string>("--string-b", default, "c# name => stringb")
                    .Option<double>("--double-c", default, "c# name => doublec")
                    .OnCommand((inta, stringb, doublec) =>
                    {
                        WriteLine($"command1 {inta} {stringb} {doublec}");
                    })
                .RunAsync(() =>
                {
                    WriteLine("RootCommand");
                });
        }

        [Fact]
        public async void AllTests()
        {
            var args = new string[] { };
            var value = await args.CommandBuilder()
                .Command("command1")
                    .Command("command1.1")
                        .Option<int>("- -int-a", default, "c# name => inta")
                        .OnCommand((inta) =>
                        {
                            WriteLine($"command1.1 {inta}");
                        })
                    .Command("command1.2")
                        .Option<int>("--int-a", default, "c# name => inta")
                        .OnCommand((inta) =>
                        {
                            WriteLine($"command1.2 {inta}");
                        })
                    .Alias("-c1")
                    .Option<int>("--int-a", default, "c# name => inta")
                    .Option<string>("--string-b", default, "c# name => stringb")
                    .Option<double>("--double-c", default, "c# name => doublec")
                    .OnCommand((inta, stringb, doublec) =>
                    {
                        WriteLine($"command1 {inta} {stringb} {doublec}");
                    })
                .Command("command2")
                    .Alias("-c2")
                    .Option<DayOfWeek>("--dow", default, "c# name => dow")
                    .OnCommand((dow) =>
                    {
                        WriteLine($"command2 {dow}");
                    })
                .RunAsync(() =>
                {
                    WriteLine("RootCommand");
                });
        }
    }
}
