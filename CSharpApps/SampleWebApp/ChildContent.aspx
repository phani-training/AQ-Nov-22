<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChildContent.aspx.cs" Inherits="SampleWebApp.ChildContent" %>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">   
    <h2>Sample Example of a Child Page</h2>
    <hr />
    <div>
        <h3>Child Pages are placed with content under the control called asp:Content</h3>
        <p>
            <ul>
                <li>Child Pages will have the Page Directive with an attribute called MasterPageFile</li>
                <li>Child Pages cannot have form tag, or any other HTML, ASP.NET Tags</li>
                <li>It can have only Content Tag in it</li>
                <li>Master pages are pages with extension .master</li>
                <li>Master pages cannot be navigated in the URL</li>
                <li>Child pages associated with the Master will have Content element with ContentPlaceHolderId</li>
            </ul>
        </p>
    </div>
</asp:Content>