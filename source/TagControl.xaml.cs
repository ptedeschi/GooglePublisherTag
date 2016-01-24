//-----------------------------------------------------------------------
// Copyright (c) 2016 Patrick Tedeschi
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
    using Windows.UI.Xaml.Controls;

    public sealed partial class TagControl : UserControl
    {
        /// <summary>
        /// This is a sample class
        /// </summary>
        private const string RawData = "<html><head><script type='text/javascript'>var googletag = googletag || {};googletag.cmd = googletag.cmd || [];(function() {var gads = document.createElement('script');gads.async = true;gads.type = 'text/javascript';var useSSL = 'https:' == document.location.protocol;gads.src = (useSSL ? 'https:' : 'http:') +'//www.googletagservices.com/tag/js/gpt.js';var node = document.getElementsByTagName('script')[0];node.parentNode.insertBefore(gads, node);})();googletag.cmd.push(function() {googletag.defineSlot('[##ADUNIT##]', [[##WIDTH##], [##HEIGHT##]], 'div-google-ads').addService(googletag.pubads());googletag.pubads().enableSingleRequest();googletag.enableServices();});</script><style type='text/css'>body {margin:0;border: none;overflow:hidden;}</style></head><body><div id='div-google-ads' style='width:[##WIDTH##]px;height:[##HEIGHT##]px;'><script type='text/javascript'>googletag.cmd.push(function() {googletag.display('div-google-ads');});</script></div></body></html>";

        public TagControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This is a sample class for testing
        /// </summary>
        /// <param name="adunit">The parameter is not used.</param>
        /// <param name="width">The parameter is not used.</param>
        /// <param name="height">The parameter is not used.</param>
        public void Load(string adunit, double width, double height)
        {
            if (string.IsNullOrWhiteSpace(adunit) || width < 0 || height < 0)
            {
                throw new ArgumentException();
            }

            string data = RawData;
            data = data.Replace("[##ADUNIT##]", adunit);
            data = data.Replace("[##WIDTH##]", width.ToString());
            data = data.Replace("[##HEIGHT##]", height.ToString());

            this.webView.Width = width;
            this.webView.Height = height;
            this.webView.NavigateToString(data);
        }
    }
}
