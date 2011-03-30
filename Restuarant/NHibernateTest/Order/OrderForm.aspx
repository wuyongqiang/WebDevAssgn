<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderForm.aspx.cs" Inherits="NHibernateTest.Order.OrderForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create your order here</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="AddressLabel" runat="server" Text="Address"></asp:Label><asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
    
    </div>
    <div>
    
        <asp:Label ID="PhoneLabel" runat="server" Text="Phone"></asp:Label><asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
    
    </div>
    
    <div>
    <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' ></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity")  %>'></asp:Label>
            <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")  %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
    
    </div>
    
    </form>
</body>
</html>
