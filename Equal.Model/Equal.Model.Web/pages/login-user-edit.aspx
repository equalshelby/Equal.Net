<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login-user-edit.aspx.cs" Inherits="pages_login_user_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>用户名</td>
                <td>密码</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="tbLoginName" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbPassWord" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnRegist" OnClick="btnRegist_Click" Text="注册" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnSearch" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
