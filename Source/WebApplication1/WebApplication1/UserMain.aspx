<%@ Page Title="" Theme="OurTheme" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="UserMain.aspx.cs" Inherits="WebApplication1.UserHome1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <asp:GridView ID="gvPurchased" AutoGenerateColumns="false" runat="server" Width="743px" AllowPaging="True" OnPageIndexChanging="gvPurchased_PageIndexChanging">
         <Columns>
                        <asp:BoundField HeaderText="Title" DataField="Title" />
                        <asp:BoundField HeaderText="Author" DataField="Author" />
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:BoundField HeaderText="Price" DataField="Price" />
             </Columns>
    </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderAsideBar" runat="server">
    <div>
        <p>
             <asp:Label ID="Label1" runat="server" Text="Books in your Areas of interest" Font-Size="Large" ForeColor="White"></asp:Label>
        </p>
        <asp:GridView ID="gvBooksInterested" AllowPaging="true" OnPageIndexChanging="gvBooksInterested_PageIndexChanging" AutoGenerateColumns="false" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
            <Columns>
                        <asp:BoundField HeaderText="Title" DataField="Title" />
                        <asp:BoundField HeaderText="Author" DataField="Author" />
                      <%--  <asp:BoundField HeaderText="Description" DataField="Description" />--%>
                        <asp:BoundField HeaderText="Price" DataField="Price" />
             </Columns>
        </asp:GridView>
        
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
