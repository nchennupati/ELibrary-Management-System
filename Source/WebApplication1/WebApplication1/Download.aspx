<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="WebApplication1.Download" %>

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
        }
        .auto-style3 {
        width: 100%;
    }
         #gvDownload
        {
            color:white;
        }
          .hiddencol
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="auto-style3">
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblDownloadDocument" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#3366FF" Text="Download Your Document"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:GridView ID="gvDownload" runat="server" OnRowCommand="gvDownload_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Title" DataField="Title" />
                    <asp:BoundField HeaderText="Author" DataField="Author" />
                    <asp:BoundField HeaderText="Description" DataField="Description" />
                    <asp:BoundField HeaderText="Price" DataField="Price" />
                    <asp:TemplateField>
                        <ItemTemplate>
                           <asp:Button ID="btnDownload" runat="server" Text="Download" CommandName="Download"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField HeaderText="Path" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Path" />
                            <asp:BoundField HeaderText="DocumentID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="DocumentID" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnHome" runat="server" Text="Go to home" OnClick="btnHome_Click" />
        </td>
    </tr>
</table>
    </div>
    </form>
</body>
</html>
