using System;
using System.Collections.Generic;
using System.Text;

namespace InfoShareApp.API.Data.Models
{
    public class InfoShareDatabaseSettings : IInfoShareDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string ProductCollection { get; set; }

        public string ContactUsCollection { get; set; }

        //public ICollections Collections { get; set; }
    }
}
