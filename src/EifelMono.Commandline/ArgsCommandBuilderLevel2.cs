﻿using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace EifelMono.CommandLine
{
    public class ArgsCommandBuilderLevel2 : ArgsCommandBuilder { }

    public class ArgsCommandBuilderLevel2Command : ArgsCommandBuilderLevel2, IArgsCommandBuilderAlias
    {
        public ArgsCommandBuilderLevel2Option<T1> Option<T1>(string name, T1 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T1>(defaultValue), isHidden));
            return new ArgsCommandBuilderLevel2Option<T1>().Clone(this);
        }
        public ArgsCommandBuilderLevel1Command OnCommand(Action action)
        {
            if (action is object)
                Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsCommandBuilderLevel1Command;
        }
    }

    public class ArgsCommandBuilderLevel2Option<T1> : ArgsCommandBuilderLevel2
    {
        public ArgsCommandBuilderLevel2Option<T1, T2> Option<T2>(string name, T2 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T2>(defaultValue), isHidden));
            return new ArgsCommandBuilderLevel2Option<T1, T2>().Clone(this);
        }

        public ArgsCommandBuilderLevel1Command OnCommand(Action<T1> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsCommandBuilderLevel1Command;
        }
    }

    public class ArgsCommandBuilderLevel2Option<T1, T2> : ArgsCommandBuilderLevel2
    {
        public ArgsCommandBuilderLevel2Option<T1, T2, T3> Option<T3>(string name, T3 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T3>(defaultValue), isHidden));
            return new ArgsCommandBuilderLevel2Option<T1, T2, T3>().Clone(this);
        }
        public ArgsCommandBuilderLevel1Command OnCommand(Action<T1, T2> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsCommandBuilderLevel1Command;
        }
    }
    public class ArgsCommandBuilderLevel2Option<T1, T2, T3> : ArgsCommandBuilderLevel2
    {
        public ArgsCommandBuilderLevel2Option<T1, T2, T3, T4> Option<T4>(string name, T4 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T4>(defaultValue), isHidden));
            return new ArgsCommandBuilderLevel2Option<T1, T2, T3, T4>().Clone(this);
        }
        public ArgsCommandBuilderLevel1Command OnCommand(Action<T1, T2, T3> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsCommandBuilderLevel1Command;
        }
    }

    public class ArgsCommandBuilderLevel2Option<T1, T2, T3, T4> : ArgsCommandBuilderLevel2
    {
        public ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5> Option<T5>(string name, T5 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T5>(defaultValue), isHidden));
            return new ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5>().Clone(this);
        }
        public ArgsCommandBuilderLevel1Command OnCommand(Action<T1, T2, T3, T4> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsCommandBuilderLevel1Command;
        }
    }

    public class ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5> : ArgsCommandBuilderLevel2
    {
        public ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5, T6> Option<T6>(string name, T6 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T6>(defaultValue), isHidden));
            return new ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5, T6>().Clone(this);
        }
        public ArgsCommandBuilderLevel1Command OnCommand(Action<T1, T2, T3, T4, T5> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsCommandBuilderLevel1Command;
        }
    }

    public class ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5, T6> : ArgsCommandBuilderLevel2
    {
        public ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5, T6, T7> Option<T7>(string name, T7 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T7>(defaultValue), isHidden));
            return new ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5, T6, T7>().Clone(this);
        }
        public ArgsCommandBuilderLevel1Command OnCommand(Action<T1, T2, T3, T4, T5, T6> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsCommandBuilderLevel1Command;
        }
    }

    public class ArgsCommandBuilderLevel2Option<T1, T2, T3, T4, T5, T6, T7> : ArgsCommandBuilderLevel2
    {
        public ArgsCommandBuilderLevel1Command OnCommand(Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            Command.Handler = CommandHandler.Create(action);
            return Parent as ArgsCommandBuilderLevel1Command;
        }
    }
}
