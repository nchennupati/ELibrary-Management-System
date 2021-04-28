<%@ Page Title=""  Theme="OurTheme" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="UserSearch.aspx.cs" Inherits="WebApplication1.UserSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table class="auto-style3">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                <asp:Label ID="lblSearchYourDoc" runat="server" Font-Bold="True" Font-Size="Larger" Text="Search Your Documents here"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="212px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblDiscipline" runat="server" Text="Discipline"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboDiscipline" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblSearchby" runat="server" Text="Search By"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboSearchBy" runat="server">
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Discipline</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cboSearchBy" ErrorMessage="Please select search by option"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvSearch_RowDataBound" OnRowCommand="gvSearch_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Title" DataField="Title" />
                        <asp:BoundField HeaderText="Author" DataField="Author" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Price" DataField="Price" />
                        <asp:BoundField HeaderText="Type" DataField="Type" />
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDownload" runat="server" Text="Download" CommandName="Download"  CommandArgument="<%# Container.DataItemIndex %>" />
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" CommandName="AddToCart" CommandArgument="<%# Container.DataItemIndex %>" />  
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Path" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Path" />
                        <asp:BoundField HeaderText="DocumentID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="DocumentID" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnBuy" runat="server" Text="Buy" Visible="true" OnClick="btnBuy_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                <asp:Label ID="lblDisplay" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderAsideBar" runat="server">
    <asp:GridView ID="gvShoppingCart" runat="server" AutoGenerateColumns="false"  OnRowCommand="gvShoppingCart_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Title" DataField="Title" />
                            <asp:BoundField HeaderText="Author" DataField="Author" />
                          
                            <asp:BoundField HeaderText="Price" DataField="Price" />
                           
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove"  CommandArgument="<%# Container.DataItemIndex %>"  />
                                
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField HeaderText="DocumentID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="DocumentID" />
       
                           </Columns>
                    </asp:GridView>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
