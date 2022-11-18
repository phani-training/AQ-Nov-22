using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class User_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //Take the input values
            var name = txtName.Text;
            var address = txtAddress.Text;
            var salary = txtSalary.Text;
            var dateOfBirth = DateTime.Parse(txtDate.Text);
            //Display them in a label
            var content = $"The Name entered: {name}<br/>The Address: {address}<br/>The Salary: {salary}<br/>The Date of Birth: {dateOfBirth.ToLongDateString()}<br/>";
            lblDisplay.Text = content;
        }
    }
}
/*
 * Create a Web Page that takes 2 inputs from the user for a calculator App. There will be 4 buttons for Adding, subtracting, multiplying and Division. The result should be displayed on a Label,
 */