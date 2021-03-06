<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart_NonSubscriber.aspx.cs" Inherits="WebApplication1.ShoppingCart_NonSubscriber" %>

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
    <div>
             <table class="auto-style1">
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Label ID="lblShpcartNonsubscriber" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="white" Text="Shopping cart for Non Subscriber"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblBookschoosen" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="white" Text="Books Choosen"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                   <asp:GridView ID="gvShoppingCart" runat="server" AutoGenerateColumns="false"  OnRowCommand="gvShoppingCart_RowCommand">
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotalAmount" runat="server" ForeColor="white" Text="Total Amount"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotalAmountDisplay" runat="server" Text="Label" ForeColor="White"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Yellow" Text="20% off for Subscriber!! Just Rs 1000"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkSubscriber" runat="server" Text="Subscriber" ForeColor="White" AutoPostBack="True" OnCheckedChanged="chkSubscriber_CheckedChanged" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" ForeColor="white" Text="Discount Avail:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDiscountAvail" runat="server" Text="Label" ForeColor="White"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
               <td colspan="3">
                   <asp:Label ID="lblSubscriptionAmount" ForeColor="White" Font-Size="Medium" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnpay" runat="server" BackColor="white" Text="Pay" OnClick="btnpay_Click" />
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
