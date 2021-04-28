<%@ Page Title="" Theme="OurTheme" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="UserGlance.aspx.cs" Inherits="WebApplication1.Glance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="gvGlance" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvGlance_RowDataBound" OnRowCommand="gvGlance_RowCommand">
        <Columns>
             <asp:BoundField HeaderText="Title" DataField="Title" />
             <asp:BoundField HeaderText="Author" DataField="Author" />
             <asp:BoundField HeaderText="Description" DataField="Description" />
             <asp:BoundField HeaderText="Price" DataField="Price" />
             <asp:BoundField HeaderText="Type" DataField="Type" />
             <asp:TemplateField>
             <ItemTemplate>
                 <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" CommandName="AddToCart"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                  <asp:Button ID="btnDownload" runat="server" Text="Download" CommandName="Download"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
             </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField HeaderText="Path" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Path" />
            <asp:BoundField HeaderText="DocumentID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="DocumentID" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnBuy" runat="server" Text="Buy" Visible="false" OnClick="btnBuy_Click" />
    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderAsideBar" runat="server">
    <p> 
        <asp:CheckBoxList ID="chklasideBar" runat="server">
        </asp:CheckBoxList>
    </p>
    <p>
        <asp:Button ID="btnFilter" Text="Filter" runat="server" OnClick="btnFilter_Click" />
    </p>
    <asp:Label ID="Label1" runat="server" Text="Your Cart" Font-Size="Medium" ForeColor="White"></asp:Label>
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