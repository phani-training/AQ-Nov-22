using SampleLibrary.Data;
using SampleLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * Data Cache is an object of the HttpCache type that can be used to cache data of the App. 
 * It has properties to set the time of cache, extend the cache and dependency of the cache. 
 */
namespace SampleWebApp
{
    public partial class DataCaching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var com = EmployeeFactory.GetComponent();//Get the data from the DLL....
                var data = com.GetEmployees();
                var fileName = @"C:\Trainings\AQ-Dotnet\CSharpApps\SampleWebApp\DependencyFile.txt";
                if (Cache["AllData"] == null)//Check if its already exists...
                {
                    Cache.Add("AllData",//Key for the cache 
                        data,//what U want to cache 
                        new CacheDependency(fileName),//Additional Dependecies
                        Cache.NoAbsoluteExpiration,//Duration of the cache 
                        Cache.NoSlidingExpiration,//If U want to extend the cache
                        CacheItemPriority.Normal,//Default priority 
                        null);//CallBack for the change request.
                }
                grdTable.DataSource = Cache["AllData"] as List<Employee>;
                grdTable.DataBind();
            }
        }
    }
}