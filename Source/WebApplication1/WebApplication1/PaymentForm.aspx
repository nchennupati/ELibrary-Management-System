<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentForm.aspx.cs" Inherits="WebApplication1.PaymentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            margin: 0;
	        padding: 0;
	        background: #73252F url(images/main-background-bg.png) repeat;
	        font-family: 'Abel', sans-serif;
	        font-size: 14px;
	        color: #383838;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 30px;
        }
    .auto-style3 {
        height: 30px;
        width: 25%;
    }
    .auto-style4 {
        width: 25%;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="auto-style1" style="color:white">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="lblpayment"  runat="server" Text="Payment Details" Font-Bold="True" Font-Size="Larger"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblUserId" runat="server" Text="UserID"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="lbluID" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblamount" align="centre" runat="server" Text="Amount"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="lblshowamt" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lblcvv" runat="server" Text="CVV"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcvv" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Cannot Be Empty" ControlToValidate="txtcvv"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Credit Card Number"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtcreditcard" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lblexpmnth" runat="server" Text="Expiry Month"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlexpmonth" runat="server">
                        <asp:ListItem Value="1">Jan</asp:ListItem>
                        <asp:ListItem Value="2">Feb</asp:ListItem>
                        <asp:ListItem Value="3">Mar</asp:ListItem>
                        <asp:ListItem Value="4">Apr</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">Jun</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">Aug</asp:ListItem>
                        <asp:ListItem Value="9">Sept</asp:ListItem>
                        <asp:ListItem Value="10">Oct</asp:ListItem>
                        <asp:ListItem Value="11">Nov</asp:ListItem>
                        <asp:ListItem Value="12">Dec</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcreditcard" ErrorMessage="Cannot Be Empty"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlexpmonth" ErrorMessage="Cannot Be Empty"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Card Holder Name"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lblexpyear" runat="server" Text="Expiry Year"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtexpyear" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtname" ErrorMessage="Cannot Be Empty"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtexpyear" ErrorMessage="Cannot Be Empty"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btnpay" runat="server" Text="Pay" OnClick="btnpay_Click" />
                </td>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UserMain.aspx">Home</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
