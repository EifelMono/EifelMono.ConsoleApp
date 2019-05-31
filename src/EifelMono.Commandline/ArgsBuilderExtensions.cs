using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace EifelMono.Commandline
{
    public static class ArgsBuilderExtensions
    {
        public static ArgsBuilderRootCommand ArgsBuilder(this string[] thisValue, string description = null)
        {
            var result = new ArgsBuilderRootCommand()
            {
                Args = thisValue,
                Command = new RootCommand(description),
                Parent = null
            };
            return result;
        }


        public static Task<int> RunAsync(this IArgsBuilderArgs thisValue)
        {
            foreach (var line in thisValue.Lines)
                if (thisValue.Console is object)
                    thisValue.Console.Out.WriteLine(line);
                else
                    Console.WriteLine(line);
            return (thisValue.Command as RootCommand).InvokeAsync(thisValue.Args, thisValue.Console);
        }

        public static ArgsBuilderLevel1Command Command(this ArgsBuilderRootCommand thisValue, string name, string description = null)
        {
            var result = new ArgsBuilderLevel1Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static ArgsBuilderLevel2Command Command(this ArgsBuilderLevel1Command thisValue, string name, string description = null)
        {
            var result = new ArgsBuilderLevel2Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static T WriteLine<T>(this T thisValue, string line) where T : ArgsBuilderRootCommand
        {
            thisValue.Lines.Add(line);
            return thisValue;
        }
        public static T SplitLine<T>(this T thisValue, char @char = '-', int count = 79) where T : ArgsBuilderRootCommand
        {
            thisValue.Lines.Add(new string(@char, count));
            return thisValue;
        }
        public static T EmptyLine<T>(this T thisValue) where T : ArgsBuilderRootCommand
        {
            thisValue.Lines.Add("");
            return thisValue;
        }

        public static T ArgsLine<T>(this T thisValue) where T : ArgsBuilderRootCommand
        {
            thisValue.Lines.Add($"args={string.Join("|", thisValue.Args)}");
            return thisValue;
        }

        public static T UseTerminal<T>(this T thisValue, IConsole console) where T : ArgsBuilderRootCommand
        {
            thisValue.Console = console;
            return thisValue;
        }


        public static T Alias<T>(this T thisValue, string name) where T : IArgsBuilderAlias
        {
            thisValue.Command.AddAlias(name);
            return thisValue;
        }
    }
}
