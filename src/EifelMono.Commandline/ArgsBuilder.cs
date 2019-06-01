using System.Collections.Generic;
using System.CommandLine;

namespace EifelMono.Commandline
{
    public class ArgsBuilder
    {
        public string[] Args { get; set; } = null;
        public ArgsBuilder Parent { get; set; } = null;
        public Command Command { get; set; }

        public List<string> Lines { get; set; } = new List<string>();
        public IConsole Console { get; set; } = null;
    }

    internal static class InternalArgsBuilderExtension
    {
        internal static T Clone<T>(this T thisValue, ArgsBuilder fromValue) where T : ArgsBuilder
        {
            thisValue.Args = fromValue.Args;
            thisValue.Parent = fromValue.Parent;
            thisValue.Command = fromValue.Command;
            thisValue.Lines = fromValue.Lines;
            thisValue.Console = fromValue.Console;
            return thisValue;
        }
    }

    public interface IArgsBuilderAlias
    {
        Command Command { get; set; }
    }

    public interface IArgsBuilderArgs
    {
        string[] Args { get; set; }
        Command Command { get; set; }
        List<string> Lines { get; set; }
        IConsole Console { get; set; }
    }
}
