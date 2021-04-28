<%@ Page Title="" Theme="OurTheme" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebApplication1.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .auto-style3 {
            width: 100%;
            margin-right: 41px;
        }
        .auto-style4 {
            width: 144px;
        }
        
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
                <asp:GridView ID="gvSearch" AutoGenerateColumns="false" runat="server" OnRowCommand="gvSearch_RowCommand" OnRowDataBound="gvSearch_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Title" DataField="Title" />
                        <asp:BoundField HeaderText="Author" DataField="Author" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Price" DataField="Price" />
                         <asp:BoundField HeaderText="Type" DataField="Type" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblBuy" runat="server" Text="Login to Buy"></asp:Label>
                                <asp:Button ID="btnDownload" runat="server" Text="Download" CommandName="Download"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Path" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Path" />
                    </Columns>
                </asp:GridView>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
