<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart_Subscriber.aspx.cs" Inherits="WebApplication1.ShoppingCart_Subscriber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <style type="text/css">
        body
        {
            margin: 0;
	        padding: 0;
	        background: #73252F url(images/main-background-bg.png) repeat;
	        font-family: 'Abel', sans-serif;
	        font-size: 14px;
	        color: #383838;
            color:white;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 30px;
        }
    .auto-style3 {
            height: 30px;
            width: 211px;
        }
    .auto-style4 {
            width: 211px;
        }
        .auto-style6 {
            width: 692px;
        }
        .auto-style7 {
            height: 30px;
            width: 462px;
        }
        .auto-style8 {
            width: 462px;
        }
        .hiddencol
        {
            display: none;
        }
        #gvShoppingCart
        {
            color:white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="        ">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style7">
                    <asp:Label ID="lblShpcartsubscriber" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="white" Text="Shopping cart for Subscriber"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="lblDisplay" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="lblBookschoosen" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="white" Text="Books Choosen"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    <asp:GridView ID="gvShoppingCart" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvShoppingCart_RowDataBound" OnRowCommand="gvShoppingCart_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Title" DataField="Title" />
                            <asp:BoundField HeaderText="Author" DataField="Author" />
                            <asp:BoundField HeaderText="Description" DataField="Description" />
                            <asp:BoundField HeaderText="Price" DataField="Price" />
                            <asp:BoundField HeaderText="Type" DataField="Type" />
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                                
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Path" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Path" />
                            <asp:BoundField HeaderText="DocumentID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="DocumentID" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style8"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblTotalAmount" runat="server" ForeColor="white" Text="Total Amount"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:Label ID="lblTotalAmountDisplay" runat="server" Text="Label" ForeColor="White"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" ForeColor="white" Text="Discount Avail:"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:Label ID="lblDiscountAvail" runat="server" Text="Label" ForeColor="White"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Button ID="btnpay" runat="server" BackColor="white" Text="Pay" OnClick="btnpay_Click1" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    
    </div>
    </form>
</body>
</html>
