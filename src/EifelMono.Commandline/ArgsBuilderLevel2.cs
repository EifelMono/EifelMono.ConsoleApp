using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace EifelMono.Commandline
{
    public class ArgsBuilderLevel2 : ArgsBuilder { }

    public class ArgsBuilderLevel2Command : ArgsBuilderLevel2, IArgsBuilderAlias
    {
        public ArgsBuilderLevel2Option<T1> Option<T1>(string name, T1 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T1>(defaultValue), isHidden));
            return new ArgsBuilderLevel2Option<T1>().Clone(this);
        }
        public ArgsBuilderLevel1Command OnCommand(Action action)
        {
            if (action is object)
                Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsBuilderLevel1Command;
        }
    }

    public class ArgsBuilderLevel2Option<T1> : ArgsBuilderLevel2
    {
        public ArgsBuilderLevel2Option<T1, T2> Option<T2>(string name, T2 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T2>(defaultValue), isHidden));
            return new ArgsBuilderLevel2Option<T1, T2>().Clone(this);
        }

        public ArgsBuilderLevel1Command OnCommand(Action<T1> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsBuilderLevel1Command;
        }
    }

    public class ArgsBuilderLevel2Option<T1, T2> : ArgsBuilderLevel2
    {
        public ArgsBuilderLevel2Option<T1, T2, T3> Option<T3>(string name, T3 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T3>(defaultValue), isHidden));
            return new ArgsBuilderLevel2Option<T1, T2, T3>().Clone(this);
        }
        public ArgsBuilderLevel1Command OnCommand(Action<T1, T2> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsBuilderLevel1Command;
        }
    }
    public class ArgsBuilderLevel2Option<T1, T2, T3> : ArgsBuilderLevel2
    {
        public ArgsBuilderLevel1Command OnCommand(Action<T1, T2, T3> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsBuilderLevel1Command;
        }
    }
}
