using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboDSLR.Framework.Interfaces;

namespace TurboDSLR.Framework.Web.Seo
{
    /// <summary>
    /// SEO settings
    /// </summary>
    public class SeoSettings : ISettings
    {
        public string PageTitleSeparator { get; set; }
        public PageTitleSeoAdjustment PageTitleSeoAdjustment { get; set; }
        public string DefaultTitle { get; set; }
        public string DefaultMetaKeywords { get; set; }
        public string DefaultMetaDescription { get; set; }

        public bool ConvertNonWesternChars { get; set; }
        public bool AllowUnicodeCharsInUrls { get; set; }

        public bool CanonicalUrlsEnabled { get; set; }

        public WwwRequirement WwwRequirement { get; set; }

        /// <summary>
        /// A value indicating whether JS file bundling and minification is enabled
        /// </summary>
        public bool EnableJsBundling { get; set; }

        /// <summary>
        /// A value indicating whether CSS file bundling and minification is enabled
        /// </summary>
        public bool EnableCssBundling { get; set; }

        /// <summary>
        /// Slugs (sename) reserved for some other needs
        /// </summary>
        public List<string> ReservedUrlRecordSlugs { get; set; }

        /// <summary>
        /// Added by Jey to append website name
        /// </summary>
        public bool AppendWebsiteName { get; set; }

    }

    /// <summary>
    /// Represents a page title SEO adjustment
    /// </summary>
    public enum PageTitleSeoAdjustment
    {
        /// <summary>
        /// Pagename comes after storename
        /// </summary>
        PagenameAfterStorename = 0,
        /// <summary>
        /// Storename comes after pagename
        /// </summary>
        StorenameAfterPagename = 10
    }

    /// <summary>
    /// Represents WWW requirement
    /// </summary>
    public enum WwwRequirement
    {
        /// <summary>
        /// Doesn't matter (do nothing)
        /// </summary>
        NoMatter = 0,
        /// <summary>
        /// Pages should have WWW prefix
        /// </summary>
        WithWww = 10,
        /// <summary>
        /// Pages should not have WWW prefix
        /// </summary>
        WithoutWww = 20,
    }

}
