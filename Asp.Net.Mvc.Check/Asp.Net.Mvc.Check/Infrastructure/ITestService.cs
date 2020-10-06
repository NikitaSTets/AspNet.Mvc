using System;

namespace Asp.Net.Mvc.Check.Infrastructure
{
    public interface ITestService : IDisposable
    {
        void GetTest();
    }
}