<%@ Page Title="" Language="C#" Theme="OurTheme" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="WebApplication1.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 256px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
     <table class="auto-style4">
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblwelcome" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style7">
                    &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">Password</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpwd" Display="Dynamic" ErrorMessage="Mandatory *" ForeColor="#FF3300"></asp:RequiredFieldValidator>
&nbsp;
            </td>
            <td class="auto-style7">
                    <asp:Label ID="lblLandlinenumber" runat="server" Text="Landline Number"></asp:Label>
            
                </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtlandnum" runat="server"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtlandnum" ErrorMessage="Mandatory *" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Confirm Password</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtcpwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcpwd" Display="Dynamic" ErrorMessage="Mandatory *" ForeColor="#FF3300"></asp:RequiredFieldValidator>
&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpwd" ControlToValidate="txtcpwd" Display="Dynamic" ErrorMessage="Password doesnot match" ForeColor="#FF3300"></asp:CompareValidator>
            </td>
            <td class="auto-style7">Mobile Number</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtmblnum" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtmblnum" ErrorMessage="Mandatory *" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr>
            <td class="auto-style12">First Name</td>
            <td class="auto-style13">
                <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfirstname" ErrorMessage="Mandatory *" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            
            </td>
            <td class="auto-style14">&nbsp;</td>
          
        </tr>
        <tr>
            <td class="auto-style8">Last Name</td>
            <td class="auto-style9">
                <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtlastname" ErrorMessage="Mandatory *" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            
            </td>
            <td class="auto-style10">
                    <asp:Label ID="lblAreasofinterest" runat="server" Text="Areas of Interest"></asp:Label>
                </td>
            <td class="auto-style2">
                        <asp:CheckBoxList ID="chklAreasofInterest" runat="server" Width="107px">
                        </asp:CheckBoxList>
                    </td>
        </tr>
        <tr>
            <td class="auto-style5">
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtadress" runat="server" TextMode="MultiLine"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtadress" ErrorMessage="Mandatory *" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="auto-style6">
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdateProfile" runat="server" OnClick="Button1_Click" Text="Update" />
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                    &nbsp;</td>
            <td class="auto-style6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblupdatestatus" runat="server" Text="Label"></asp:Label>
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderAsideBar" runat="server">
   
        &nbsp; 
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
