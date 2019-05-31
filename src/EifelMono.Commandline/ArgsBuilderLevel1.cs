using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace EifelMono.Commandline
{
    public class ArgsBuilderLevel1 : ArgsBuilder { }

    public class ArgsBuilderLevel1Command : ArgsBuilderLevel1, IArgsBuilderAlias
    {
        public ArgsBuilderLevel1Option<T1> Option<T1>(string name, T1 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T1>(defaultValue), isHidden));
            return new ArgsBuilderLevel1Option<T1>().Clone(this);
        }
        public ArgsBuilderRootCommand OnCommand(Action action = null)
        {
            if (action is object)
                Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsBuilderRootCommand;
        }
    }

    public class ArgsBuilderLevel1Option<T1> : ArgsBuilderLevel1
    {
        public ArgsBuilderLevel1Option<T1, T2> Option<T2>(string name, T2 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T2>(defaultValue), isHidden));
            return new ArgsBuilderLevel1Option<T1, T2>().Clone(this);
        }

        public ArgsBuilderRootCommand OnCommand(Action<T1> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsBuilderRootCommand;
        }
    }

    public class ArgsBuilderLevel1Option<T1, T2> : ArgsBuilderLevel1
    {
        public ArgsBuilderLevel1Option<T1, T2, T3> Option<T3>(string name, T3 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T3>(defaultValue), isHidden));
            return new ArgsBuilderLevel1Option<T1, T2, T3>().Clone(this);
        }
        public ArgsBuilderRootCommand OnCommand(Action<T1, T2> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsBuilderRootCommand;
        }
    }
    public class ArgsBuilderLevel1Option<T1, T2, T3> : ArgsBuilderLevel1
    {
        public ArgsBuilderRootCommand OnCommand(Action<T1, T2, T3> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsBuilderRootCommand;
        }
    }
}
