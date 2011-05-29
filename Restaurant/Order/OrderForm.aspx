<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OrderForm.aspx.cs" Inherits="Order_OrderForm" %>

<%@ Register src="../UserControl/GvOrder.ascx" tagname="GvOrder" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 128px;
            text-align:right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p/> 
    <table style="width:100%;">
        <tr>
            <td class="style1" >
                OrderType:</td>
            <td>
                <asp:DropDownList ID="ddlOrderType" runat="server"> </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td class="style1" >
                Name:</td>
            <td>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" >
                Phone Number:</td>
            <td>
                <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Address</td>
            <td>
                <asp:TextBox ID="tbAdd" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Additional Text</td>
            <td>
                <asp:TextBox ID="tbAddition" runat="server" Width="454px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="82px" 
                    onclick="btnSubmit_Click" /> </td>
            <td>
                
                <asp:Label ID="LabelRslt" runat="server"></asp:Label>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>            
            <td colspan="2">
                <uc1:GvOrder ID="GvOrderDetail" runat="server" />
            <asp:LinkButton ID="LinkButtonMyOrders" Text="ShowMyOrders" Visible="false" runat="server" OnClick="LinkButtonMyOrders_Click"></asp:LinkButton>    
            </td>
        </tr>
    </table>
    
</asp:Content>

