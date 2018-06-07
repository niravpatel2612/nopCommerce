using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.DiscountMessage.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Widgets.DiscountMessage.Components
{
    [ViewComponent(Name = "WidgetsDiscountMessage")]
    public class WidgetsDiscountMessageComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;
        private readonly ISettingService _settingService;

        public WidgetsDiscountMessageComponent(IStoreContext storeContext,
            IStaticCacheManager cacheManager,
            ISettingService settingService)
        {
            this._storeContext = storeContext;
            this._cacheManager = cacheManager;
            this._settingService = settingService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var discountMessageSettings = _settingService.LoadSetting<DiscountMessageSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                DiscountMessageText = discountMessageSettings.DiscountMessageText
            };

            if (string.IsNullOrEmpty(model.DiscountMessageText))
                //no message found
                return Content("");

            return View("~/Plugins/Widgets.DiscountMessage/Views/PublicInfo.cshtml", model);
        }
    }
}
