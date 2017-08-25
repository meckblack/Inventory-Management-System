using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace IMS.Data.DbConnections.DAL
{
    class MyInitializer : CreateDatabaseIfNotExists<IMS_DB>
    {
        public MyInitializer()
        {

        }
        protected override void Seed(IMS_DB context)
        {

        }
    }


}
