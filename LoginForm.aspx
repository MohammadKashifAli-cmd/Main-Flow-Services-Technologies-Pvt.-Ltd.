<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="LoginApp.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <link rel="stylesheet" type="text/css" href="Content/Style.css" />
    <script src="Scripts/Script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center-container">
            <h2 class="title-label">Login Page</h2>
            <table class="login-table">
                <tr>
                    <td>
                        <asp:Label ID="lblUsername" runat="server">Username:</asp:Label></td>
                    <td>
                        <asp:TextBox ID="usernameField" runat="server" placeholder="Enter Username"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server">Password:</asp:Label></td>
                    <td>
                        <asp:TextBox ID="passwordField" runat="server" placeholder="Enter password" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
