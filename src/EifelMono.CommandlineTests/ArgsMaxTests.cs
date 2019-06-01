using System;
using System.Reflection;
using EifelMono.Commandline;
using EifelMono.Fluent.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.CommandlineTests
{
    public class ArgMaxTests : XunitCore
    {
        public ArgMaxTests(ITestOutputHelper output) : base(output) { }

        [Theory]
        [InlineData("RootCommand")]
        [InlineData("--Level1-1", "--Level1-1")]
        [InlineData("--Level1-2", "--Level1-1", "--Level1-2")]
        [InlineData("--Level1-3", "--Level1-1", "--Level1-2", "--Level1-3")]
        [InlineData("--Level1-4", "--Level1-1", "--Level1-2", "--Level1-3", "--Level1-4")]
        [InlineData("--Level1-5", "--Level1-1", "--Level1-2", "--Level1-3", "--Level1-4", "--Level1-5")]
        [InlineData("--Level1-6", "--Level1-1", "--Level1-2", "--Level1-3", "--Level1-4", "--Level1-5", "--Level1-6")]
        public async void Command_Level_Tests(string result, params string[] args)
        {
            var commandResult = "";
            var value = await args.ArgsBuilder()
                .SplitLine().WriteLine(GetMethodName()).ArgsLine().SplitLine().UseTerminal(TestTerminal)
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
                .OnCommand(() => commandResult += "RootCommand")
                .RunAsync();
            DumpTestTerminal();
            Assert.Equal(result, commandResult);
        }

        [Theory]
        [InlineData("RootCommand")]
        [InlineData("--Level1-1", "--Level1-1")]
        [InlineData("--Level1-2", "--Level1-1", "--Level1-2")]
        [InlineData("--Level1-3", "--Level1-1", "--Level1-2", "--Level1-3")]
        [InlineData("--Level1-4", "--Level1-1", "--Level1-2", "--Level1-3", "--Level1-4")]
        [InlineData("--Level1-5", "--Level1-1", "--Level1-2", "--Level1-3", "--Level1-4", "--Level1-5")]
        [InlineData("--Level1-6", "--Level1-1", "--Level1-2", "--Level1-3", "--Level1-4", "--Level1-5", "--Level1-6")]
        [InlineData("--Level2-1", "--Level2-1")]
        [InlineData("--Level2-2", "--Level2-1", "--Level2-2")]
        [InlineData("--Level2-3", "--Level2-1", "--Level2-2", "--Level2-3")]
        [InlineData("--Level2-4", "--Level2-1", "--Level2-2", "--Level2-3", "--Level2-4")]
        [InlineData("--Level2-5", "--Level2-1", "--Level2-2", "--Level2-3", "--Level2-4", "--Level2-5")]
        [InlineData("--Level2-6", "--Level2-1", "--Level2-2", "--Level2-3", "--Level2-4", "--Level2-5", "--Level2-6")]
        [InlineData("--Level3-1", "--Level3-1")]
        [InlineData("--Level3-2", "--Level3-1", "--Level3-2")]
        [InlineData("--Level3-3", "--Level3-1", "--Level3-2", "--Level3-3")]
        [InlineData("--Level3-4", "--Level3-1", "--Level3-2", "--Level3-3", "--Level3-4")]
        [InlineData("--Level3-5", "--Level3-1", "--Level3-2", "--Level3-3", "--Level3-4", "--Level3-5")]
        [InlineData("--Level3-6", "--Level3-1", "--Level3-2", "--Level3-3", "--Level3-4", "--Level3-5", "--Level3-6")]
        public async void Commands_Level_Tests(string result, params string[] args)
        {
            var commandResult = "";
            var value = await args.ArgsBuilder()
                .SplitLine().WriteLine(GetMethodName()).ArgsLine().SplitLine().UseTerminal(TestTerminal)
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
                    .Command("--Level2-1")
                        .Command("--Level2-2")
                            .Command("--Level2-3")
                                .Command("--Level2-4")
                                    .Command("--Level2-5")
                                        .Command("--Level2-6")
                                        .OnCommand(() => commandResult += "--Level2-6")
                                    .OnCommand(() => commandResult += "--Level2-5")
                                .OnCommand(() => commandResult += "--Level2-4")
                            .OnCommand(() => commandResult += "--Level2-3")
                        .OnCommand(() => commandResult += "--Level2-2")
                    .OnCommand(() => commandResult += "--Level2-1")
                    .Command("--Level3-1")
                        .Command("--Level3-2")
                            .Command("--Level3-3")
                                .Command("--Level3-4")
                                    .Command("--Level3-5")
                                        .Command("--Level3-6")
                                        .OnCommand(() => commandResult += "--Level3-6")
                                    .OnCommand(() => commandResult += "--Level3-5")
                                .OnCommand(() => commandResult += "--Level3-4")
                            .OnCommand(() => commandResult += "--Level3-3")
                        .OnCommand(() => commandResult += "--Level3-2")
                    .OnCommand(() => commandResult += "--Level3-1")
                .OnCommand(() => commandResult += "RootCommand")
                .RunAsync();
            DumpTestTerminal();
            Assert.Equal(result, commandResult);
        }
    }
}
