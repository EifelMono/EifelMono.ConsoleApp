using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace EifelMono.Commandline
{
    public class CommandBuilderLevel2 : CommandBuilder { }

    public class CommandBuilderLevel2Command : CommandBuilderLevel2, ICommandBuilderAlias
    {
        public CommandBuilderLevel2Option<T1> Option<T1>(string name, T1 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T1>(defaultValue), isHidden));
            return new CommandBuilderLevel2Option<T1>().Clone(this);
        }
        public CommandBuilderLevel1Command OnCommand(Action action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as CommandBuilderLevel1Command;
        }
    }

    public class CommandBuilderLevel2Option<T1> : CommandBuilderLevel2
    {
        public CommandBuilderLevel2Option<T1, T2> Option<T2>(string name, T2 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T2>(defaultValue), isHidden));
            return new CommandBuilderLevel2Option<T1, T2>().Clone(this);
        }

        public CommandBuilderLevel1Command OnCommand(Action<T1> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as CommandBuilderLevel1Command;
        }
    }

    public class CommandBuilderLevel2Option<T1, T2> : CommandBuilderLevel2
    {
        public CommandBuilderLevel2Option<T1, T2, T3> Option<T3>(string name, T3 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T3>(defaultValue), isHidden));
            return new CommandBuilderLevel2Option<T1, T2, T3>().Clone(this);
        }
        public CommandBuilderLevel1Command OnCommand(Action<T1, T2> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as CommandBuilderLevel1Command;
        }
    }
    public class CommandBuilderLevel2Option<T1, T2, T3> : CommandBuilderLevel2
    {
        public CommandBuilderLevel1Command OnCommand(Action<T1, T2, T3> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as CommandBuilderLevel1Command;
        }
    }
}
