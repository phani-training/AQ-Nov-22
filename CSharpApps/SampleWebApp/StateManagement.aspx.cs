using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * All Client side State Management techniques are unique to the user of the Application. 
 * Client Side stores only Text based Data other than ViewState.
 * Server side allows data of any kind to be stored in the server. 
 * Session, Application are the 2 major server side State Management Systems. 
 * Session is a unique interaction b/w a browser instance and the server. The session is lost of the user closes the browser or the browser is idle for more than a certain period of time. 
 * Application is something that is available across all the users of the Application. It has the global scope and is available to all the users. 
 */

namespace SampleWebApp
{
    public partial class StateManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = Application["AllData"] as List<Product>;
                productDB.DataSource = data;
                productDB.DataBind();
            }
            //FormView1.DataSource = new Product();
        }

        protected void productDB_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var id = Convert.ToInt32(e.CommandArgument);
            if(e.CommandName == "OnView")
            {
                //Get the Selected Product.
                var allData = Application["AllData"] as List<Product>;
                var selectedProduct = allData.Find((p) => p.ProductId == id);
                FormView1.DataSource = new List<Product> { selectedProduct };//DataSource needs a Collection, So make it as a collection and set it. 
                FormView1.DataBind();

                //Get the Session data of Recent list.
                var recent = Session["recent"] as Queue<Product>;
                if(recent == null)
                {
                    Session["recent"] = new Queue<Product>();
                    recent = Session["recent"] as Queue<Product>;
                }
                if(recent.Count == 5)
                {
                    recent.Dequeue();
                }
                recent.Enqueue(selectedProduct);
                var reverseRecords = recent.Reverse();
                lstRecent.DataSource = reverseRecords;
                lstRecent.DataBind();

            }else if(e.CommandName == "OnAdd")
            {
                Response.Write(id +" to be added to cart");
            }
        }
    }
}