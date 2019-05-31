using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace EifelMono.Commandline
{
    public static class CommandBuilderExtensions
    {
        public static CommandBuilderRootCommand CommandBuilder(this string[] thisValue, string name = null)
        {
            var result = new CommandBuilderRootCommand()
            {
                Args = thisValue,
                Command = new RootCommand(name),
                Parent = null
            };
            return result;
        }

        public static Task<int> RunAsync(this CommandBuilderRoot thisValue, Action<string[]> action = null)
        {
            var rootCommand = thisValue.Command as RootCommand;
            if (action is object)
                rootCommand.Handler = CommandHandler.Create(() => action(thisValue.Args));
            return rootCommand.InvokeAsync(thisValue.Args);
        }

        public static Task<int> RunAsync(this CommandBuilderRoot thisValue, Action action = null)
        {
            var rootCommand = thisValue.Command as RootCommand;
            if (action is object)
                rootCommand.Handler = CommandHandler.Create(action);
            return rootCommand.InvokeAsync(thisValue.Args);
        }

        public static CommandBuilderLevel1Command Command(this CommandBuilderRootCommand thisValue, string name, string description = null)
        {
            var result = new CommandBuilderLevel1Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }

        public static CommandBuilderLevel2Command Command(this CommandBuilderLevel1Command thisValue, string name, string description = null)
        {
            var result = new CommandBuilderLevel2Command
            {
                Command = new Command(name, description),
                Parent = thisValue
            };
            thisValue.Command.AddCommand(result.Command);
            return result;
        }


        public static T Alias<T>(this T thisValue, string name) where T : ICommandBuilderAlias
        {
            thisValue.Command.AddAlias(name);
            return thisValue;
        }
    }
}
