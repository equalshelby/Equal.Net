namespace Equal.Utility.Web
{
    /// <summary>
    /// 网页脚本类
    /// </summary>
    public class ScriptHelper
    {
        /// <summary>
        /// 创建JavaScript代码块
        /// </summary>
        /// <param name="javaScriptCode">JavaScript代码</param>
        /// <returns>完整的JavaScript代码块</returns>
        public static string CreateJavaScriptBlock(string javaScriptCode)
        {
            return @"
<script type=""text/javascript"" language=""javascript"">
<!--
" + javaScriptCode + @"
//-->
</script>";
        }

        /// <summary>
        /// 创建JavaScript Alert代码块
        /// </summary>
        /// <param name="message">Alert字符串</param>
        /// <returns>完整的JavaScript代码块</returns>
        public static string CreateJavaScriptAlertBlock(string message)
        {
            return CreateJavaScriptBlock(@"alert('" + message + @"');");
        }

    }
}
