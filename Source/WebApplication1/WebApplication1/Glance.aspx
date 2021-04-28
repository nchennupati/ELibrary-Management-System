<%@ Page Title="" Language="C#" Theme="OurTheme" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Glance.aspx.cs" Inherits="WebApplication1.Glance1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .hiddencol
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <p> 
        <asp:CheckBoxList ID="chklasideBar" runat="server">
        </asp:CheckBoxList>
    </p>
    <p>
        <asp:Button ID="btnFilter" Text="Filter" runat="server" OnClick="btnFilter_Click" />
    </p>
    <p>
        <asp:GridView ID="gvGlance" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvGlance_RowDataBound" OnRowCommand="gvGlance_RowCommand">
        <Columns>
             <asp:BoundField HeaderText="Title" DataField="Title" />
             <asp:BoundField HeaderText="Author" DataField="Author" />
             <asp:BoundField HeaderText="Description" DataField="Description" />
             <asp:BoundField HeaderText="Price" DataField="Price" />
             <asp:BoundField HeaderText="Type" DataField="Type" />
             <asp:TemplateField>
             <ItemTemplate>
                 <asp:Label ID="lblBuy" runat="server" Text="Login To Buy"></asp:Label>
                 <asp:Button ID="btnDownload" runat="server" Text="Download" CommandName="Download"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
             </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField HeaderText="Path" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="Path" />
            <asp:BoundField HeaderText="DocumentID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" DataField="DocumentID" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
