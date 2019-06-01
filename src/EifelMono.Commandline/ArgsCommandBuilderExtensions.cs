using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace EifelMono.Commandline
{
    public static class ArgsCommandBuilderExtensions
    {
        public static ArgsCommandBuilderRootCommand ArgsCommandBuilder(this string[] thisValue, string description = null)
        {
            var result = new ArgsCommandBuilderRootCommand()
            {
                Args = thisValue,
                Command = new RootCommand(description),
                Parent = null
            };
            return result;
        }

        public static Task<int> RunAsync(this IArgsComamandBuilderArgs thisValue)
        {
            foreach (var line in thisValue.Lines)
                if (thisValue.Console is object)
                    thisValue.Console.Out.WriteLine(line);
                else
                    Console.WriteLine(line);
            return (thisValue.Command as RootCommand).InvokeAsync(thisValue.Args, thisValue.Console);
        }

        public static ArgsCommandBuilderLevel1Command Command(this ArgsCommandBuilderRootCommand thisValue, string name, string description = null)
        {
            var result = new ArgsCommandBuilderLevel1Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static ArgsCommandBuilderLevel2Command Command(this ArgsCommandBuilderLevel1Command thisValue, string name, string description = null)
        {
            var result = new ArgsCommandBuilderLevel2Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static ArgsCommandBuilderLevel3Command Command(this ArgsCommandBuilderLevel2Command thisValue, string name, string description = null)
        {
            var result = new ArgsCommandBuilderLevel3Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static ArgsCommandBuilderLevel4Command Command(this ArgsCommandBuilderLevel3Command thisValue, string name, string description = null)
        {
            var result = new ArgsCommandBuilderLevel4Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static ArgsCommandBuilderLevel5Command Command(this ArgsCommandBuilderLevel4Command thisValue, string name, string description = null)
        {
            var result = new ArgsCommandBuilderLevel5Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static ArgsCommandBuilderLevel6Command Command(this ArgsCommandBuilderLevel5Command thisValue, string name, string description = null)
        {
            var result = new ArgsCommandBuilderLevel6Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static T Alias<T>(this T thisValue, string name) where T : IArgsCommandBuilderAlias
        {
            thisValue.Command.AddAlias(name);
            return thisValue;
        }

        public static T WriteLine<T>(this T thisValue, string line) where T : ArgsCommandBuilderRootCommand
        {
            thisValue.Lines.Add(line);
            return thisValue;
        }
        public static T SplitLine<T>(this T thisValue, char @char = '-', int count = 79) where T : ArgsCommandBuilderRootCommand
        {
            thisValue.Lines.Add(new string(@char, count));
            return thisValue;
        }
        public static T EmptyLine<T>(this T thisValue) where T : ArgsCommandBuilderRootCommand
        {
            thisValue.Lines.Add("");
            return thisValue;
        }

        public static T NewLine<T>(this T thisValue) where T : ArgsCommandBuilderRootCommand
            => thisValue.EmptyLine();

        public static T ArgsLine<T>(this T thisValue) where T : ArgsCommandBuilderRootCommand
        {
            thisValue.Lines.Add($"args={string.Join("|", thisValue.Args)}");
            return thisValue;
        }

        public static T UseTerminal<T>(this T thisValue, IConsole console) where T : ArgsCommandBuilderRootCommand
        {
            thisValue.Console = console;
            return thisValue;
        }
    }
}
