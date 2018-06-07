using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.DiscountMessage.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        
        [NopResourceDisplayName("Plugins.Widgets.DiscountMessage.Text")]
        public string DiscountMessageText { get; set; }
        public bool DiscountMessageText_OverrideForStore { get; set; }
    }
}