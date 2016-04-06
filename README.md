# sitecore-urloptionsswitcher
Switcher for Sitecore UrlOptions

## Usage
Use this Switcher to temporarily override UrlOptions for Sitecore.

```csharp
var linkoptions = LinkManager.GetDefaultUrlOptions();
linkoptions.LanguageEmbedding = LanguageEmbedding.Never;
linkoptions.SiteResolving = false;

using (new UrlOptionsSwitcher(urlOptions))
{
  // Do stuff here
}
```

## Setup
Replace the original Sitecore LinkProvider with the one one in this project (See SwitchLinkProvider.config).

```xml
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>

    <!-- Make UrlOptions Switchable -->
    <linkManager>
      <providers>
        <add name="sitecore">
          <patch:attribute name="type">UrlOptionsSwitcher.SwitchableLinkProvider, UrlOptionsSwitcher</patch:attribute>
        </add>
      </providers>
    </linkManager>
    
  </sitecore>
</configuration>
```

## Alternative
Sitecore introduced a LinkProviderSwitcher, which can be alternatively used.
