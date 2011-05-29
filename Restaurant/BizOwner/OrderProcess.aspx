<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OrderProcess.aspx.cs" Inherits="Order_OrderProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <!- The page needs to refresh often to get the new orders -->
    <meta http-equiv="refresh" content="30" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../Scripts/restaurant.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="OrderProcessGridView" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ORDER_ID,STATUS_ID,ORDERTYPE_ID" DataSourceID="OrderUpdateObjectDataSource"
        OnRowCommand="GridViewCommandEventHandler" style="margin-top: 1px">
        <Columns>
            <asp:BoundField DataField="ORDER_ID" HeaderText="ORDER_ID" 
                InsertVisible="False" ReadOnly="True" SortExpression="ORDER_ID" 
                Visible="False"/>
            <asp:BoundField DataField="STATUS_ID" HeaderText="STATUS_ID" 
                SortExpression="STATUS_ID" Visible="False"/>
            <asp:BoundField DataField="ORDERTYPE_ID" HeaderText="ORDERTYPE_ID" 
                SortExpression="ORDERTYPE_ID" Visible="False"/>
            <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME" />
            <asp:BoundField DataField="ADDRESS" HeaderText="Delivery Address" SortExpression="ADDRESS" />
            <asp:BoundField DataField="PHONE" HeaderText="Phone" SortExpression="PHONE" />
            <asp:BoundField DataField="ADDTEXT" HeaderText="Comment" SortExpression="ADDTEXT" />
            <asp:BoundField DataField="ORDER_TIME" HeaderText="Order time" SortExpression="ORDER_TIME" />
            <asp:BoundField DataField="USER_NAME" HeaderText="USER_NAME" SortExpression="USER_NAME" Visible="False" />
            <asp:BoundField DataField="ORDERTYPE_TEXT" HeaderText="Type" SortExpression="ORDERTYPE_TEXT" />
            <asp:BoundField DataField="STATUS_TEXT" HeaderText="Status" SortExpression="STATUS_TEXT" >
                <ControlStyle CssClass="status" />
            <ItemStyle CssClass="status" />
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" CommandName="Advance" HeaderText="Advance process" ShowHeader="True" Text="Next" >
                 <ControlStyle CssClass="next" />
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Button" CommandName="Cancel"  HeaderText="Cancel order" ShowHeader="True" Text="Cancel"  >
            <ControlStyle CssClass="cancel" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="OrderUpdateObjectDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="getOrderProcessData" TypeName="RestaurantApp.OrderProcessBiz">
    </asp:ObjectDataSource>
</asp:Content>

