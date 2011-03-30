<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="NHibernateTest.CreateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create New User</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#FFFBD6" 
            BorderColor="#FFDFAD" BorderStyle="Solid" BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="0.8em" 
            oncreateduser="CreateUserWizard1_CreatedUser">
            <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" />
            <SideBarButtonStyle ForeColor="White" />
            <FinishNavigationTemplate>
                <asp:Button ID="FinishPreviousButton" runat="server" BackColor="White" 
                    BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" 
                    CausesValidation="False" CommandName="MovePrevious" Font-Names="Verdana" 
                    ForeColor="#990000" Text="back" />
                <asp:Button ID="FinishButton" runat="server" BackColor="White" 
                    BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" 
                    CommandName="MoveComplete" Font-Names="Verdana" ForeColor="#990000" Text="Finished" />
            </FinishNavigationTemplate>
            <ContinueButtonStyle BackColor="White" BorderColor="#CC9966" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#990000" />
            <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#990000" />
            <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" 
                BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" 
                HorizontalAlign="Center" />
            <CreateUserButtonStyle BackColor="White" BorderColor="#CC9966" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#990000" />
            <StepNavigationTemplate>
                <asp:Button ID="StepPreviousButton" runat="server" BackColor="White" 
                    BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" 
                    CausesValidation="False" CommandName="MovePrevious" Font-Names="Verdana" 
                    ForeColor="#990000" Text="back" />
                <asp:Button ID="StepNextButton" runat="server" BackColor="White" 
                    BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" 
                    CommandName="MoveNext" Font-Names="Verdana" ForeColor="#990000" Text="Next" />
            </StepNavigationTemplate>
            <TitleTextStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <StartNavigationTemplate>
                <asp:Button ID="StartNextButton" runat="server" BackColor="White" 
                    BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" 
                    CommandName="MoveNext" Font-Names="Verdana" ForeColor="#990000" Text="Next" />
            </StartNavigationTemplate>
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0" 
                            style="background-color:#FFFBD6;font-family:Verdana;font-size:100%;">
                            <tr>
                                <td align="center" colspan="2" 
                                    style="color:White;background-color:#990000;font-weight:bold;">
                                    Create New Account</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="Mandatory“User Name”。" ToolTip="Mandatory“User Name”。" 
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Mandatory“Password”。" ToolTip="Mandatory“Password”。" 
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmPassword">ConfirmPassword:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                        ControlToValidate="ConfirmPassword" ErrorMessage="Mandatory“Confirm Password”。" 
                                        ToolTip="Mandatory“Confirm Password”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                        ControlToValidate="Email" ErrorMessage="Mandatory“Email”。" ToolTip="Mandatory“Email”。" 
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                            <td align="center" colspan="2" 
                                    style="color:White;background-color:#990000;font-weight:bold;">
                                    If you forget your password</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Saftey Question:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                        ControlToValidate="Question" ErrorMessage="Mandatory“Saftey Question”。" 
                                        ToolTip="Mandatory“Saftey Question”。" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Question Answer:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                        ControlToValidate="Answer" ErrorMessage="Mandatory“Question Answer”。" ToolTip="Mandatory“Question Answer”。" 
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                        ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                        Display="Dynamic" ErrorMessage="“Password”and“ConfirmPassword”Must be the same" 
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                            <td align="center" colspan="2" 
                                    style="color:White;background-color:#990000;font-weight:bold;">
                                    Input the following to help filling the order</td>
                            </tr>
                            <tr>
                            <td align="right">
                                    <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="TextAddress">Address:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextAddress" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="TextAddress" ErrorMessage="Mandatory“Address”。" ToolTip="Mandatory“Address”。" 
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                            <td align="right">
                                    <asp:Label ID="PHoneLabel" runat="server" AssociatedControlID="TextPhone">Phone:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextPhone" runat="server"></asp:TextBox>
                                    
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextPhone"
                                        ErrorMessage="phone number format not correct"></asp:RegularExpressionValidator>
                                    
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                        <table border="0" cellspacing="5" style="width:100%;height:100%;">
                            <tr align="right">
                                <td align="right" colspan="0">
                                    <asp:Button ID="StepNextButton" runat="server" BackColor="White" 
                                        BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" 
                                        CommandName="MoveNext" Font-Names="Verdana" ForeColor="#990000" Text="Create a User" 
                                        ValidationGroup="CreateUserWizard1" />
                                </td>
                            </tr>
                        </table>
                    </CustomNavigationTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Finished</td>
                            </tr>
                            <tr>
                                <td>
                                    You have created an account successfully</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" 
                                        CommandName="Continue" PostBackUrl="~/Login.aspx" Text="Continue" 
                                        ValidationGroup="CreateUserWizard1" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">HyperLink</asp:HyperLink>
                    </CustomNavigationTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
    </form>
</body>
</html>
