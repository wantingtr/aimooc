using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace aimooc.Data
{
    public interface IDatabaseFactory : IDisposable
    {
        AIMoocDataContext Get();
    }
}
