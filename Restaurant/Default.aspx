<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="UserControl/GvOrder.ascx" tagname="GvOrder" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
     <table style="width: 100%;">
    <tr>
    <td></td>
    <td></td>
        <td align="right"> 
                <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl="~/Order/OrderForm.aspx" CssClass="style2">Submit Order</asp:HyperLink>
            </td>
    </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td rowspan="2" style="vertical-align: top" >
                <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" ondatabinding="GridView1_DataBinding" 
            style="margin-right: 23px" onrowcommand="GridView1_RowCommand">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Descript" HeaderText="Descript" 
                    SortExpression="Descript" />
                <asp:BoundField DataField="Price" DataFormatString="{0:c}" 
                    HeaderText="Price" SortExpression="Price" />
                <asp:TemplateField HeaderText="Quant">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="3" Width="30px">1</asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField CommandName="Order" Text="Order" />
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:restaurantConnectionString %>" 
            SelectCommand="SELECT [Id], [Name], [Descript], [Price] FROM [DishItem]">
        </asp:SqlDataSource>
    
    </div>
            </td>
            <td class="style1" style="vertical-align: top" >
              
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id" 
                    onrowcancelingedit="GridView2_RowCancelingEdit" 
                    onrowdeleted="GridView2_RowDeleted" onrowdeleting="GridView2_RowDeleting" 
                    onrowediting="GridView2_RowEditing" onrowupdated="GridView2_RowUpdated" 
                    onrowupdating="GridView2_RowUpdating">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="SubPrice" HeaderText="Price" ReadOnly="True" />
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <PagerTemplate>                        
                    </PagerTemplate>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <span>You havn&#39;t made any order</span>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
                
                
    <uc1:GvOrder ID="GvOrder1"  runat="server"/>    
    
    </div>
</asp:Content>
