using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostBoard.Framework.Common
{
    /// <summary>
    /// Base interface for each photos used in this system.
    /// This interface will be used to post in social media or just to display on this website it self.
    /// Trying to Stick to KISS principal as much as possible.
    /// </summary>
    interface IBoardPhoto
    {
        /// <summary>
        /// Unique id for photo
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// A Short Introduction about the image. Usually shown in P or H tag
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// A Title for the image. Usually shown in H tag
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Alternative text to show in img tag
        /// </summary>
        string AltText { get; set; }

        /// <summary>
        /// will be used as # tags
        /// </summary>
        IList<string> Keywords { get; set; }

        /// <summary>
        /// No full idea on this. But this can be used to hold information like latitude or longitude etc.
        /// </summary>
        Dictionary<string, string> Attributes { get; set; }

        T GetAttributeValue<T>(string key);

   }

}
