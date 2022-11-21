<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CookiesExample.aspx.cs" Inherits="SampleWebApp.CookiesExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <h1>Using Cookies to store the data</h1>
    <hr />
    <div>
        <div class="section">
            <p>
                Enter the Name:  <asp:TextBox runat="server" ID="txtName" />
            </p>
            <p>
                Enter the Email Address:
                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" />
            </p>
            <p>
                <asp:Button Text="Submit" runat="server" OnClick="Unnamed1_Click"/>
            </p>
        </div>
    </div>
</asp:Content>
