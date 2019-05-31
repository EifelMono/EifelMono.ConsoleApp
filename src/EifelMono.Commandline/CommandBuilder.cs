using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace EifelMono.Commandline
{
    public class CommandBuilder
    {
        public string[] Args { get; set; } = null;
        public CommandBuilder Parent { get; set; } = null;
        public Command Command { get; set; }
    }

    internal static class InternalCommandBuilderExtension
    {
        public static T Clone<T>(this T thisValue, CommandBuilder fromValue) where T : CommandBuilder
        {
            thisValue.Args = fromValue.Args;
            thisValue.Parent = fromValue.Parent;
            thisValue.Command = fromValue.Command;
            return thisValue;
        }
    }

    public interface ICommandBuilderAlias
    {
        Command Command { get; set; }
    }
}
