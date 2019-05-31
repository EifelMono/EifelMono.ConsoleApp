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

        public static Task<int> RunAsync(this IArgsBuilderArgs thisValue, IConsole console = null)
            => (thisValue.Command as RootCommand).InvokeAsync(thisValue.Args, console);

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

        public static T Alias<T>(this T thisValue, string name) where T : IArgsBuilderAlias
        {
            thisValue.Command.AddAlias(name);
            return thisValue;
        }
    }
}
