<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/HomeMasterPage.master" CodeFile="index.aspx.cs" Inherits="pages_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>首页</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- index-main -->
    <div class="index-main clearfix">
        <!-- index-banner -->
        <div class="index-banner">
            <img src="../images/index_banner_img.jpg" alt="" />
        </div>
        <!-- index-banner -->
        <!-- index-container -->
        <div class="index-container wrap clearfix">
            <!-- index-list-left -->
            <div class="index-list-left fl">
                <div class="index-list-title">
                    <h3>
                        <img src="../images/index_title_zw.jpg" alt="" /></h3>
                    <a href="manager-news-list.aspx">
                        <img src="../images/index_title_more.jpg" alt="" /></a>
                </div>
                <div class="index-left-cont clearfix">
                    <ul id="lblArticleInfoData1" runat="server">
                    </ul>
                </div>
                <br />
                <div class="index-list-title">
                    <h3>
                        <img src="../images/index_title_zw.jpg" alt="" /></h3>
                    <a href="manager-news-list.aspx">
                        <img src="../images/index_title_more.jpg" alt="" /></a>
                </div>
                <div class="index-left-cont clearfix">
                    <ul id="lblArticleInfoData2" runat="server">
                    </ul>
                </div>
            </div>
            <!-- index-list-left -->
            <!-- index-list-right -->
            <div class="index-list-right fr">
                <div class="index-list-title">
                    <h3>
                        <img src="../images/index_title_zw.jpg" alt="" /></h3>
                    <a href="manager-news-list.aspx">
                        <img src="../images/index_title_more.jpg" alt="" /></a>
                </div>
                <div class="index-right-cont clearfix">
                    <div class="subLi">
                        <div class="list" style="width: 300px">
                            <img src="../images/index_list_img.jpg" alt="" />
                            <asp:Label ID="lblArticleInfoData5" runat="server"></asp:Label>
                        </div>
                    </div>
                    <ul id="lblArticleInfoData3" runat="server">
                    </ul>
                </div>
                <br />
                <div class="index-list-title">
                    <h3>
                        <img src="../images/index_title_zw.jpg" alt="" /></h3>
                    <a href="manager-news-list.aspx">
                        <img src="../images/index_title_more.jpg" alt="" /></a>
                </div>
                <div class="index-right-cont clearfix">
                    <div class="subLi">
                        <div class="list" style="width: 300px">
                            <img src="../images/index_list_img.jpg" alt="" />
                            <asp:Label ID="lblArticleInfoData6" runat="server"></asp:Label>
                        </div>
                    </div>
                    <ul id="lblArticleInfoData4" runat="server">
                    </ul>
                </div>
            </div>

        </div>
        <!-- index-container -->
        <!-- index-list-right -->
        <div class="index-link wrap clearfix">
            <div class="index-link-img">
                <img src="../images/index_link_img.jpg" alt="" />
            </div>
            <div>
                <asp:Label runat="server" ID="lblTips" Text="友情提示"></asp:Label>
            </div>
        </div>
    </div>
    <!-- index-main -->
</asp:Content>
