using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.Links;

namespace UrlOptionsSwitcher.Test
{
    [TestClass]
    public class UrlOptionsSwitcherTest
    {
        [TestMethod]
        public void UrlOptionsSwitcher_SwitchesDefaultUrlOptions()
        {
            // Create new URL options
            var urlOptions = new UrlOptions {
                AddAspxExtension =true,
                AlwaysIncludeServerUrl = true,
                EncodeNames = true,
                SiteResolving = true,
                LowercaseUrls = true,
                ShortenUrls = true,
                UseDisplayName = true
            };

            // Use the switcher to enter new context
            using (new UrlOptionsSwitcher(urlOptions))
            {
                // Verify that the default url options in all instances of the linkprovider return the same url options
                // when inside the switcher
                Assert.IsTrue(AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions));
                Assert.IsTrue(AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions));
            }
        }

        [TestMethod]
        public void UrlOptionsSwitcher_ReturnsToPreviousState()
        {
            // Create new URL options
            var urlOptions = new UrlOptions
            {
                AddAspxExtension = true,
                AlwaysIncludeServerUrl = true,
                EncodeNames = true,
                SiteResolving = true,
                LowercaseUrls = true,
                ShortenUrls = true,
                UseDisplayName = true
            };

            // Note: We can not easily compare the DefaultUrlOptions since GetDefaultUrlOptions() clones the options
            // Fails: Assert.AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), new SwitchableLinkProvider().GetDefaultUrlOptions());

            Assert.IsFalse(AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions));

            // Use the switcher to enter new context
            using (new UrlOptionsSwitcher(urlOptions))
            {
                // Nothing to do
            }

            Assert.IsFalse(AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions));
        }

        [TestMethod]
        public void UrlOptionsSwitcher_CanBeNested()
        {
            // Create new URL options
            var urlOptions1 = new UrlOptions
            {
                AddAspxExtension = true,
                AlwaysIncludeServerUrl = true,
                EncodeNames = true,
                SiteResolving = true,
                LowercaseUrls = true,
                ShortenUrls = true,
                UseDisplayName = true
            };
            // options with everything set to false:
            var urlOptions2 = new UrlOptions();

            // Use the switcher to enter new context
            using (new UrlOptionsSwitcher(urlOptions1))
            {
                // Verify that the default url options in all instances of the linkprovider return the same url options
                // when inside the switcher
                Assert.IsTrue(AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions1));
                using (new UrlOptionsSwitcher(urlOptions2))
                {
                    // Verify that the default url options in all instances of the linkprovider return the same url options
                    // when inside the switcher
                    Assert.IsTrue(AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions2));
                }
                Assert.IsTrue(AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions1));
            }
        }

        [TestMethod]
        public void UrlOptionsSwitcher_UrlOptionsAreCloned()
        {
            // Create new URL options
            var urlOptions = new UrlOptions
            {
                AddAspxExtension = true,
                AlwaysIncludeServerUrl = true,
                EncodeNames = true,
                SiteResolving = true,
                LowercaseUrls = true,
                ShortenUrls = true,
                UseDisplayName = true
            };

            // Use the switcher to enter new context
            using (new UrlOptionsSwitcher(urlOptions))
            {
                // Verify that the default url options in all instances of the linkprovider return the same url options
                // when inside the switcher
                Assert.IsTrue(AreEqual(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions));
                Assert.AreNotSame(new SwitchableLinkProvider().GetDefaultUrlOptions(), urlOptions);
            }
        }

        /// <summary>
        /// Helper to compare UrlOptions
        /// </summary>
        /// <param name="options1"></param>
        /// <param name="options2"></param>
        /// <returns></returns>
        private bool AreEqual(UrlOptions options1, UrlOptions options2)
        {
            if (options1 == null || options2 == null)
                return options1 == options2;

            return options1.AddAspxExtension == options2.AddAspxExtension
                && options1.AlwaysIncludeServerUrl == options2.AlwaysIncludeServerUrl
                && options1.EncodeNames == options2.EncodeNames
                && options1.SiteResolving == options2.SiteResolving
                && options1.LowercaseUrls == options2.LowercaseUrls
                && options1.ShortenUrls == options2.ShortenUrls
                && options1.UseDisplayName == options2.UseDisplayName;
        }
    }
}
