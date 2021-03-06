﻿using EifelMono.CommandLine;
using EifelMono.Fluent;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.CommandLineTests
{
    public class OptionLevel6Tests : XunitCore
    {
        public OptionLevel6Tests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async void None_Tests()
        {
            var commandResult = "";
            var line = $"com1 com2 com3 com4 com5 com6";
            var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            var value = await args.ArgsCommandBuilder()
                .UseTerminal(TestTerminal)
                    .Command("com1")
                    .Command("com2")
                    .Command("com3")
                    .Command("com4")
                    .Command("com5")
                    .Command("com6")
                    .OnCommand(() => commandResult += "InCommand6")
                    .OnCommand(() => commandResult += "InCommand5")
                    .OnCommand(() => commandResult += "InCommand4")
                    .OnCommand(() => commandResult += "InCommand3")
                    .OnCommand(() => commandResult += "InCommand2")
                    .OnCommand(() => commandResult += "InCommand1")
                .OnRootCommand(() => commandResult += "InCommandRoot")
                .RunAsync();
            DumpTestTerminal();
            Assert.Equal("InCommand6", commandResult);
        }

        [Fact]
        public async void Var1_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
            {
                var commandResult = "";
                var line = $"com1 com2 com3 com4 com5 com6 --var1 {arg1}";
                var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                var value = await args.ArgsCommandBuilder()
                    .UseTerminal(TestTerminal)
                        .Command("com1")
                        .Command("com2")
                        .Command("com3")
                        .Command("com4")
                        .Command("com5")
                        .Command("com6")
                        .Option<Type1>("--var1")
                        .OnCommand((var1) =>
                        {
                            Assert.Equal(arg1.GetType(), var1.GetType());
                            Assert.Equal(arg1, var1);
                            commandResult += "InCommand6";
                        })
                        .OnCommand(() => commandResult += "InCommand5")
                        .OnCommand(() => commandResult += "InCommand4")
                        .OnCommand(() => commandResult += "InCommand3")
                        .OnCommand(() => commandResult += "InCommand2")
                        .OnCommand(() => commandResult += "InCommand1")
                    .OnRootCommand(() => commandResult += "InCommandRoot")
                    .RunAsync();
                DumpTestTerminal();
                Assert.Equal("InCommand6", commandResult);
            }
        }
        [Fact]
        public async void Var1Var2_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                {
                    var commandResult = "";
                    var line = $"com1 com2 com3 com4 com5 com6 --var1 {arg1} --var2 {arg2}";
                    var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                    var value = await args.ArgsCommandBuilder()
                        .UseTerminal(TestTerminal)
                            .Command("com1")
                            .Command("com2")
                            .Command("com3")
                            .Command("com4")
                            .Command("com5")
                            .Command("com6")
                            .Option<Type1>("--var1")
                            .Option<Type2>("--var2")
                            .OnCommand((var1, var2) =>
                            {
                                Assert.Equal(arg1.GetType(), var1.GetType());
                                Assert.Equal(arg1, var1);
                                Assert.Equal(arg2.GetType(), var2.GetType());
                                Assert.Equal(arg2, var2);
                                commandResult += "InCommand6";
                            })
                            .OnCommand(() => commandResult += "InCommand5")
                            .OnCommand(() => commandResult += "InCommand4")
                            .OnCommand(() => commandResult += "InCommand3")
                            .OnCommand(() => commandResult += "InCommand2")
                            .OnCommand(() => commandResult += "InCommand1")
                        .OnRootCommand(() => commandResult += "InCommandRoot")
                        .RunAsync();
                    DumpTestTerminal();
                    Assert.Equal("InCommand6", commandResult);
                }
        }
        [Fact]
        public async void Var1Var2Var3_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                    {
                        var commandResult = "";
                        var line = $"com1 com2 com3 com4 com5 com6 --var1 {arg1} --var2 {arg2} --var3 {arg3}";
                        var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                        var value = await args.ArgsCommandBuilder()
                            .UseTerminal(TestTerminal)
                                .Command("com1")
                                .Command("com2")
                                .Command("com3")
                                .Command("com4")
                                .Command("com5")
                                .Command("com6")
                                .Option<Type1>("--var1")
                                .Option<Type2>("--var2")
                                .Option<Type3>("--var3")
                                .OnCommand((var1, var2, var3) =>
                                {
                                    Assert.Equal(arg1.GetType(), var1.GetType());
                                    Assert.Equal(arg1, var1);
                                    Assert.Equal(arg2.GetType(), var2.GetType());
                                    Assert.Equal(arg2, var2);
                                    Assert.Equal(arg3.GetType(), var3.GetType());
                                    Assert.Equal(arg3, var3);
                                    commandResult += "InCommand6";
                                })
                                .OnCommand(() => commandResult += "InCommand5")
                                .OnCommand(() => commandResult += "InCommand4")
                                .OnCommand(() => commandResult += "InCommand3")
                                .OnCommand(() => commandResult += "InCommand2")
                                .OnCommand(() => commandResult += "InCommand1")
                            .OnRootCommand(() => commandResult += "InCommandRoot")
                            .RunAsync();
                        DumpTestTerminal();
                        Assert.Equal("InCommand6", commandResult);
                    }
        }
        [Fact]
        public async void Var1Var2Var3Var4_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                        foreach (var arg4 in fluent.Enum.Values<Type4>())
                        {
                            var commandResult = "";
                            var line = $"com1 com2 com3 com4 com5 com6 --var1 {arg1} --var2 {arg2} --var3 {arg3} --var4 {arg4}";
                            var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                            var value = await args.ArgsCommandBuilder()
                                .UseTerminal(TestTerminal)
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
                                    .OnCommand((var1, var2, var3, var4) =>
                                    {
                                        Assert.Equal(arg1.GetType(), var1.GetType());
                                        Assert.Equal(arg1, var1);
                                        Assert.Equal(arg2.GetType(), var2.GetType());
                                        Assert.Equal(arg2, var2);
                                        Assert.Equal(arg3.GetType(), var3.GetType());
                                        Assert.Equal(arg3, var3);
                                        Assert.Equal(arg4.GetType(), var4.GetType());
                                        Assert.Equal(arg4, var4);
                                        commandResult += "InCommand6";
                                    })
                                    .OnCommand(() => commandResult += "InCommand5")
                                    .OnCommand(() => commandResult += "InCommand4")
                                    .OnCommand(() => commandResult += "InCommand3")
                                    .OnCommand(() => commandResult += "InCommand2")
                                    .OnCommand(() => commandResult += "InCommand1")
                                .OnRootCommand(() => commandResult += "InCommandRoot")
                                .RunAsync();
                            DumpTestTerminal();
                            Assert.Equal("InCommand6", commandResult);
                        }
        }
        [Fact]
        public async void Var1Var2Var3Var4Var5_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                        foreach (var arg4 in fluent.Enum.Values<Type4>())
                            foreach (var arg5 in fluent.Enum.Values<Type5>())
                            {
                                var commandResult = "";
                                var line = $"com1 com2 com3 com4 com5 com6 --var1 {arg1} --var2 {arg2} --var3 {arg3} --var4 {arg4} --var5 {arg5}";
                                var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                                var value = await args.ArgsCommandBuilder()
                                    .UseTerminal(TestTerminal)
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
                                        .OnCommand((var1, var2, var3, var4, var5) =>
                                        {
                                            Assert.Equal(arg1.GetType(), var1.GetType());
                                            Assert.Equal(arg1, var1);
                                            Assert.Equal(arg2.GetType(), var2.GetType());
                                            Assert.Equal(arg2, var2);
                                            Assert.Equal(arg3.GetType(), var3.GetType());
                                            Assert.Equal(arg3, var3);
                                            Assert.Equal(arg4.GetType(), var4.GetType());
                                            Assert.Equal(arg4, var4);
                                            Assert.Equal(arg5.GetType(), var5.GetType());
                                            Assert.Equal(arg5, var5);
                                            commandResult += "InCommand6";
                                        })
                                        .OnCommand(() => commandResult += "InCommand5")
                                        .OnCommand(() => commandResult += "InCommand4")
                                        .OnCommand(() => commandResult += "InCommand3")
                                        .OnCommand(() => commandResult += "InCommand2")
                                        .OnCommand(() => commandResult += "InCommand1")
                                    .OnRootCommand(() => commandResult += "InCommandRoot")
                                    .RunAsync();
                                DumpTestTerminal();
                                Assert.Equal("InCommand6", commandResult);
                            }
        }
        [Fact]
        public async void Var1Var2Var3Var4Var5Var6_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                        foreach (var arg4 in fluent.Enum.Values<Type4>())
                            foreach (var arg5 in fluent.Enum.Values<Type5>())
                                foreach (var arg6 in fluent.Enum.Values<Type6>())
                                {
                                    var commandResult = "";
                                    var line = $"com1 com2 com3 com4 com5 com6 --var1 {arg1} --var2 {arg2} --var3 {arg3} --var4 {arg4} --var5 {arg5} --var6 {arg6}";
                                    var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                                    var value = await args.ArgsCommandBuilder()
                                        .UseTerminal(TestTerminal)
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
                                                Assert.Equal(arg1.GetType(), var1.GetType());
                                                Assert.Equal(arg1, var1);
                                                Assert.Equal(arg2.GetType(), var2.GetType());
                                                Assert.Equal(arg2, var2);
                                                Assert.Equal(arg3.GetType(), var3.GetType());
                                                Assert.Equal(arg3, var3);
                                                Assert.Equal(arg4.GetType(), var4.GetType());
                                                Assert.Equal(arg4, var4);
                                                Assert.Equal(arg5.GetType(), var5.GetType());
                                                Assert.Equal(arg5, var5);
                                                Assert.Equal(arg6.GetType(), var6.GetType());
                                                Assert.Equal(arg6, var6);
                                                commandResult += "InCommand6";
                                            })
                                            .OnCommand(() => commandResult += "InCommand5")
                                            .OnCommand(() => commandResult += "InCommand4")
                                            .OnCommand(() => commandResult += "InCommand3")
                                            .OnCommand(() => commandResult += "InCommand2")
                                            .OnCommand(() => commandResult += "InCommand1")
                                        .OnRootCommand(() => commandResult += "InCommandRoot")
                                        .RunAsync();
                                    DumpTestTerminal();
                                    Assert.Equal("InCommand6", commandResult);
                                }
        }
        [Fact]
        public async void Var1Var2Var3Var4Var5Var6Var7_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                        foreach (var arg4 in fluent.Enum.Values<Type4>())
                            foreach (var arg5 in fluent.Enum.Values<Type5>())
                                foreach (var arg6 in fluent.Enum.Values<Type6>())
                                    foreach (var arg7 in fluent.Enum.Values<Type7>())
                                    {
                                        var commandResult = "";
                                        var line = $"com1 com2 com3 com4 com5 com6 --var1 {arg1} --var2 {arg2} --var3 {arg3} --var4 {arg4} --var5 {arg5} --var6 {arg6} --var7 {arg7}";
                                        var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                                        var value = await args.ArgsCommandBuilder()
                                            .UseTerminal(TestTerminal)
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
                                                .Option<Type7>("--var7")
                                                .OnCommand((var1, var2, var3, var4, var5, var6, var7) =>
                                                {
                                                    Assert.Equal(arg1.GetType(), var1.GetType());
                                                    Assert.Equal(arg1, var1);
                                                    Assert.Equal(arg2.GetType(), var2.GetType());
                                                    Assert.Equal(arg2, var2);
                                                    Assert.Equal(arg3.GetType(), var3.GetType());
                                                    Assert.Equal(arg3, var3);
                                                    Assert.Equal(arg4.GetType(), var4.GetType());
                                                    Assert.Equal(arg4, var4);
                                                    Assert.Equal(arg5.GetType(), var5.GetType());
                                                    Assert.Equal(arg5, var5);
                                                    Assert.Equal(arg6.GetType(), var6.GetType());
                                                    Assert.Equal(arg6, var6);
                                                    Assert.Equal(arg7.GetType(), var7.GetType());
                                                    Assert.Equal(arg7, var7);
                                                    commandResult += "InCommand6";
                                                })
                                                .OnCommand(() => commandResult += "InCommand5")
                                                .OnCommand(() => commandResult += "InCommand4")
                                                .OnCommand(() => commandResult += "InCommand3")
                                                .OnCommand(() => commandResult += "InCommand2")
                                                .OnCommand(() => commandResult += "InCommand1")
                                            .OnRootCommand(() => commandResult += "InCommandRoot")
                                            .RunAsync();
                                        DumpTestTerminal();
                                        Assert.Equal("InCommand6", commandResult);
                                    }
        }

        [Fact]
        public async void Default_Var1_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
            {
                var commandResult = "";
                var line = $"com1 com2 com3 com4 com5 com6";
                var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                var value = await args.ArgsCommandBuilder()
                    .UseTerminal(TestTerminal)
                        .Command("com1")
                        .Command("com2")
                        .Command("com3")
                        .Command("com4")
                        .Command("com5")
                        .Command("com6")
                        .Option<Type1>("--var1", arg1)
                        .OnCommand((var1) =>
                        {
                            Assert.Equal(arg1.GetType(), var1.GetType());
                            Assert.Equal(arg1, var1);
                            commandResult += "InCommand6";
                        })
                        .OnCommand(() => commandResult += "InCommand5")
                        .OnCommand(() => commandResult += "InCommand4")
                        .OnCommand(() => commandResult += "InCommand3")
                        .OnCommand(() => commandResult += "InCommand2")
                        .OnCommand(() => commandResult += "InCommand1")
                    .OnRootCommand(() => commandResult += "InCommandRoot")
                    .RunAsync();
                DumpTestTerminal();
                Assert.Equal("InCommand6", commandResult);
            }
        }
        [Fact]
        public async void Default_Var1Var2_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                {
                    var commandResult = "";
                    var line = $"com1 com2 com3 com4 com5 com6";
                    var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                    var value = await args.ArgsCommandBuilder()
                        .UseTerminal(TestTerminal)
                            .Command("com1")
                            .Command("com2")
                            .Command("com3")
                            .Command("com4")
                            .Command("com5")
                            .Command("com6")
                            .Option<Type1>("--var1", arg1)
                            .Option<Type2>("--var2", arg2)
                            .OnCommand((var1, var2) =>
                            {
                                Assert.Equal(arg1.GetType(), var1.GetType());
                                Assert.Equal(arg1, var1);
                                Assert.Equal(arg2.GetType(), var2.GetType());
                                Assert.Equal(arg2, var2);
                                commandResult += "InCommand6";
                            })
                            .OnCommand(() => commandResult += "InCommand5")
                            .OnCommand(() => commandResult += "InCommand4")
                            .OnCommand(() => commandResult += "InCommand3")
                            .OnCommand(() => commandResult += "InCommand2")
                            .OnCommand(() => commandResult += "InCommand1")
                        .OnRootCommand(() => commandResult += "InCommandRoot")
                        .RunAsync();
                    DumpTestTerminal();
                    Assert.Equal("InCommand6", commandResult);
                }
        }
        [Fact]
        public async void Default_Var1Var2Var3_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                    {
                        var commandResult = "";
                        var line = $"com1 com2 com3 com4 com5 com6";
                        var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                        var value = await args.ArgsCommandBuilder()
                            .UseTerminal(TestTerminal)
                                .Command("com1")
                                .Command("com2")
                                .Command("com3")
                                .Command("com4")
                                .Command("com5")
                                .Command("com6")
                                .Option<Type1>("--var1", arg1)
                                .Option<Type2>("--var2", arg2)
                                .Option<Type3>("--var3", arg3)
                                .OnCommand((var1, var2, var3) =>
                                {
                                    Assert.Equal(arg1.GetType(), var1.GetType());
                                    Assert.Equal(arg1, var1);
                                    Assert.Equal(arg2.GetType(), var2.GetType());
                                    Assert.Equal(arg2, var2);
                                    Assert.Equal(arg3.GetType(), var3.GetType());
                                    Assert.Equal(arg3, var3);
                                    commandResult += "InCommand6";
                                })
                                .OnCommand(() => commandResult += "InCommand5")
                                .OnCommand(() => commandResult += "InCommand4")
                                .OnCommand(() => commandResult += "InCommand3")
                                .OnCommand(() => commandResult += "InCommand2")
                                .OnCommand(() => commandResult += "InCommand1")
                            .OnRootCommand(() => commandResult += "InCommandRoot")
                            .RunAsync();
                        DumpTestTerminal();
                        Assert.Equal("InCommand6", commandResult);
                    }
        }
        [Fact]
        public async void Default_Var1Var2Var3Var4_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                        foreach (var arg4 in fluent.Enum.Values<Type4>())
                        {
                            var commandResult = "";
                            var line = $"com1 com2 com3 com4 com5 com6";
                            var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                            var value = await args.ArgsCommandBuilder()
                                .UseTerminal(TestTerminal)
                                    .Command("com1")
                                    .Command("com2")
                                    .Command("com3")
                                    .Command("com4")
                                    .Command("com5")
                                    .Command("com6")
                                    .Option<Type1>("--var1", arg1)
                                    .Option<Type2>("--var2", arg2)
                                    .Option<Type3>("--var3", arg3)
                                    .Option<Type4>("--var4", arg4)
                                    .OnCommand((var1, var2, var3, var4) =>
                                    {
                                        Assert.Equal(arg1.GetType(), var1.GetType());
                                        Assert.Equal(arg1, var1);
                                        Assert.Equal(arg2.GetType(), var2.GetType());
                                        Assert.Equal(arg2, var2);
                                        Assert.Equal(arg3.GetType(), var3.GetType());
                                        Assert.Equal(arg3, var3);
                                        Assert.Equal(arg4.GetType(), var4.GetType());
                                        Assert.Equal(arg4, var4);
                                        commandResult += "InCommand6";
                                    })
                                    .OnCommand(() => commandResult += "InCommand5")
                                    .OnCommand(() => commandResult += "InCommand4")
                                    .OnCommand(() => commandResult += "InCommand3")
                                    .OnCommand(() => commandResult += "InCommand2")
                                    .OnCommand(() => commandResult += "InCommand1")
                                .OnRootCommand(() => commandResult += "InCommandRoot")
                                .RunAsync();
                            DumpTestTerminal();
                            Assert.Equal("InCommand6", commandResult);
                        }
        }
        [Fact]
        public async void Default_Var1Var2Var3Var4Var5_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                        foreach (var arg4 in fluent.Enum.Values<Type4>())
                            foreach (var arg5 in fluent.Enum.Values<Type5>())
                            {
                                var commandResult = "";
                                var line = $"com1 com2 com3 com4 com5 com6";
                                var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                                var value = await args.ArgsCommandBuilder()
                                    .UseTerminal(TestTerminal)
                                        .Command("com1")
                                        .Command("com2")
                                        .Command("com3")
                                        .Command("com4")
                                        .Command("com5")
                                        .Command("com6")
                                        .Option<Type1>("--var1", arg1)
                                        .Option<Type2>("--var2", arg2)
                                        .Option<Type3>("--var3", arg3)
                                        .Option<Type4>("--var4", arg4)
                                        .Option<Type5>("--var5", arg5)
                                        .OnCommand((var1, var2, var3, var4, var5) =>
                                        {
                                            Assert.Equal(arg1.GetType(), var1.GetType());
                                            Assert.Equal(arg1, var1);
                                            Assert.Equal(arg2.GetType(), var2.GetType());
                                            Assert.Equal(arg2, var2);
                                            Assert.Equal(arg3.GetType(), var3.GetType());
                                            Assert.Equal(arg3, var3);
                                            Assert.Equal(arg4.GetType(), var4.GetType());
                                            Assert.Equal(arg4, var4);
                                            Assert.Equal(arg5.GetType(), var5.GetType());
                                            Assert.Equal(arg5, var5);
                                            commandResult += "InCommand6";
                                        })
                                        .OnCommand(() => commandResult += "InCommand5")
                                        .OnCommand(() => commandResult += "InCommand4")
                                        .OnCommand(() => commandResult += "InCommand3")
                                        .OnCommand(() => commandResult += "InCommand2")
                                        .OnCommand(() => commandResult += "InCommand1")
                                    .OnRootCommand(() => commandResult += "InCommandRoot")
                                    .RunAsync();
                                DumpTestTerminal();
                                Assert.Equal("InCommand6", commandResult);
                            }
        }
        [Fact]
        public async void Default_Var1Var2Var3Var4Var5Var6_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                        foreach (var arg4 in fluent.Enum.Values<Type4>())
                            foreach (var arg5 in fluent.Enum.Values<Type5>())
                                foreach (var arg6 in fluent.Enum.Values<Type6>())
                                {
                                    var commandResult = "";
                                    var line = $"com1 com2 com3 com4 com5 com6";
                                    var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                                    var value = await args.ArgsCommandBuilder()
                                        .UseTerminal(TestTerminal)
                                            .Command("com1")
                                            .Command("com2")
                                            .Command("com3")
                                            .Command("com4")
                                            .Command("com5")
                                            .Command("com6")
                                            .Option<Type1>("--var1", arg1)
                                            .Option<Type2>("--var2", arg2)
                                            .Option<Type3>("--var3", arg3)
                                            .Option<Type4>("--var4", arg4)
                                            .Option<Type5>("--var5", arg5)
                                            .Option<Type6>("--var6", arg6)
                                            .OnCommand((var1, var2, var3, var4, var5, var6) =>
                                            {
                                                Assert.Equal(arg1.GetType(), var1.GetType());
                                                Assert.Equal(arg1, var1);
                                                Assert.Equal(arg2.GetType(), var2.GetType());
                                                Assert.Equal(arg2, var2);
                                                Assert.Equal(arg3.GetType(), var3.GetType());
                                                Assert.Equal(arg3, var3);
                                                Assert.Equal(arg4.GetType(), var4.GetType());
                                                Assert.Equal(arg4, var4);
                                                Assert.Equal(arg5.GetType(), var5.GetType());
                                                Assert.Equal(arg5, var5);
                                                Assert.Equal(arg6.GetType(), var6.GetType());
                                                Assert.Equal(arg6, var6);
                                                commandResult += "InCommand6";
                                            })
                                            .OnCommand(() => commandResult += "InCommand5")
                                            .OnCommand(() => commandResult += "InCommand4")
                                            .OnCommand(() => commandResult += "InCommand3")
                                            .OnCommand(() => commandResult += "InCommand2")
                                            .OnCommand(() => commandResult += "InCommand1")
                                        .OnRootCommand(() => commandResult += "InCommandRoot")
                                        .RunAsync();
                                    DumpTestTerminal();
                                    Assert.Equal("InCommand6", commandResult);
                                }
        }
        [Fact]
        public async void Default_Var1Var2Var3Var4Var5Var6Var7_Tests()
        {
            foreach (var arg1 in fluent.Enum.Values<Type1>())
                foreach (var arg2 in fluent.Enum.Values<Type2>())
                    foreach (var arg3 in fluent.Enum.Values<Type3>())
                        foreach (var arg4 in fluent.Enum.Values<Type4>())
                            foreach (var arg5 in fluent.Enum.Values<Type5>())
                                foreach (var arg6 in fluent.Enum.Values<Type6>())
                                    foreach (var arg7 in fluent.Enum.Values<Type7>())
                                    {
                                        var commandResult = "";
                                        var line = $"com1 com2 com3 com4 com5 com6";
                                        var args = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                                        var value = await args.ArgsCommandBuilder()
                                            .UseTerminal(TestTerminal)
                                                .Command("com1")
                                                .Command("com2")
                                                .Command("com3")
                                                .Command("com4")
                                                .Command("com5")
                                                .Command("com6")
                                                .Option<Type1>("--var1", arg1)
                                                .Option<Type2>("--var2", arg2)
                                                .Option<Type3>("--var3", arg3)
                                                .Option<Type4>("--var4", arg4)
                                                .Option<Type5>("--var5", arg5)
                                                .Option<Type6>("--var6", arg6)
                                                .Option<Type7>("--var7", arg7)
                                                .OnCommand((var1, var2, var3, var4, var5, var6, var7) =>
                                                {
                                                    Assert.Equal(arg1.GetType(), var1.GetType());
                                                    Assert.Equal(arg1, var1);
                                                    Assert.Equal(arg2.GetType(), var2.GetType());
                                                    Assert.Equal(arg2, var2);
                                                    Assert.Equal(arg3.GetType(), var3.GetType());
                                                    Assert.Equal(arg3, var3);
                                                    Assert.Equal(arg4.GetType(), var4.GetType());
                                                    Assert.Equal(arg4, var4);
                                                    Assert.Equal(arg5.GetType(), var5.GetType());
                                                    Assert.Equal(arg5, var5);
                                                    Assert.Equal(arg6.GetType(), var6.GetType());
                                                    Assert.Equal(arg6, var6);
                                                    Assert.Equal(arg7.GetType(), var7.GetType());
                                                    Assert.Equal(arg7, var7);
                                                    commandResult += "InCommand6";
                                                })
                                                .OnCommand(() => commandResult += "InCommand5")
                                                .OnCommand(() => commandResult += "InCommand4")
                                                .OnCommand(() => commandResult += "InCommand3")
                                                .OnCommand(() => commandResult += "InCommand2")
                                                .OnCommand(() => commandResult += "InCommand1")
                                            .OnRootCommand(() => commandResult += "InCommandRoot")
                                            .RunAsync();
                                        DumpTestTerminal();
                                        Assert.Equal("InCommand6", commandResult);
                                    }
        }
    }
}
