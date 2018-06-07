using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Widgets.DiscountMessage
{
    public class DiscountMessagePlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        public DiscountMessagePlugin(ISettingService settingService, IWebHelper webHelper)
        {
            this._settingService = settingService;
            this._webHelper = webHelper;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsOverviewTop };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsDiscountMessage/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsDiscountMessage";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new DiscountMessageSettings
            {
                DiscountMessageText = "50% discount in December"
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.DiscountMessage.PanelHeading", "Discount Message");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.DiscountMessage.Text", "Product Details");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.DiscountMessage.Text.Hint", "This message will appear in product details page in public store.");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<DiscountMessageSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.DiscountMessage.PanelHeading");
            this.DeletePluginLocaleResource("Plugins.Widgets.DiscountMessage.Text");
            this.DeletePluginLocaleResource("Plugins.Widgets.DiscountMessage.Text.Hint");

            base.Uninstall();
        }
    }
}
