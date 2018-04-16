<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/HomeMasterPage.master" CodeFile="management-van.aspx.cs" Inherits="pages_management_van" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- answer-main -->
    <div class="answer-main clearfix">
        <div class="wrap answer-main-container clearfix">
            <div class="header">
                后台管理
            </div>
            <div class="answer-list clearfix">
                <div class="answer-li">
                    <table class="form-table">
                        <tr>
                            <td class="lbl">主页管理</td>
                            <td>
                                <a href="manager-home-page.aspx">主页管理</a>
                            </td>
                            <td class="lbl">导航栏管理</td>
                            <td>
                                <a href="manager-key-value-list.aspx?id=true">导航栏管理</a>
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl">文章管理</td>
                            <td>
                                <a href="manager-news-list.aspx?id=true">文章管理列表</a>
                            </td>
                            <td class="lbl">添加文章</td>
                            <td>
                                <a href="manager-news.aspx">添加文章</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!-- answer-main -->
</asp:Content>
