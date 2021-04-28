<%@ Page Title="" Language="C#" Theme="OurTheme" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<center>
                    <table style="color:white">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblLogin" runat="server" Font-Bold="True" Font-Size="Larger" Text="LogIn"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblUserID" runat="server" Text="User ID"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserID" runat="server" ForeColor="Black"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserID" ErrorMessage="Please enter UserID"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" TextMode="Password"  ForeColor="Black" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter Password"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                               <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click"   />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HyperLink ID="hypRegister" Text="Click here to Register" NavigateUrl="~/Register.aspx" runat="server"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                    </center>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
