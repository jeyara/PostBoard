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
        /// Full path of the image including domain and file extension
        /// </summary>
        string FullUrl { get; set; }

        /// <summary>
        /// A Short Introduction about the image
        /// </summary>
        string Caption { get; set; }
        
        /// <summary>
        /// will be used as # tags
        /// </summary>
        IList<string> Keywords { get; set; }

        /// <summary>
        /// No full idea on this. But this can be used to hold information like latitude or longitude etc.
        /// </summary>
        Dictionary<string, string> CustomData { get; set; }
    }
}
