<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QueryStringExample.aspx.cs" Inherits="SampleWebApp.QueryStringExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <style>
            .section{
                display:inline-block; 
                width:45%
            }
        </style>
        <h2>State Management using QueryString</h2>
        <hr />
        <div class="section">
            <p>
                <asp:TextBox runat="server" ID="txtName" />
            </p>
            <p>
                Enter the Email Address:
                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" />
            </p>
            <p>
                <asp:Button Text="Submit" runat="server" OnClick="Unnamed1_Click" />
            </p>
        </div>
        <div class="section">
            <h2>List of Employees with us!!!</h2>
            <hr />
            <asp:ListBox runat="server" ID="lstNames" Height="339px" Width="225px" AutoPostBack="True" OnSelectedIndexChanged="lstNames_SelectedIndexChanged">
 
            </asp:ListBox>
        </div>
    </div>
</asp:Content>
