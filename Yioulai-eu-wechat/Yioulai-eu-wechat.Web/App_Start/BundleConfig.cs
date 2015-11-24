using System.Web;
using System.Web.Optimization;

namespace Yioulaieuwechat.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-3.2.0.js",
                "~/Scripts/knockout.mapping-latest.js"));
            //Home
            bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                        "~/Scripts/JS/Home.js"));
            //knockout-kendo
            bundles.Add(new ScriptBundle("~/bundles/knockout-kendo").Include("~/Scripts/kendo.all.min.js",
                        "~/Scripts/knockout-kendo.min.js"));
            //GetMangoCard
            bundles.Add(new ScriptBundle("~/bundles/GetMangoCard").Include(
                      "~/Scripts/JS/GetMangoCard.js"));
            //LoginConfirmation
            bundles.Add(new ScriptBundle("~/bundles/LoginConfirmation").Include(
                      "~/Scripts/JS/LoginConfirmation.js"));
            //QrCodeHandle
            bundles.Add(new ScriptBundle("~/bundles/QrCodeHandle").Include(
                       "~/Scripts/JS/QrCodeHandle.js"));
            //MyQrCodeList
            bundles.Add(new ScriptBundle("~/bundles/MyQrCodeList").Include(
                      "~/Scripts/JS/MyQrCodeList.js"));
        }
    }
}
