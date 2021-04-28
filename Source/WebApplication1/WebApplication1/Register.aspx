<%@ Page Title="" Theme="OurTheme" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
        height: 42px;
    }
        .auto-style4 {
            width: 92px;
        }
        .auto-style5 {
            height: 42px;
            width: 92px;
        }
        .auto-style6 {
            height: 30px;
            width: 27%;
        }
        .auto-style7 {
            width: 27%;
        }
        .auto-style8 {
            height: 42px;
            width: 27%;
        }
        .auto-style9 {
            width: 92px;
            height: 23px;
        }
        .auto-style10 {
            height: 23px;
        }
        .auto-style11 {
            width: 27%;
            height: 23px;
        }
    .auto-style12 {
        height: 30px;
        width: 12%;
    }
    .auto-style13 {
            width: 79%;
        }
    .auto-style14 {
        height: 42px;
        width: 12%;
    }
    .auto-style15 {
        height: 23px;
        width: 12%;
    }
    .auto-style16 {
        height: 30px;
        width: 79%;
    }
    .auto-style17 {
        height: 42px;
        width: 14%;
    }
    .auto-style18 {
        height: 23px;
        width: 79%;
    }
    .auto-style19 {
        height: 42px;
        width: 79%;
    }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table class="auto-style1">
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style9">
                    <asp:Label ID="lblRegistrationform" runat="server" Font-Bold="True" Font-Size="Larger" Text="Registration Form"></asp:Label>
                </td>
                <td class="auto-style6"></td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style12">
                    <asp:Label ID="lblException" runat="server"></asp:Label>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblUserid" runat="server" Text="User ID"></asp:Label>
                </td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtUserId" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style12">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserId" ErrorMessage="UserID cannot be empty"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="192px"></asp:TextBox>
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password cannot be empty"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="189px"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10" id=" ">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Password cannot be empty"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password doesnot match"></asp:CompareValidator>
                </td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10" id=" ">
                </td>
                <td class="auto-style11">
                </td>
                <td class="auto-style18"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblFirstname" runat="server" Text="FirstName"></asp:Label>
                </td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="184px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="lbllastname" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtLastName" runat="server" Width="167px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style14">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter Firstname"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Must Contain Only Characters" ValidationExpression="[A-Za-z]{1,50}" ControlToValidate="txtFirstName"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style13">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter lastname"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Must Contain Characters between 1 and 50" ValidationExpression="[A-Za-z]{1,50}" ControlToValidate="txtLastName"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblDateofBirth" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date" Width="182px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="lablGender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td class="auto-style13">
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:RadioButtonList ID="rblGender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdateofbirth" ErrorMessage="Please enter Date of Birth"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style13">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="rblGender" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="auto-style17">
                    <asp:TextBox ID="txtAddress" runat="server" Height="36px" TextMode="MultiLine" Width="188px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="lblAreasofinterest" runat="server" Text="Areas of Interest"></asp:Label>
                </td>
                <td class="auto-style13">
                    <asp:Panel ID="Panel2" runat="server">
                        <asp:CheckBoxList ID="chklAreasofInterest" runat="server" Width="107px">
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style12">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter valid Address"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblLandlinenumber" runat="server" Text="Landline Number"></asp:Label>
                </td>
                <td class="auto-style20">
                    <asp:TextBox ID="txtLandlineNumber" runat="server" Width="190px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style13">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style12">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Format Must Be xxx-xxxx-xxxx" ValidationExpression="[0-9]{3}-[0-9]{4}-[0-9]{4}" ControlToValidate="txtLandlineNumber"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtLandlineNumber" ErrorMessage="Please enter valid landline number"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style13">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblMobilenumber" runat="server" Text="Mobile Number"></asp:Label>
                </td>
                <td class="auto-style10">
                    <asp:TextBox ID="txtboxMobileNumber" runat="server" Width="190px"></asp:TextBox>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtboxMobileNumber"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Format Must Be xxx-xxxx-xxxx" ValidationExpression="[0-9]{3}-[0-9]{4}-[0-9]{4}" ControlToValidate="txtboxMobileNumber"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style12"></td>
                <td class="auto-style7"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lbldiscount" runat="server" Font-Bold="True" Font-Size="Medium" Text="To Avail 20% Discount"></asp:Label>
                </td>
                <td class="auto-style12">
                    <asp:CheckBox ID="chksubscribe" runat="server" Text="Subscribe" />
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style12"></td>
                <td class="auto-style7"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style23">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" Width="114px" OnClick="btnRegister_Click" />
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style13"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
