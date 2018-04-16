<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/HomeMasterPage.master" CodeFile="manager-key-value.aspx.cs" Inherits="pages_manager_manager_key_value" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- answer-main -->
    <div class="answer-main clearfix">
        <div class="wrap answer-main-container clearfix">
            <div class="answer-title">
                <img src="../images/answer_title.jpg" alt="" />
            </div>
            <div class="answer-list clearfix">
                <div class="answer-li">
                    <table class="form-table">
                        <tr>
                            <td class="lbl">标识</td>
                            <td>
                                <asp:TextBox ID="tbKey" runat="server" Width="500"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl">内容</td>
                            <td>
                                <asp:TextBox ID="tbValue" runat="server" Width="500"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl">类型</td>
                            <td>
                                <asp:TextBox ID="tbType" runat="server" Width="500"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                <asp:Button ID="btnSave" runat="server" Text ="保存" OnClick="btnSave_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!-- answer-main -->
</asp:Content>
