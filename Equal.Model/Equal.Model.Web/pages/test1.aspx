<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test1.aspx.cs" Inherits="pages_test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="author" content="Chomo" />
<link rel="start" href="http://www.14px.com" title="Home" />
<title>div仿框架布局</title>
<style type="text/css">
* { margin:0; padding:0; list-style:none;}
html { height:100%; overflow:hidden; background:#fff;}
body { height:100%; overflow:hidden; background:#fff;}
div { background:#f60; line-height:1.6;}
.top { position:absolute; left:10px; top:10px; right:10px; height:50px;}
.side { position:absolute; left:10px; top:70px; bottom:70px; width:200px; overflow:auto;}
.main { position:absolute; left:220px; top:70px; bottom:70px; right:10px; overflow:auto;}
.bottom { position:absolute; left:10px; bottom:10px; right:10px; height:50px;}
/*---ie6---*/
html { _padding:70px 10px;}
.top { _height:50px; _margin-top:-60px; _margin-bottom:10px; _position:relative; _top:0; _right:0; _bottom:0; _left:0;}
.side { _height:100%; _float:left; _width:200px; _position:relative; _top:0; _right:0; _bottom:0; _left:0;}
.main { _height:100%; _margin-left:207px; _position:relative; _top:0; _right:0; _bottom:0; _left:0;}
.bottom { _height:50px; _margin-top:10px; _position:relative; _top:0; _right:0; _bottom:0; _left:0;}
</style>



 <script src='js/jquery.js'></script>
<script>
/** 初始化加载页面 **/
jQuery(document).ready(function(){
document.getElementById("iframe").src='index.htm';
})
/****   网页跳转到页面顶部  ****/
function parentGoTop(){
$(function(){$('html, body').animate({  
                   scrollTop: 0  
    },0);});
}
/****  根据链接地址跳转页面   ****/
function clicklist(uri){
document.getElementById("iframe").src=uri;
parentGoTop();
}
</script>



<style type='text/css'>
li a{
float:left;
width:200px;
display:block;
}
</style>
</head>
<body>
<div class="top"></div>
<div class="side">
<ul class='menu'>
<li><strong>资源专版快讯管理</strong></li>
<li><a  onClick="clicklist('test2.aspx');"> 发布网上资源/供求专版 </a></li>
<li><a  onClick="clicklist('login-user-edit.aspx');"> login-user-edit.aspx</a></li>
<li><a  onClick="clicklist('mypay.htm');"> 供求快讯发布</a></li>
<li><a  onClick="clicklist('head.htm');"> 供求快讯重发/修改/删除</a></li>
</ul>
</div>
<div class="main">
<IFRAME id="iframe"  src="" height='850px' width="700"  frameBorder=0 scrolling=yes></IFRAME>
</div>
<div class="bottom"></div>
</body>
</html>
