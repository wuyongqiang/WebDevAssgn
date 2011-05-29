<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Sales.aspx.cs" Inherits="Sales_Sales" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Submit1_onclick() {

        }

// ]]>
    </script>
    <style type="text/css">
        #Text1
        {
            height: 25px;
            width: 168px;
        }
        #leftPanel
        {
            width: 438px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   
   
    <asp:UpdatePanel ID="SalesUpdatePanel" runat="server">
        <ContentTemplate>
            <div id="topPanel">
                <asp:Label ID="salesPeriodLbl" runat="server" Text="Select sales period:" 
                CssClass="salesfont"></asp:Label>
                <asp:RadioButtonList ID="SalesPeriodRadioButtonList" runat="server" 
                AutoPostBack="True" 
                onselectedindexchanged="HandleSalesPageRadioButtonEvent" 
                RepeatDirection="Horizontal" ToolTip="Select you sales period" 
                Width="494px" CssClass="salesfontsmall">
                    <asp:ListItem Value="1" Selected="True">Today</asp:ListItem>
                    <asp:ListItem Value="7">This week</asp:ListItem>
                    <asp:ListItem Value="30">This month</asp:ListItem>
                    <asp:ListItem Value="CustomDate">Custom Date</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div id="leftPanel">
                <asp:Label ID="lblTotalSalesTxt" runat="server" Text="Sales Pr Day:" 
               CssClass="salesfont"></asp:Label>
                <asp:Label ID="lblTotalSales" runat="server" CssClass="salesfont" Width="16px"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblSalesChart" runat="server" Text="Best selling items in selected period:" 
               CssClass="salesfont"></asp:Label>
                <asp:Chart ID="SalesChart" runat="server" Width="301px">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="DISHNAME" YValueMembers="Sales">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div id="rightPanel">
                <asp:Label ID="lblSalesFromDate" runat="server" Text="Select from date:" 
                CssClass="salesfont"></asp:Label>
                <asp:Calendar ID="SalesCalendar" runat="server" BackColor="White" 
                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                Height="180px" OnSelectionChanged="HandleSalesPageCalendarEvent" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </div>
            <div id="bottomPanel">
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="SalesPeriodRadioButtonList" 
                EventName="DataBinding" />
            <asp:AsyncPostBackTrigger ControlID="SalesCalendar" EventName="DataBinding" />
        </Triggers>
    </asp:UpdatePanel>

   
&nbsp;<br />
</asp:Content>

