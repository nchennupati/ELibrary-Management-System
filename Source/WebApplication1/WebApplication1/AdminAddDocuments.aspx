<%@ Page Title="" Language="C#" Theme="OurTheme" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminAddDocuments.aspx.cs" Inherits="WebApplication1.AdminAddDocuments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .auto-style3 {
        width: 100%;
    }
    .auto-style4 {
        width: 119px;
    }
    .auto-style5 {
        width: 174px;
    }
    .auto-style6 {
        width: 162px;
    }
    .auto-style7 {
        width: 119px;
        height: 23px;
    }
    .auto-style8 {
        width: 174px;
        height: 23px;
    }
    .auto-style9 {
        width: 162px;
        height: 23px;
    }
        .auto-style10 {
            width: 119px;
            height: 30px;
        }
        .auto-style11 {
            width: 174px;
            height: 30px;
        }
        .auto-style12 {
            width: 162px;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<table class="auto-style3" style="color:white">
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">
            <asp:Label ID="lblEnterDocDetails" runat="server" Font-Size="Larger" Text="Enter Document Details"></asp:Label>
        </td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="lblDocumentName" runat="server" Text="DocumentName"></asp:Label>
        </td>
        <td class="auto-style5">
            <asp:TextBox ID="txtDocumentName" runat="server" Width="148px"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDocumentName" ErrorMessage="Please enter a document Name"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        </td>
        <td class="auto-style5">
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please enter document description"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style7"></td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style9"></td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="lblPath" runat="server" Text="Path"></asp:Label>
        </td>
        <td class="auto-style5">
            <asp:FileUpload ID="FileUpload1" runat="server"  />
        </td>
        <td class="auto-style6">
           
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="lblDocumenttype" runat="server" Text="Document Type"></asp:Label>
        </td>
        <td class="auto-style5">
            <asp:DropDownList ID="cboDocumentType" runat="server">
            </asp:DropDownList>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboDocumentType" ErrorMessage="Please select document type"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="lblDiscipline" runat="server" Text="Discipline"></asp:Label>
        </td>
        <td class="auto-style5">
            <asp:DropDownList ID="cboDiscipline" runat="server">
            </asp:DropDownList>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cboDiscipline" ErrorMessage="Please select Discipline"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
        </td>
        <td class="auto-style5">
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" ErrorMessage="Please enter title"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style7"></td>
        <td class="auto-style8"></td>
        <td class="auto-style9"></td>
    </tr>
    <tr>
        <td class="auto-style7">
            <asp:Label ID="lblAuthor" runat="server" Text="Author"></asp:Label>
        </td>
        <td class="auto-style8">
            <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style9">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAuthor" ErrorMessage="Please enter an author name"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style7">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7">
            <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        </td>
        <td class="auto-style8">
            <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox>
        </td>
        <td class="auto-style9">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrice" ErrorMessage="Please enter price"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Enter Price more than zero" Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7"></td>
        <td class="auto-style8"></td>
        <td class="auto-style9"></td>
    </tr>
    <tr>
        <td class="auto-style10">
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
        </td>
        <td class="auto-style11">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        </td>
        <td class="auto-style12">
            <asp:Label ID="lblDisplay" runat="server" Text="Label Display"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
