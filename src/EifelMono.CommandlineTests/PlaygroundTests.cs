using System;
using EifelMono.CommandlineTests.XunitTests;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.CommandlineTests
{
    public class PlayGroundTests : XunitCore
    {

        public PlayGroundTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void PlayGround1()
        {
        }
    }
}
