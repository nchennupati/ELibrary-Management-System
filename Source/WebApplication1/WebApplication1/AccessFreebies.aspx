<%@ Page Title="" Language="C#" Theme="OurTheme" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="AccessFreebies.aspx.cs" Inherits="WebApplication1.AccessFreebies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="gvFreebies" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvFreebies_RowDataBound" OnRowCommand="gvFreebies_RowCommand" >
        <Columns>
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="Author" HeaderText="Author" />
        <asp:BoundField DataField="Description" HeaderText="Description" />
        <asp:TemplateField HeaderText="Download">
            <ItemTemplate>
                <asp:button ID="btnDownload" runat="server" Text="Download" CommandName="Download" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:button>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Path" HeaderText="Path" Visible="true" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
        
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
