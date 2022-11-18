<%@ Page Language="C#" MasterPageFile="~/Site.Master" Trace="true" AutoEventWireup="true" CodeBehind="User Registration.aspx.cs" Inherits="SampleWebApp.User_Registration" %>
<asp:Content ID="content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
            <h1>User Registration Page</h1>
            <hr />
            <div>
                <table border="1">
                    <tr>
                        <td>Enter the Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="500px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ErrorMessage="Name is mandatory" ControlToValidate="txtName" runat="server" ForeColor="IndianRed" />
                        </td>
                    </tr>
                    <tr>
                        <td>Enter the Email Address:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" Width="500px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator  ErrorMessage="Email is not in a proper format" ControlToValidate="txtAddress" runat="server" ForeColor="IndianRed" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                        </td>
                    </tr>
                    <tr>
                        <td>Enter the Salary:
                        </td>
                        <td>
                            <asp:TextBox ID="txtSalary" runat="server" Width="500px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RangeValidator ErrorMessage="Salary should be within the Range of 30000 to 100000" ControlToValidate="txtSalary" MinimumValue="30000" MaximumValue="100000" Type="Integer" ForeColor="IndianRed" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Enter the password:</td>
                        <td>
                            <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ErrorMessage="Password is Must" ControlToValidate="txtPassword" ForeColor="IndianRed" runat="server" />
                            <asp:RegularExpressionValidator ErrorMessage="Password should contain atleast 9 charecters with 1 Sp charector and 1 Uppercase" ControlToValidate="txtPassword" runat="server" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{9,}$" ForeColor="IndianRed" />
                        </td>
                    </tr>
                    <tr>
                        <td>ReEnter the password:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtRetype" />
                        </td>
                        <td>
                            <asp:CompareValidator ErrorMessage="Password Mismatch" ControlToValidate="txtRetype" ControlToCompare="txtPassword" Type="String" ForeColor="IndianRed" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Enter the Date of Birth:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" TextMode="Date" runat="server" Width="500px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                </table>
                <asp:Button Text="Register" runat="server" OnClick="Unnamed1_Click" />
            </div>
        </div>
        <asp:Label ID="lblDisplay" runat="server" BackColor="#6699FF" BorderStyle="Dotted" ForeColor="#FFFFCC" Height="275px" Width="744px"></asp:Label>

</asp:Content>