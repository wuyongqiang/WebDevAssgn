<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Restuarant._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Suzie Wong Asian Food Restaurant</title>
    <style type="text/css">
        .Bold
        {
            font-family: Times New Roman;
            font-size: medium;
            font-weight: bold;
        }
        .style2
        {
            width: 200px;
        }
        .style_SkipStroke
        {
            background: transparent;
        }
        .style_External_630_50
        {
            position: relative;
        }
        .style
        {
            padding: 4px;
        }
        .Header
        {
            color: rgb(167, 167, 167);
            font-family: 'Arial-BoldMT' , 'Arial' , sans-serif;
            font-size: 36px;
            font-stretch: normal;
            font-style: normal;
            font-variant: normal;
            font-weight: 700;
            letter-spacing: 0;
            line-height: 42px;
            margin-bottom: 0px;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
            padding-bottom: 0px;
            padding-top: 0px;
            text-align: center;
            text-decoration: none;
            text-indent: 0px;
            text-transform: none;
        }
        .style3
        {
            position: absolute;
            width: 630px;
            height: 50px;
            top: 28px;
            left: 197px;
            overflow: visible;
        }
        .style4
        {
            overflow: visible;
            padding: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="id1" class="">
        <div class="">
            <div class="">
                <p class="Header" style="PADDING-BOTTOM: 0pt; PADDING-TOP: 0pt; color: #FF6600;">
                    Suzie Wong Asian Fast Food</p>
            </div>
        </div>
    </div>
    
    <table style="width: 100%;">
        <tr>
            <td style="width: 10%;" rowspan="4">
                &nbsp;
            </td>
            <td style="height: auto" colspan="3">
             <div>
                <img alt="logo" src="Images/logo.png" style="padding-left: 28px;" />
                </div>
            <div>
               
                <img alt="phone" src="Images/ph1.jpg"/>
            </div>
                <div>
                    <p class="Bold" style="display: inline">
                        "This place is a great takeaway restaurant ,</p>
                    <p style="display: inline">
                        just don't expect to have a nice intimate meal in here. The service is friendly
                        and efficient, the food is nice (all types of asian food) and very well priced.
                        Highly recommended for takeaway."</p>
                    ‎
                </div>
            </td>
            <td style="width: 10%;" rowspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <div style="display: inline">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://maps.google.com.au/maps?hl=en&amp;biw=1346&amp;bih=612&amp;wrapid=tlif130083714660931&amp;um=1&amp;ie=UTF-8&amp;q=suzie+wong+newmarket&amp;fb=1&amp;gl=au&amp;hq=suzie+wong&amp;hnear=Newmarket+QLD&amp;cid=0,0,399946272996793355&amp;ei=2jKJTe2AMYiqcZjm0cIM&amp;sa=X&amp;oi=local_result&amp;ct=image&amp;resnum=1&amp;ved=0CBoQnwIwAA">
        <img width="270px" height="185px" alt="google map here"  src="Images/suziewongmap.gif" />
                                </asp:HyperLink>
                            </div>
                        </td>
                        <td>
                            <div style="display: inline; width: 300px">
                                <p style="font-family: 'Times New Roman', Times, serif; font-size: medium; font-weight: bold;">
                                    Suzie Wong Asian Fast Food
                                </p>
                                <p>
                                    190 Enoggera Road, Newmarket QLD 4051</p>
                                <p>
                                    (07) 3356 3555</p>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
