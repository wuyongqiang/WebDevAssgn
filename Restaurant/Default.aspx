<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<p>
    <h2>Welcome to the Asian Fast Food - online order system</h2>
</p>
<p>
    This system is created by Wu Yongqiang - n7682905 and Bjorn Smette n4193989</p>
<p>
    <h3>User guide as a "customer"</h3>
</p>
<p>
    1. Go to the <a href="FirstPage.aspx">first page</a> of the system by clicking &#39;Home&#39;<br />
    2. Select from the menu what you would like to order - click &#39;Submit&#39;<br />
    3. <a href="Account/Login.aspx">Log in</a> using login &#39;customer&#39;, - the password is 123456<br />
    4. You can now enter/change details for this particular order (E.g. if the customer is away from home)<br />
    5. You can now go to 'My Orders' and search the current order date or a previous order date. Here you can view the status of the order.<br />
</p>

<p>
    <h3>User guide as an "admin" </h3>
<p>
<p>
    1. <a href="Account/Login.aspx">Log in</a> using login &#39;admin&#39;, - the password is 123456<br />
    2. On the Sales Menu item select "Process Orders"
    3. Here you will see a list of the current orders, and you have the option to advance the status or decline the order<br />
    4. Only Unprocessed orders can be cancelled.
</p>

<p>
    <h3>User guide as an "sales"</h3>
</p>
<p>
    1. <a href="Account/Login.aspx">Log in</a> using login &#39;sales&#39;, - the password is 123456<br />
    2. On the Sales Menu item select "Sales"
    3. Select the sales period you want, and the server will update the total sales and a the corresponding chart showing the dish giving most revenue in the selected period<br />
</p>
<p>
    &nbsp;</p>
</asp:Content>

