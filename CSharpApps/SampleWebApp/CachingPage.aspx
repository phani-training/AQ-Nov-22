<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CachingPage.aspx.cs" Inherits="SampleWebApp.CachingPage" %>
<%@ Register TagPrefix="custom" TagName="Time" Src="~/FragmentPage.ascx" %>
<%--<%@ OutputCache Duration="60" VaryByParam="City" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <h2>Web Page caching</h2>
        <div>
            Select the City to see its Time:
            <asp:DropDownList runat="server" ID="dpList" Height="30px" Width="200px">
                <asp:ListItem Text="New York" />
                <asp:ListItem Text="London" />
                <asp:ListItem Text="New Delhi" />
                <asp:ListItem Text="Moscow" />
                <asp:ListItem Text="Sidney" />
            </asp:DropDownList>
            <asp:Button Text="Get Time" ID="btnTime" runat="server" OnClick="btnTime_Click" />
        </div>
        <div>
            The Time is: <asp:Label Text="" ID="lblTime" runat="server"/>
        </div>
    </div>
    <div>
        <custom:Time runat="server" />
    </div>
</asp:Content>
