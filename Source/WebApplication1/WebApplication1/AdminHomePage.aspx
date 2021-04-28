<%@ Page Title="" Language="C#" Theme="OurTheme" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="WebApplication1.AdminHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblWelcome" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
                <p>
                <asp:Label ID="lblReg" runat="server" Text="Label" Font-Size="Medium"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblSub" runat="server" Text="Label" Font-Size="Medium"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblSold" runat="server" Text="Label" Font-Size="Medium"></asp:Label>
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
