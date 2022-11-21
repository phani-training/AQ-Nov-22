<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StateManagement.aspx.cs" Inherits="SampleWebApp.StateManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div class="section">
    <asp:Repeater ID="productDB" runat="server" OnItemCommand="productDB_ItemCommand">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th>ProductID</th>
                    <th>ProductName</th>
                    <th>ProductPrice</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr style="background-color:gray; color:white">
                <td><%#Eval("ProductId") %></td>
                <td><%#Eval("ProductName") %></td>
                <td><%#Eval("Price") %></td>
                <td>
                    <asp:Button Text="View" CommandName="OnView" CommandArgument="<%#((SampleWebApp.Models.Product)Container.DataItem).ProductId%>" runat="server" />
                    <asp:Button Text="Add To Cart" CommandName="OnAdd" CommandArgument="<%#((SampleWebApp.Models.Product)Container.DataItem).ProductId%>" runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
             <tr style="background-color:lightgray">
                <td><%#Eval("ProductId") %></td>
                <td><%#Eval("ProductName") %></td>
                <td><%#Eval("Price") %></td>
                <td>
                    <asp:Button Text="View" CommandName="OnView" CommandArgument="<%#((SampleWebApp.Models.Product)Container.DataItem).ProductId%>" runat="server" />
                    <asp:Button Text="Add To Cart" CommandName="OnAdd" CommandArgument="<%#((SampleWebApp.Models.Product)Container.DataItem).ProductId%>" runat="server" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>
    <div class="section">
        <h2>Details of the Product</h2>
        <asp:FormView ID="FormView1" runat="server">
            <ItemTemplate>
                <h2>Details of the Product <%#Eval("ProductName")%></h2>
                <hr />
                <p>Product ID: <span><%#Eval("ProductId")%></span></p>
                <p>Product Name: <span><%#Eval("ProductName")%></span></p>
                <p>Product Price: <span><%#Eval("Price")%></span></p>
                <p>Product Quantity: <span><%#Eval("Quantity")%></span></p>
            </ItemTemplate>
        </asp:FormView>
    </div>
    <div>
        <asp:DataList ID="lstRecent" runat="server" RepeatColumns="5">
           
            <ItemTemplate>
                
                <div style="border:2px solid blue; border-radius:10px">
                    <h3><%#Eval("ProductName")%></h3>
                </div>
                    
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>
</asp:Content>
