using System;
using System.Web;
/*
* Cookies are text based info stored in the client machines with his/her permissions.
* Cookies are represented as objects of a class called HttpCookie.
* Cookies are added to the Response object to store the cookies in the client machines. 
* We use Request object to extract the cookies stored from the client machine.
* Cookies store the data as Text(String) only. Clients can refuse the permission to allow cookies. Clients can delete the cookie any time. The default time of cookie storage is for 2 years. 
*/
namespace SampleWebApp
{
    public partial class CookiesExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("EmpInfo");
            cookie.Values.Add("name", txtName.Text);
            cookie.Values.Add("email", txtEmail.Text);
            Response.Cookies.Add(cookie);
            Response.Redirect("RecipiantPage.aspx");

        }
    }
}