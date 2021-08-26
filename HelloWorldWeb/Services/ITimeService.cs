namespace HelloWorldWeb.services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ITimeService
    {
        DateTime Now();
    }
}