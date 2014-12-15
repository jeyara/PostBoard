using System.Collections.Generic;

namespace PostBoard.Framework.Common
{
    /// <summary>
    /// Base interface for each photos used in this system.
    /// This interface will be used to post in social media or just to display on this website it self.
    /// Trying to Stick to KISS principal as much as possible.
    /// </summary>
    public interface IBoardPhoto
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
        /// Url of the small size image
        /// </summary>
        string StampSizeUrl { get; set; }

        /// <summary>
        /// Url of the full size image
        /// </summary>
        string FullSizeUrl { get; set; }

        /// <summary>
        /// Alternative text to show in img tag
        /// </summary>
        string AltText { get; set; }

        /// <summary>
        /// will be used as # tags
        /// </summary>
        IList<string> HashTags { get; set; }

        /// <summary>
        /// No full idea on this. But this can be used to hold information like latitude or longitude etc.
        /// </summary>
        Dictionary<string, string> Attributes { get; set; }
   }

}
