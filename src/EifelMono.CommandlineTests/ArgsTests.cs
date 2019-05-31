using System;
using System.Reflection;
using EifelMono.Commandline;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.CommandlineTests
{
    public class ArgTests : XunitCore
    {

        public ArgTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async void RootCommand_WithtoutOption_Tests()
        {
            Console.WriteLine("Hello World");
            Console.Error.WriteLine("Hello Error");
            try
            {
                var args = new string[] { };
                var value = await args.ArgsBuilder()
                    .OnCommand(() =>
                    {
                        WriteLine("RootCommand");
                    })
                    .RunAsync(TestTerminal);
            }
            finally
            {
                DumpTestTerminal();
            }
        }

        [Theory]
        [InlineData(0, true, "--string-a", "Hello", "--int-x", "4711")]
        [InlineData(1, false, "--string-ax", "Hello", "--int-x", "4711")]
        [InlineData(1, false, "--string-a", "Hello", "--int-x", "4711a")]
        [InlineData(1, true)]
        public async void RootCommand_WithOption_Tests(int shouldValue, bool shouldInCommand, params string[] args)
        {
            try
            {
                bool inCommand = false;
                var value = await args.ArgsBuilder()
                    .Option<string>("--string-a", default, "c# => stringa")
                    .Option<int>("--int-x", default, "c# => intx")
                    .OnCommand((stringa, intx) =>
                    {
                        WriteLine($"RootCommand stringa={stringa} intx={intx}");
                        inCommand = true;
                        Assert.Equal(args[1], stringa);
                        Assert.Equal(args[3], intx.ToString());
                    })
                    .RunAsync(TestTerminal);
                Assert.Equal(shouldInCommand, inCommand);
                Assert.Equal(shouldValue, value);
            }
            finally
            {
                DumpTestTerminal();
            }
        }

        [Fact]
        public async void RootCommand1Tests()
        {
            var args = new string[] { };
            var value = await args.ArgsBuilder()
                .Command("command1")
                    .Alias("-c1")
                    .Option<int>("--int-a", default, "c# name => inta")
                    .Option<string>("--string-b", default, "c# name => stringb")
                    .Option<double>("--double-c", default, "c# name => doublec")
                    .OnCommand((inta, stringb, doublec) =>
                    {
                        WriteLine($"command1 {inta} {stringb} {doublec}");
                    })
                .OnCommand(() =>
                {
                    WriteLine("RootCommand {string.Join('|', args)}");
                })
                .RunAsync();
        }

        [Fact]
        public async void AllTests()
        {
            var args = new string[] { };
            var value = await args.ArgsBuilder()
                .Command("command1")
                    .Command("command1.1")
                        .Option<int>("--int-a", default, "c# name => inta")
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
                .OnCommand(() =>
                {
                    WriteLine("RootCommand");
                })
                .RunAsync(TestTerminal);
        }
    }
}
