<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/HomeMasterPage.master" CodeFile="manager-key-value-list.aspx.cs" Inherits="pages_manager_key_value_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="news-main clearfix">
        <div class="wrap news-main-container clearfix">
            <div class="header">
                导航列表
            </div>
            <div class="advertise-table row">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"  CssClass="table table-hover text-center" DataKeyNames="Id" OnRowDataBound="gv_RowDataBound" ShowHeaderWhenEmpty="true" OnRowDeleting="gv_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="键" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF">
                            <ItemTemplate>
                                <asp:Label ID="ilblKey" runat="server" Width="200px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="值" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF" >
                            <ItemTemplate>
                                <asp:Label ID="ilblValue" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="附加数据" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF">
                            <ItemTemplate>
                                <asp:Label ID="ilblAdditionalData" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#e62422" HeaderStyle-ForeColor="#FFFFFF">
                            <ItemTemplate>
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
