using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using aimooc.Data;

namespace aimooc.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private AIMoocDataContext dataContext;
        public IConfiguration Configuration { get; set; }
        public AIMoocDataContext Get()
        {
            
			  //var builder = new ConfigurationBuilder().AddJsonFile("config.json");
			  //Configuration = builder.Build();
            //IConfiguration configuration = new Configuration().AddJsonFile("config.json");
            return dataContext ?? (dataContext = new AIMoocDataContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
