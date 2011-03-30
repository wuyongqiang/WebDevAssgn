<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="NHibernateTest.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Layout Practice</title>
    
    <style type="text/css">
    body 
        { 
        	column-width: 12em 
         }
    
    .leftpage
    {
    	font-family: 'Times New Roman', Times, serif; 
    	font-size: xx-large; 
    	color: #000000 ;
    	display :block;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div style="margin-left: 10px; margin-right: 10px;">
    <div style="background-color: #FFFFFF; display: block;height:75px; background-image: url('head.PNG'); background-repeat: no-repeat; "  >
        
        
        <img / src="welcome.PNG" style="margin-left: 120px; margin-top: 20px">
        
        </div>
    
    <div style="float: left; height: 400px;width:15%;">
        <span class="leftpage" > order history </span>
        <span class="leftpage" > How I can find </span>
        <span class="leftpage" > More info </span>
        <span class="leftpage" > More info </span>
    </div>
    <div style="float: right; height: 400px;width:85%; background-image: url('bgtext.GIF'); border-right-width: 2px; border-right-color: #00FFFF;">
        <span> main page</span>
    </div>
    
    <div style="vertical-align: bottom; border-width: thin; border-color: #008000;height:70px;width:100%"> 
    
    <span style="display:block"> bottom </span>
    
    <span> copyright reserved</span>
    
    </div>
    
    </div>
    </form>
</body>
</html>
