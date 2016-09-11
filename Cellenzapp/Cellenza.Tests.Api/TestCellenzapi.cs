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
        public void TestGetExpert()
        {
            Cellenzapi service = new Cellenzapi();
            var result = service.GetExperts();
            result = result;
        }


        [Test()]
        public void TestUpdateAbout()
        {
            Cellenzapi service = new Cellenzapi();
            var result = service.GetExperts();
            result = result;
        }


        [Test()]
        public void TestAddExpert()
        {
            Cellenzapi service = new Cellenzapi();
            var result = service.GetExperts();
            result = result;
        }
    }
}

