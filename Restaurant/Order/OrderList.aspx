<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="OrderList.aspx.cs" Inherits="Order_OrderList" %>

<%@ Register Src="../UserControl/GvOrder.ascx" TagName="GvOrder" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="rightDiv">
        <span>
        <asp:Panel ID="PanelCalendar" runat="server" >
        <asp:Calendar ID="CalendarSearchDate"
            runat="server" onselectionchanged="CalendarSearchDate_SelectionChanged" BackColor="White" 
                        BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                        ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" 
                Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>           
        </asp:Panel>
        
        </span>
        <span>
            <uc1:GvOrder ID="GvOrderDetail" runat="server" />
        </span>
    </div>
    <div class="leftDiv">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:restaurantConnectionString %>"
            SelectCommand="SELECT [ORDER_ID], [NAME], [ADDRESS], [PHONE], [ADDTEXT], [ORDER_TIME] FROM [TOrder]">
        </asp:SqlDataSource>
        <table>
            <tr>
                <td align="right">
                    Begin Date
                </td>
                <td>
                    <asp:TextBox ID="tbBegin" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButtonBeinDate" runat="server" 
                        onclick="LinkButtonBeginDate_Click">calendar</asp:LinkButton>
                </td>
                <td> </td>
            </tr>
            <tr>
                <td align="right">
                    End Date
                </td>
                <td>
                    <asp:TextBox ID="tbEnd" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButtonEndDate" runat="server" 
                        onclick="LinkButtonEndDate_Click">calendar</asp:LinkButton>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                        onclick="btnSearch_Click" />
                </td>
                <td></td>
            </tr>
        </table>
        <asp:Repeater ID="RepeaterOrders" runat="server"  
            OnItemCommand="RepeaterOrders_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td align="right">
                            ID
                        </td>
                        <td>
                            Name
                        </td>
                        <td>
                            Phone
                        </td>
                        <td>
                            Time
                        </td>
                        <td>
                            Price
                        </td>
                        <td>
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="right">
                        <asp:Label ID="ORDER_IDLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NAMELabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PHONELabel" runat="server" Text='<%# Eval("Phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ORDER_TIMELabel" runat="server" Text='<%# Eval("OrderTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Price")%>' />
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="show more" />
                    </td>
                </tr>
                 <tr>
                    <td>
                    </td>
                    <td>
                        ADDRESS
                    </td>
                    <td colspan="4">
                        <asp:Label ID="ADDRESSLabel" runat="server" Text='<%# Eval("Address") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        Comment
                    </td>
                    <td colspan="4">
                        <asp:Label ID="ADDTEXTLabel" runat="server" Text='<%# Eval("AddText") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        Status
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label2" runat="server" Text='<%# GetStatusText(Eval("Status")) %>' />
                    </td>
                    <td>
                        Type
                    </td>
                    <td colspan="1">
                        <asp:Label ID="Label3" runat="server" Text='<%# GetTypeText(Eval("OrderType")) %>' />
                    </td>
                </tr>
               
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
