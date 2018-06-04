using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Customer
{
    public partial class CheckGiftCardBalanceModel : BaseNopModel
    {
        public string Result { get; set; }

        public string Message { get; set; }
    }
}
