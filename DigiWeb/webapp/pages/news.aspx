<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/HomeMasterPage.master" CodeFile="news.aspx.cs" Inherits="pages_news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>文章详情</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- answer-main -->
    <div class="news-main clearfix">
        <div class="wrap news-main-container clearfix">
            <div class="news-title">
                <img src="../images/news_title.jpg" alt="" />
            </div>
            <div class="news-article clearfix">
                <h3><asp:Label runat="server" ID="lblTitle"></asp:Label></h3>
                <div class="news-info">
                    <p>发布时间：<asp:Label runat="server" ID="lblSubmitTime"></asp:Label> </p>
                    <p>发布者：<asp:Label runat="server" ID="lblSubmitUser"></asp:Label></p>
                </div>
                <div class="news-cont clearfix">
                    <p style="text-align: center; padding-bottom: 45px;">
                        <img src="../images/new_img.jpg" alt="" />
                    </p>
                    <p style="padding-bottom: 10px;">
                        <asp:Label runat="server" ID="lblContext"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <!-- answer-main -->
</asp:Content>
