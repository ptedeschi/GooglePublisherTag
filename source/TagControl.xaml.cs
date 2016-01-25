//-----------------------------------------------------------------------
// <copyright file="TagControl.xaml.cs" company="Patrick Tedeschi">
//     Copyright (c) 2016 Patrick Tedeschi
// </copyright>
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//-----------------------------------------------------------------------
namespace GooglePublisherTag
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// User control responsible for load the ads from Google Publisher Tag.
    /// </summary>
    public sealed partial class TagControl : UserControl
    {
        /// <summary>
        /// Tag dependency property.
        /// </summary>
        public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(string), typeof(string), null);

        /// <summary>
        /// Width dependency property.
        /// </summary>
        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(double), null);

        /// <summary>
        /// Height dependency property.
        /// </summary>
        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(double), typeof(double), null);

        /// <summary>
        /// Raw HTML data example of an asynchronous Google Publisher Tag.
        /// </summary>
        private const string RawData = "<html><head><script type='text/javascript'>var googletag = googletag || {};googletag.cmd = googletag.cmd || [];(function() {var gads = document.createElement('script');gads.async = true;gads.type = 'text/javascript';var useSSL = 'https:' == document.location.protocol;gads.src = (useSSL ? 'https:' : 'http:') +'//www.googletagservices.com/tag/js/gpt.js';var node = document.getElementsByTagName('script')[0];node.parentNode.insertBefore(gads, node);})();googletag.cmd.push(function() {googletag.defineSlot('[##TAG##]', [[##WIDTH##], [##HEIGHT##]], 'div-google-ads').addService(googletag.pubads());googletag.pubads().enableSingleRequest();googletag.enableServices();});</script><style type='text/css'>body {margin:0;border: none;overflow:hidden;}</style></head><body><div id='div-google-ads' style='width:[##WIDTH##]px;height:[##HEIGHT##]px;'><script type='text/javascript'>googletag.cmd.push(function() {googletag.display('div-google-ads');});</script></div></body></html>";

        /// <summary>
        /// Initializes a new instance of the TagControl class.
        /// </summary>
        public TagControl()
        {
            this.InitializeComponent();

            // Loads the ads from Google Publisher Tag
            this.Load();
        }

        /// <summary>
        /// Gets or sets the Tag property.
        /// The Tag value will have the form /NetworkCode/AdUnitCode.
        /// </summary>
        public string Tag
        {
            get { return this.GetValue(TagProperty) as string; }
            set { this.SetValue(TagProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Width property.
        /// This value will be the width size that the element will take.
        /// </summary>
        public double Width
        {
            get { return (double)this.GetValue(WidthProperty); }
            set { this.SetValue(WidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Height property.
        /// This value will be the height size that the element will take.
        /// </summary>
        public double Height
        {
            get { return (double)this.GetValue(HeightProperty); }
            set { this.SetValue(HeightProperty, value); }
        }

        /// <summary>
        /// Loads the ads from Google Publisher Tag.
        /// The properties Tag, Width and Height must be filled.
        /// </summary>
        public void Load()
        {
            string tag = this.Tag;
            double width = this.Width;
            double height = this.Height;

            if (!string.IsNullOrWhiteSpace(tag) && width > 0 && height > 0)
            {
                string data = RawData;
                data = data.Replace("[##TAG##]", tag);
                data = data.Replace("[##WIDTH##]", width.ToString());
                data = data.Replace("[##HEIGHT##]", height.ToString());

                this.webView.Width = width;
                this.webView.Height = height;
                this.webView.NavigateToString(data);
            }
        }

        /// <summary>
        /// Loads the ads from Google Publisher Tag.
        /// </summary>
        /// <param name="tag">The tag value value. It will have the form /NetworkCode/AdUnitCode.</param>
        /// <param name="width">The width size that the element will take.</param>
        /// <param name="height">The height size that the element will take.</param>
        [Obsolete("Use the properties instead")]
        public void Load(string tag, double width, double height)
        {
            if (!string.IsNullOrWhiteSpace(tag) && width > 0 && height > 0)
            {
                string data = RawData;
                data = data.Replace("[##TAG##]", tag);
                data = data.Replace("[##WIDTH##]", width.ToString());
                data = data.Replace("[##HEIGHT##]", height.ToString());

                this.webView.Width = width;
                this.webView.Height = height;
                this.webView.NavigateToString(data);
            }
        }
    }
}