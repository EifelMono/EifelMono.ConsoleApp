using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace EifelMono.Commandline
{
    public class ArgsBuilderRoot : ArgsBuilder { }

    public class ArgsBuilderRootCommand : ArgsBuilderRoot, IArgsBuilderAlias, IArgsBuilderArgs
    {
        public ArgsBuilderRootOption<T1> Option<T1>(string name, T1 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T1>(defaultValue), isHidden));
            return new ArgsBuilderRootOption<T1>().Clone(this);
        }

        public IArgsBuilderArgs OnCommand(Action action = null)
        {
            if (action is object)
                Command.Handler = CommandHandler.Create(action);
            return this;
        }
    }

    public class ArgsBuilderRootOption<T1> : ArgsBuilderRoot, IArgsBuilderArgs
    {
        public ArgsBuilderRootOption<T1, T2> Option<T2>(string name, T2 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T2>(defaultValue), isHidden));
            return new ArgsBuilderRootOption<T1, T2>().Clone(this);
        }

        public IArgsBuilderArgs OnCommand(Action<T1> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return this;
        }
    }

    public class ArgsBuilderRootOption<T1, T2> : ArgsBuilderRoot, IArgsBuilderArgs
    {
        public ArgsBuilderRootOption<T1, T2, T3> Option<T3>(string name, T3 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T3>(defaultValue), isHidden));
            return new ArgsBuilderRootOption<T1, T2, T3>().Clone(this);
        }

        public IArgsBuilderArgs OnCommand(Action<T1, T2> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return this;
        }
    }
    public class ArgsBuilderRootOption<T1, T2, T3> : ArgsBuilderRoot, IArgsBuilderArgs
    {
        public IArgsBuilderArgs OnCommand(Action<T1, T2, T3> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return this;
        }
    }
}
