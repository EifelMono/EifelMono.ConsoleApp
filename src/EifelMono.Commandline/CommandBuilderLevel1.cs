using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace EifelMono.Commandline
{
    public class CommandBuilderLevel1 : CommandBuilder { }

    public class CommandBuilderLevel1Command : CommandBuilderLevel1, ICommandBuilderAlias
    {
        public CommandBuilderLevel1Option<T1> Option<T1>(string name, T1 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T1>(defaultValue), isHidden));
            return new CommandBuilderLevel1Option<T1>().Clone(this);
        }
        public CommandBuilderRootCommand OnCommand(Action action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as CommandBuilderRootCommand;
        }
    }

    public class CommandBuilderLevel1Option<T1> : CommandBuilderLevel1
    {
        public CommandBuilderLevel1Option<T1, T2> Option<T2>(string name, T2 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T2>(defaultValue), isHidden));
            return new CommandBuilderLevel1Option<T1, T2>().Clone(this);
        }

        public CommandBuilderRootCommand OnCommand(Action<T1> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as CommandBuilderRootCommand;
        }
    }

    public class CommandBuilderLevel1Option<T1, T2> : CommandBuilderLevel1
    {
        public CommandBuilderLevel1Option<T1, T2, T3> Option<T3>(string name, T3 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T3>(defaultValue), isHidden));
            return new CommandBuilderLevel1Option<T1, T2, T3>().Clone(this);
        }
        public CommandBuilderRootCommand OnCommand(Action<T1, T2> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as CommandBuilderRootCommand;
        }
    }
    public class CommandBuilderLevel1Option<T1, T2, T3> : CommandBuilderLevel1
    {
        public CommandBuilderRootCommand OnCommand(Action<T1, T2, T3> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as CommandBuilderRootCommand;
        }
    }
}
