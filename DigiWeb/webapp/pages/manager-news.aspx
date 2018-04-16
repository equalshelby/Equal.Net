<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/pages/HomeMasterPage.master" CodeFile="manager-news.aspx.cs" Inherits="pages_manager_manager_news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>文章编辑</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- answer-main -->
    <div class="news-main clearfix">
        <div class="wrap news-main-container clearfix">
            <div class="header" >文章编辑 </div>
            <table class="form-table">
                <tr>
                    <td class="lbl">标题
                    </td>
                    <td>
                        <asp:TextBox ID="tbTitle" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">发布时间
                    </td>
                    <td>
                        <asp:TextBox ID="tbSubmitTime" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">发布类型
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Text ="类型1" Value="1"></asp:ListItem>
                            <asp:ListItem Text ="类型2" Value="2"></asp:ListItem>
                            <asp:ListItem Text ="类型3" Value="3"></asp:ListItem>
                            <asp:ListItem Text ="类型4" Value="4"></asp:ListItem>
                            <asp:ListItem Text ="类型5" Value="5"></asp:ListItem>
                            <asp:ListItem Text ="类型6" Value="6"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">点击量
                    </td>
                    <td>
                        <asp:TextBox ID="tbClickCount" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">发布者
                    </td>
                    <td>
                        <asp:TextBox ID="tbSubmitUser" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">发布内容
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="tbContext" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" ></asp:Button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- answer-main -->
</asp:Content>
