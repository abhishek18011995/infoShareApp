using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InfoShareApp.API.Data.Models
{
    public interface IInfoShareDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ProductCollection { get; set; }
        //ICollections Collections { get; set; }
    }

    //public interface ICollections
    //{
    //    string Product { get; set; }
    //}
}
