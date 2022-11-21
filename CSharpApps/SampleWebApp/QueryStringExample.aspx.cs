using System;
/*
 * Querystring is a key-value pairs of text based info that can be transfered using the URL of the page. 
 * Most of the Web Apps use query string to share the data among the pages.
 * Each key-value pair will be seperated by an &. 
 * Querystring data is available in the URL of the Recipiant Page which could be seen and edited there by compromising on the Security of the content. The content of the Url should not be more than 255 charecters for certain browsers. The data that can be put in the URL can be only of the type string. 
 */

namespace SampleWebApp
{
    using SampleLibrary.Data;
    using SampleLibrary.Entities;
    public partial class QueryStringExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get the Data Access Component 
                var component = EmployeeFactory.GetComponent();
                //Call the API and get the data
                var data = component.GetEmployees();
                //Populate the data to the listbox. 
                lstNames.DataSource = data;
                lstNames.DataTextField = "EmpName";
                lstNames.DataValueField = "EmpId";
                lstNames.DataBind();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var url = $"RecipiantPage.aspx?name={txtName.Text}&email={txtEmail.Text}";
            Response.Redirect(url);
        }

        protected void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var url = $"RecipiantPage.aspx?EmpId={lstNames.SelectedValue}";
            Response.Redirect(url);
        }
    }
}