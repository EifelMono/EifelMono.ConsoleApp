using System;
using System.Reflection;
using EifelMono.Commandline;
using EifelMono.Fluent.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.CommandlineTests
{
    public class PlayGroundTests : XunitCore
    {

        public PlayGroundTests(ITestOutputHelper output) : base(output) { }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false, "--string-a", "Hello", "--int-x", "4711")]
        [InlineData(1, false, "--string-ax", "Hello", "--int-x", "4711")]
        [InlineData(1, false, "--string-a", "Hello", "--int-x", "4711a")]
        public async void RootCommand_WithtoutOption_Tests(int shouldValue, bool shouldInCommand, params string[] args)
        {
            bool inCommand = false;
            var value = await args.ArgsCommandBuilder()
                .HorizontalLine().WriteLine(GetMethodName()).ArgsLine().HorizontalLine().UseTerminal(TestTerminal)
                .OnRootCommand(() =>
                {
                    WriteLine($"RootCommand");
                    inCommand = true;
                })
                .RunAsync();
            DumpTestTerminal();
            Assert.Equal(shouldInCommand, inCommand);
            Assert.Equal(shouldValue, value);
        }

        [Theory]
        [InlineData(0, true, "--string-a", "Hello", "--int-x", "4711")]
        [InlineData(1, false, "--string-ax", "Hello", "--int-x", "4711")]
        [InlineData(1, false, "--string-a", "Hello", "--int-x", "4711a")]
        // why is result 1 ?
        [InlineData(1, true)]
        public async void RootCommand_WithOption_Tests(int shouldValue, bool shouldInCommand, params string[] args)
        {
            bool inCommand = false;
            var value = await args.ArgsCommandBuilder()
                .HorizontalLine().WriteLine(GetMethodName()).ArgsLine().HorizontalLine().UseTerminal(TestTerminal)
                .Option<string>("--string-a", default, "c# => stringa")
                .Option<int>("--int-x", default, "c# => intx")
                .OnRootCommand((stringa, intx) =>
                {
                    WriteLine($"RootCommand stringa={stringa} intx={intx}");
                    inCommand = true;
                    Assert.Equal(args[1], stringa);
                    Assert.Equal(args[3], intx.ToString());
                })
                .RunAsync();
            DumpTestTerminal();
            Assert.Equal(shouldInCommand, inCommand);
            Assert.Equal(shouldValue, value);
        }

        [Fact]
        public async void RootCommand1Tests()
        {
            var args = new string[] { };
            var value = await args.ArgsCommandBuilder()
                .HorizontalLine().WriteLine(GetMethodName()).ArgsLine().HorizontalLine().UseTerminal(TestTerminal)
                .Command("command1")
                    .Alias("-c1")
                    .Option<int>("--int-a", default, "c# name => inta")
                    .Option<string>("--string-b", default, "c# name => stringb")
                    .Option<double>("--double-c", default, "c# name => doublec")
                    .OnCommand((inta, stringb, doublec) =>
                    {
                        WriteLine($"command1 {inta} {stringb} {doublec}");
                    })
                .OnRootCommand(() =>
                {
                    WriteLine("RootCommand {string.Join('|', args)}");
                })
                .RunAsync();
        }

        [Fact]
        public async void AllTests()
        {
            var args = new string[] { };
            var value = await args.ArgsCommandBuilder()
                .HorizontalLine().WriteLine(GetMethodName()).ArgsLine().HorizontalLine().UseTerminal(TestTerminal)
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
                .OnRootCommand(() =>
                {
                    WriteLine("RootCommand");
                })
                .RunAsync();
        }
    }
}
