using Microsoft.AspNetCore.Mvc;
using NeatBurger.Areas.Admin.Models;
using NeatBurger.Areas.Admin.Models.ViewModels;
using NeatBurger.Repositories;

namespace NeatBurger.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController (ClasificacionRepository clasificacionRepository, MenuRepository menuRepository): Controller
    {
        ClasificacionRepository clasificacionRepository_ = clasificacionRepository;
        MenuRepository menuRepository_ = menuRepository;
        public IActionResult Index()
        {
            return View();
        }
        [Route ("Admin/menu")]
        public IActionResult Menu()
        {
            var vm = new MenuViewModel()
            {
                Clasificaciones = clasificacionRepository_
                .GetAll()
                .Select(x=>new ClasificacionModel()
                {
                    Id = x.Id,
                    Nombre=x.Nombre,
                    Menus=x.Menu.Select(x=>new MenuModel()
                    {
                        Id=x.Id,
                        Nombre=x.Nombre,
                        Descripcion=x.Descripción,
                        PrecioOriginal=(decimal)x.Precio,
                        PrecioFinal=(decimal?)x.PrecioPromocion
                    })
                })
            };
            return View(vm);
        }

        [Route("Admin/menu/agregar")]
        public IActionResult AgregarMenu()
        {
            var vm = new AgregarMenuViewModel()
            {
                clasificaciones = clasificacionRepository_.GetAll().Select(x => new ClasificacionModel()
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                })
            };
            return View(vm);
        }

        [HttpPost]
        [Route("Admin/menu/agregar")]
        public IActionResult AgregarMenu(AgregarMenuViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.Nombre)) ModelState.AddModelError(string.Empty, "El Campo Nombre no puede estar vacio");
            if (string.IsNullOrEmpty(vm.Descripcion)) ModelState.AddModelError(string.Empty, "El Campo Descripcion no puede estar vacio");
            if (vm.Precio == 0) ModelState.AddModelError(string.Empty, "El Precio no puede ser 0");
            if (vm?.Archivo?.Length > 500 * 1024) ModelState.AddModelError(string.Empty, "La imagen no puede pesar menos de 500kb");
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var enti
            return View();
        }
    }
}
