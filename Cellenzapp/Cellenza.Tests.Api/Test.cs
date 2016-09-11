using NUnit.Framework;
using System;
using Cellenzapp.Core;
using System.Threading.Tasks;

namespace Cellenzapp.Tests.Api
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            Cellenzapi service = new Cellenzapi();
            var result = service.GetExperts();
            result = result;
        }
    }
}

