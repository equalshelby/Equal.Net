<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/HomeMasterPage.master" CodeFile="advertise.aspx.cs" Inherits="pages_advertise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>招聘内页</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <!-- answer-main -->
    <div class="advertise-main clearfix">
        <div class="wrap advertise-main-container clearfix">
            <div class="advertise-title">
                <img src="../images/advertise_title.jpg" alt="">
            </div>
            <!-- advertise-cont -->
            <div class="advertise-cont clearfix">
                <div class="advertise-ht clearfix">
                    <p class="on">1. 选择职位</p>
                    <p>2. 粘贴简历</p>
                    <p>3. 申请成功</p>
                </div>
                <!-- advertise-info -->
                <div class="advertise-info">
                    <div class="info-title">
                        <h3>
                            软件开发工程师
                        </h3>
                        <p>工作地点：郑州&nbsp;&nbsp;&nbsp;招聘人数：20人</p>
                    </div>
                    <div class="info-cont clearfix">
                        <div class="info-list">
                            <div class="info-li">
                                <h3>职位描述：</h3>
                                <p>
                                    1、负责软件产品研发项目的需求分析、设计开发、研发管理工作，承担核心代码的编写，保证软件产品按计划交付；<br>
                                    2、解决项目实施过程中的关键问题和技术难点；<br>
                                    3、协助测试团队完成软件系统及模块的测试；<br>
                                    4、完成公司安排的其他工作。
                                </p>
                            </div>
                            <div class="info-li">
                                <h3>任职条件：</h3>
                                <p>
                                    1、2018届应届统招本硕毕业生，计算机技术、软件工程等相关专业；<br>
                                    2、具有非常强的责任心，能够承担压力做事细心，参与独立系统的设计、开发、维护工作；<br>
                                    3、熟练掌握Java语法，了解JVM基本原理；<br>
                                    4、了解Javascript，Html，Css，能独立完成简单前端功能开发；<br>
                                    5、了解关系型数据库结构，熟悉sql语法，能熟练使用SQL语句完成增删改查和复杂报表功能；<br>
                                    6、掌握基本的数据结构，了解算法设计的基本思路；<br>
                                    7、使用过Maven, Spring MVC，Mybatis, Bootstrap框架的优先；<br>
                                    8、思维清晰，逻辑清楚，执行力强；认真细致，踏实勤奋，具有较好的团队协作精神和沟通能力。
                                </p>
                            </div>
                        </div>
                        <div class="info-button clearfix">
                            <a class="large button yellow">申请该职位</a>
                            <a class="large button orange">返回职位列表</a>
                        </div>
                    </div>
                </div>
                <!-- advertise-info -->
            </div>
            <!-- advertise-cont -->
        </div>
    </div>
    <!-- answer-main -->
</asp:Content>