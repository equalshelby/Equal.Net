﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/HomeMasterPage.master" CodeFile="manager-news-list.aspx.cs" Inherits="pages_manager_news_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="news-main clearfix">
        <div class="wrap news-main-container clearfix">
            <div class="header">
                文章列表
            </div>
            <div class="advertise-table row">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"  CssClass="table table-hover text-center" DataKeyNames="Id" OnRowDataBound="gv_RowDataBound" ShowHeaderWhenEmpty="true" OnRowDeleting="gv_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF">
                            <ItemTemplate>
                                <asp:Label ID="ilblTitle" runat="server" Width="200px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发布时间" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF" >
                            <ItemTemplate>
                                <asp:Label ID="ilblSubmitTime" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发布者" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF">
                            <ItemTemplate>
                                <asp:Label ID="ilblSubmitUser" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="点击量" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF">
                            <ItemTemplate>
                                <asp:Label ID="ilblClickCount" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF">
                            <ItemTemplate>
                                <asp:HyperLink ID="ihlDetail" runat="server" Text="详情"></asp:HyperLink>
                                <asp:HyperLink ID="ihlEdit" runat="server" Text="编辑"></asp:HyperLink>
                                <asp:LinkButton ID="ilbtnDelete" runat="server" Text="删除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="pager-container">
                <webdiyer:AspNetPager runat="server" ID="anp" OnPageChanged="anp_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
</asp:Content>
