using System.CommandLine;

namespace EifelMono.Commandline
{
    public class CommandBuilderRoot : CommandBuilder { }

    public class CommandBuilderRootCommand : CommandBuilderRoot, ICommandBuilderAlias
    {
        public CommandBuilderRootOption<T1> Option<T1>(string name, T1 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T1>(defaultValue), isHidden));
            return new CommandBuilderRootOption<T1>().Clone(this);
        }
    }

    public class CommandBuilderRootOption<T1> : CommandBuilderRoot
    {
        public CommandBuilderRootOption<T1, T2> Option<T2>(string name, T2 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T2>(defaultValue), isHidden));
            return new CommandBuilderRootOption<T1, T2>().Clone(this);
        }
    }

    public class CommandBuilderRootOption<T1, T2> : CommandBuilderRoot
    {
        public CommandBuilderRootOption<T1, T2, T3> Option<T3>(string name, T3 defaultValue = default, string description = null, bool isHidden = false)
        {
            Command.AddOption(new Option(name, description, new Argument<T3>(defaultValue), isHidden));
            return new CommandBuilderRootOption<T1, T2, T3>().Clone(this);
        }
    }
    public class CommandBuilderRootOption<T1, T2, T3> : CommandBuilderRoot
    {
    }
}
