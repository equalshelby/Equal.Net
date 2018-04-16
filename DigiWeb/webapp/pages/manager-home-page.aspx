<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/pages/HomeMasterPage.master" CodeFile="manager-home-page.aspx.cs" Inherits="pages_manager_home_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>主页管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- answer-main -->
    <div class="news-main clearfix">
        <div class="wrap news-main-container clearfix">
            <div class="header" >主页管理 </div>
            <table class="form-table">
                <tr>
                    <td class="lbl">欢迎语
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbWelcome" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">列表1名称
                    </td>
                    <td>
                        <asp:TextBox ID="tbList1Name" runat="server"></asp:TextBox>
                    </td>
                    <td class="lbl">列表2名称
                    </td>
                    <td>
                        <asp:TextBox ID="tbList2Name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">列表3名称
                    </td>
                    <td>
                        <asp:TextBox ID="tbList3Name" runat="server"></asp:TextBox>
                    </td>
                    <td class="lbl">列表4名称
                    </td>
                    <td>
                        <asp:TextBox ID="tbList4Name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">电话1
                    </td>
                    <td>
                        <asp:TextBox ID="tbPhone1" runat="server"></asp:TextBox>
                    </td>
                    <td class="lbl">电话2
                    </td>
                    <td>
                        <asp:TextBox ID="tbPhone2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">企业邮箱
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbEmail" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">企业地址
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbAddress" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lbl">版权信息
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbCopyrightInfo" runat="server" Width="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:center">
                        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- answer-main -->
</asp:Content>
