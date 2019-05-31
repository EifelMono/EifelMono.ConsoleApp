using System;
using System.IO;
using System.Text;
using EifelMono.Fluent.Extensions;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using System.CommandLine.Rendering;
using System.CommandLine;

namespace EifelMono.CommandlineTests
{
    public class XunitCore
    {
        protected readonly ITestOutputHelper Output;

        public IConsole TestTerminal = new TestTerminal();

        public XunitCore(ITestOutputHelper output)
        {
            Output = output;
        }

        public void DumpTestTerminal()
        {
            WriteLine(TestTerminal.Out);
        }

        public void WriteLine(string text = "") => Output.WriteLine(text);

        public void WriteLine(Exception ex) => Output.WriteLine(ex.ToString());

        public void WriteLine(object @object) => Output.WriteLine(@object?.ToString() ?? "");

        public void Line(int count = 80) => Output.WriteLine("-".Repeat(count));

        public void DoubleLine(int count = 80) => Output.WriteLine("=".Repeat(count));

        public void Dump(object dump, string title = default)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Line();
                WriteLine(title);
            }
            WriteLine(JsonConvert.SerializeObject(dump, Formatting.Indented));
        }

        public void TryCatch(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                Output.WriteLine(ex.ToString());
                throw new Xunit.Sdk.XunitException(ex.ToString());
            }
        }

        public static void AssertFail(string message = "")
           => throw new Xunit.Sdk.XunitException(message);

        public static void AssertSomethingWentWrong()
           => AssertFail("Something went wrong 😢");

        public static void AssertOk()
           => Assert.True(true);
    }
}

