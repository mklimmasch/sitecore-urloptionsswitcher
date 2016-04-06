using Sitecore.Common;
using Sitecore.Links;

namespace UrlOptionsSwitcher
{
    /// <summary>
    /// The UrlOptionsSwitcher is actually just a switcher for UrlOtpions
    /// </summary>
    public class UrlOptionsSwitcher : Switcher<UrlOptions> {
        public UrlOptionsSwitcher(UrlOptions urlOptions): base(urlOptions) { }
    }
}
