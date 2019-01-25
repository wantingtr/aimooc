using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace aimooc.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private AIMoocDataContext dataContext;

        public UnitOfWork(AIMoocDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Commit()
        {
            this.dataContext.Commit();
        }
    }
    
}
   