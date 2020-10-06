using System;

namespace Asp.Net.Mvc.Check.Infrastructure
{
    public class TestService : ITestService
    {
        public void GetTest()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            var a = 1;
        }
    }
}