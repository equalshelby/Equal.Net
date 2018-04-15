<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/pages/HomeMasterPage.master" CodeFile="manager-news.aspx.cs" Inherits="pages_manager_manager_news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>文章编辑</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- answer-main -->
    <div class="news-main clearfix">
        <div class="wrap news-main-container clearfix">
            <div class="header" >文章管理 </div>
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
                        <asp:HiddenField />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- answer-main -->
</asp:Content>
