<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GvOrder.ascx.cs" Inherits="UserControl_GvOrder" %>
<style type="text/css">
    a:link, a:visited
    {
        color: #034af3;
    }
    
    #navigation1
    {
        position: absolute;
        top: 0;
        right: 5px;
        z-index: 2;
        text-align: right;
        background: #9cb27c;
    }
    
    #navigation
    {
        position: fixed;
        z-index: 2;
        background: #9cb27c;
    }
</style>
<script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript">
    $(function () {
        $(window).scroll(
            function () {
               
                $('#navigation1')
                .stop()
                .animate({
                    top: $(document).scrollTop()
                },
                    {
                        duration: 500,
                        easing: 'easeOutBack'
                    });

            });

    });

</script>
<div id="navigation">
    <asp:GridView ID="GvOrder" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None" DataKeyNames="Id" OnRowCancelingEdit="GvOrder_RowCancelingEdit"
        OnRowDeleted="GvOrder_RowDeleted" OnRowDeleting="GvOrder_RowDeleting" OnRowEditing="GvOrder_RowEditing"
        OnRowUpdated="GvOrder_RowUpdated" OnRowUpdating="GvOrder_RowUpdating">
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
            <span>No items to show</span>
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:HiddenField ID="HiddenField1" runat="server" Visible="False" Value="true" />
</div>
