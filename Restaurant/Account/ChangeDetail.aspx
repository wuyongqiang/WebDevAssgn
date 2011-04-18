<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ChangeDetail.aspx.cs" Inherits="Account_ChangePasswordSuccess" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 352px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td align="center" colspan="2" style="color: Red;">
                <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="color: White; background-color: #990000; font-weight: bold;">
                Input the following to help filling the order
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="TextName">Name:</asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="TextName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextName"
                    ErrorMessage="Mandatory“Name”。" ToolTip="Mandatory“Name”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="TextAddress">Address:</asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="TextAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextAddress"
                    ErrorMessage="Mandatory“Address”。" ToolTip="Mandatory“Address”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="PHoneLabel" runat="server" AssociatedControlID="TextPhone">Phone:</asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="TextPhone" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextPhone"
                    ErrorMessage="phone number format not correct" ValidationExpression="\d{8,10}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="style1">
                <asp:Button ID="Button1" runat="server" Text="OK" Width="77px" 
                    onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
