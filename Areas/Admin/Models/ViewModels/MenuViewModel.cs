using NeatBurger.Models.ViewModels;

namespace NeatBurger.Areas.Admin.Models.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<ClasificacionModel> Clasificaciones { get; set; }
            = Enumerable.Empty<ClasificacionModel>();
    }
}
