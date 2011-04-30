<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

    <div>
    <span>test page object data source</span>
    </div>
    <hr />

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


    <div>
    
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" 
            AutoGenerateColumns="False" onrowupdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="DishId" HeaderText="DishId" 
                    SortExpression="DishId" />
                <asp:BoundField DataField="DishName" HeaderText="DishName" 
                    SortExpression="DishName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" 
                    SortExpression="Amount" />
                <asp:BoundField DataField="SubPrice" HeaderText="SubPrice" 
                    SortExpression="SubPrice" />
                <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="RestaurantApp.TAppOrderItem" DeleteMethod="deleteOrderItem" 
            InsertMethod="insertOrderItem" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="getOrderItems" TypeName="RestaurantApp.OrderObj" 
            UpdateMethod="updateDataItem" onselected="ObjectDataSource1_Selected" 
            onupdating="ObjectDataSource1_Updating">
            <InsertParameters>
                <asp:Parameter Name="sessionid" Type="Int32" />
                <asp:Parameter Name="item" Type="Object" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="sessionid" SessionField="SessionID" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <%--<asp:Parameter Name="sessionid" Type="Int32" />--%>
                <asp:Parameter Name="item" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    
    </div>
    <div>
    
        <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" 
            onitemupdating="FormView1_ItemUpdating">
            <EditItemTemplate>
                Id:
                <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                <br />
                DishId:
                <asp:TextBox ID="DishIdTextBox" runat="server" Text='<%# Bind("DishId") %>' />
                <br />
                DishName:
                <asp:TextBox ID="DishNameTextBox" runat="server" 
                    Text='<%# Bind("DishName") %>' />
                <br />
                Price:
                <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                <br />
                Amount:
                <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' />
                <br />
                SubPrice:
                <asp:TextBox ID="SubPriceTextBox" runat="server" 
                    Text='<%# Bind("SubPrice") %>' />
                <br />
                Text:
                <asp:TextBox ID="TextTextBox" runat="server" Text='<%# Bind("Text") %>' />
                <br />
              <%--  Order:
                <asp:TextBox ID="OrderTextBox" runat="server" Text='<%# Bind("Order") %>' />
                <br />--%>
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Id:
                <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                <br />
                DishId:
                <asp:TextBox ID="DishIdTextBox" runat="server" Text='<%# Bind("DishId") %>' />
                <br />
                DishName:
                <asp:TextBox ID="DishNameTextBox" runat="server" 
                    Text='<%# Bind("DishName") %>' />
                <br />
                Price:
                <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                <br />
                Amount:
                <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' />
                <br />
                SubPrice:
                <asp:TextBox ID="SubPriceTextBox" runat="server" 
                    Text='<%# Bind("SubPrice") %>' />
                <br />
                Text:
                <asp:TextBox ID="TextTextBox" runat="server" Text='<%# Bind("Text") %>' />
                <br />
                <%--Order:
                <asp:TextBox ID="OrderTextBox" runat="server" Text='<%# Bind("Order") %>' />
                <br />--%>
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                Id:
                <asp:Label ID="IdLabel" runat="server" Text='<%# Bind("Id") %>' />
                <br />
                DishId:
                <asp:Label ID="DishIdLabel" runat="server" Text='<%# Bind("DishId") %>' />
                <br />
                DishName:
                <asp:Label ID="DishNameLabel" runat="server" Text='<%# Bind("DishName") %>' />
                <br />
                Price:
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("Price") %>' />
                <br />
                Amount:
                <asp:Label ID="AmountLabel" runat="server" Text='<%# Bind("Amount") %>' />
                <br />
                SubPrice:
                <asp:Label ID="SubPriceLabel" runat="server" Text='<%# Bind("SubPrice") %>' />
                <br />
                Text:
                <asp:Label ID="TextLabel" runat="server" Text='<%# Bind("Text") %>' />
                <br />
                <%--Order:
                <asp:Label ID="OrderLabel" runat="server" Text='<%# Bind("Order") %>' />
                <br />--%>
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Edit" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" />
            </ItemTemplate>
        </asp:FormView>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    
    </div>

    <div>
    

            <asp:Panel ID="Panel2" runat="server">
           <p style="display:inline"> date picked</p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button2"
            runat="server" Text="Calendar" onclick="Button2_Click" /> 
            
            </asp:Panel>
           
        
        <asp:Panel ID="Panel1" runat="server" >
        <asp:Calendar ID="Calendar1" Visible="true" 
            runat="server" onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
            <p> haha</p>
        </asp:Panel>
            
    </div>
    <div>
    <table>

    <tr CssClass="upLayer"> 

    <td> asdfasdfasd</td>
    </tr>
        <caption>
            asdfsadfsad<tr>
                <td>
                </td>
                <caption>
                    asdfasdfasf<tr>
                        <td>
                            sdfasdfasdfasdf</td>
                    </tr>
                    <tr>
                        <td>
                            asdfasdfasd</td>
                        <caption>
                            asdfsadfsad<tr>
                                <td>
                                </td>
                                <caption>
                                    asdfasdfasf<tr>
                                        <td>
                                            sdfasdfasdfasdf</td>
                                        <tr>
                                            <td>
                                                asdfasdfasd</td>
                                            <caption>
                                                asdfsadfsad<tr>
                                                    <td>
                                                    </td>
                                                    <caption>
                                                        asdfasdfasf<tr>
                                                            <td>
                                                                sdfasdfasdfasdf</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                asdfasdfasd</td>
                                                            <caption>
                                                                asdfsadfsad<tr>
                                                                    <td>
                                                                    </td>
                                                                    <caption>
                                                                        asdfasdfasf<tr>
                                                                            <td>
                                                                                sdfasdfasdfasdf</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                asdfasdfasd</td>
                                                                            <caption>
                                                                                asdfsadfsad<tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <caption>
                                                                                        asdfasdfasf<tr>
                                                                                            <td>
                                                                                                sdfasdfasdfasdf</td>
                                                                                        </tr>
                                                                                    </caption>
                                                                                </tr>
                                                                            </caption>
                                                                        </tr>
                                                                    </caption>
                                                                </tr>
                                                            </caption>
                                                        </tr>
                                                    </caption>
                                                </tr>
                                            </caption>
                                        </tr>
                                    </tr>
                                </caption>
                            </tr>
                        </caption>
                    </tr>
                </caption>
            </tr>
        </caption>
    
    </table>
    
    </div>

    <div id="fixme" style="background-color:Red;position:fixed;top:10;left:73%;width:30;height:20;z-index:2"> Some Fixed Content </div>


    <div>
    <p> hi<asp:CheckBoxList ID="CheckBoxList1" runat="server">
        <asp:ListItem>option1</asp:ListItem>
        <asp:ListItem>option2</asp:ListItem>
        <asp:ListItem>option3</asp:ListItem>
        </asp:CheckBoxList>
        </p>

    
    </div>
    </ContentTemplate>

    </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                Getting employees...
            </ProgressTemplate>
        </asp:UpdateProgress>


    </form>
</body>
</html>
