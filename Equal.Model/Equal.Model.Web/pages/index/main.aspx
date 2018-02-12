<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="pages_index_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="main.css" rel="stylesheet" />
    <script>
        $('#btn').click(function(){
            $('#main').load("../test1.aspx");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <h1 class="tit-layout">div仿框架布局之典型的两栏布局Version2.0（Private）</h1>
            <asp:Button ID="btnOut" runat="server" Text="注销" OnClick="btnOut_Click" />
        </div>
        <div id="article">
            <div id="side">
                <div>
                    <button id="btn">yemian1</button>
                </div>
                <div>
                    <button class="btn">yemian2</button>
                </div>
            </div>
            <div id="main">
                <%--<iframe id="iframe" name="iframe" frameborder=0 width=100% height=100% src="../login-user-edit.aspx"></iframe>--%>
            </div>
        </div>
        <div id="footer">
            <address class="copyright">Copyright &copy; <a href="http://blog.doyoe.com/">doyoe.com</a></address>
        </div>
    </form>
</body>
</html>
