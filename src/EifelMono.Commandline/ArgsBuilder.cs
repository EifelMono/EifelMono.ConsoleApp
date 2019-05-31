using System.CommandLine;

namespace EifelMono.Commandline
{
    public class ArgsBuilder
    {
        public string[] Args { get; set; } = null;
        public ArgsBuilder Parent { get; set; } = null;
        public Command Command { get; set; }
    }

    internal static class InternalArgsBuilderExtension
    {
        public static T Clone<T>(this T thisValue, ArgsBuilder fromValue) where T : ArgsBuilder
        {
            thisValue.Args = fromValue.Args;
            thisValue.Parent = fromValue.Parent;
            thisValue.Command = fromValue.Command;
            return thisValue;
        }
    }

    public interface IArgsBuilderAlias
    {
        Command Command { get; set; }
    }

    public interface IArgsBuilderArgs
    {
        Command Command { get; set; }
        string[] Args { get; set; }
    }
}
