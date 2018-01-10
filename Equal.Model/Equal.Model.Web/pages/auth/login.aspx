<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="pages_auth_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="login.css" rel="stylesheet" />
</head>
<body>
<form id="form" runat="server">
    <div class="login-container">
        <h1>Equal.Net</h1>
        <div class="login-form-container">
            <div class="login-form">
                <ul>
                    <li>
                        <label>用户名：</label>
                        <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                    </li>
                    <li>
                        <label>密码：</label>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </li>
                    <li>
                        <label>记住密码：</label>
                        <asp:CheckBox ID="cbRemember" runat="server" />
                    </li>
                    <li>
                        <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
                        <%--<asp:Button ID="btnGetPassword" runat="server" Text="找回密码"  />--%>
                    </li>
                </ul>
            </div>
        </div>
        <p class="login-footer">
            <a href="https://gitee.com/EqualDong/Equal.Net">Equal.Net Power By EqualDong</a>
        </p>
    </div>
    <asp:Label ID="lblScript" runat="server" EnableViewState="False"></asp:Label>
</form>
</body>
</html>

