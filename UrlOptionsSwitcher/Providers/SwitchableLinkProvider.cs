using Sitecore.Links;

namespace UrlOptionsSwitcher
{
    /// <summary>
    /// We need to change the original sitecore linkprovider just a tiny bit
    /// </summary>
    public class SwitchableLinkProvider : LinkProvider
    {
        /// <summary>
        /// The default url options are now taken from the switcher if applicable, else the default options are used
        /// </summary>
        /// <returns>The switched UrlOptions or the default ones</returns>
        public override UrlOptions GetDefaultUrlOptions()
        {
            return UrlOptionsSwitcher.CurrentValue?.Clone() as UrlOptions ?? base.GetDefaultUrlOptions();
        }
    }
}
