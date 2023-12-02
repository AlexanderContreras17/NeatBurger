using Microsoft.AspNetCore.Mvc;
using NeatBurger.Models.ViewModels;
using NeatBurger.Repositories;

namespace NeatBurger.Controllers
{
    public class HomeController(MenuRepository menuRepository) : Controller
    {
        MenuRepository menuRepository_ = menuRepository;
        public IActionResult Index()
        {
            return View();
        }

        [Route("menu")]
        public IActionResult Menu()
        {
            var vm = new MenuViewModel()
            {
                Clasificaciones = menuRepository_.GetAll()
                .GroupBy(x => x.IdClasificacionNavigation)
                .Select(x => new ClasificacionModel
                {
                    Nombre = x.Key.Nombre,
                    Hamburguesas = x.Select(x => new HamburguesaModel
                    {
                        Id = x.Id,
                        Descripcion = x.Descripción,
                        Nombre = x.Nombre,
                        Precio = x.PrecioPromocion is null ? (decimal)x.Precio : (decimal)x.PrecioPromocion
                    }).ToList()
                }).ToList()
            };
            vm.Clasificaciones.First()
                .Hamburguesas.First().Seleccionado = true;
            vm.Hamburguesa = vm.Clasificaciones
                 .SelectMany(x => x.Hamburguesas).First(x => x.Seleccionado);

            return View(vm);
        }
        [Route("menu/{Id}")]
        public IActionResult Menu(string Id)
        {
            Id = Id.Replace("-", " ");
            var menu = menuRepository_.GetByNombre(Id);

            if(menu == null)
            {
                return RedirectToAction("Index");
            }

            var vm = new MenuViewModel()
            {
                Clasificaciones = menuRepository_.GetAll()
                .GroupBy(x => x.IdClasificacionNavigation)
                .Select(x => new ClasificacionModel
                {
                    Nombre = x.Key.Nombre,
                    Hamburguesas = x.Select(x =>
                    new HamburguesaModel
                    {
                        Id = x.Id,
                        Descripcion = x.Descripción,
                        Nombre = x.Nombre,
                        Precio = x.PrecioPromocion == null ? (decimal)x.Precio : (decimal)x.PrecioPromocion,
                        Seleccionado = x.Id == menu.Id
                    })
                })
            };
            vm.Hamburguesa = vm.Clasificaciones.SelectMany(x => x.Hamburguesas).First(x => x.Seleccionado);
           
            return View(vm);
        }
        [Route("Promociones")]
        public IActionResult Promociones()
        {
            var datos = menuRepository_.GetAll().Where(x=> x.PrecioPromocion != null).ToList();

            if (datos.Any())
            {
                return RedirectToAction("Index");
            }
            var promocion = datos.First();
            var vm = new PromocionesViewModel()
            {
                id = promocion.Id,
                Nombre = promocion.Nombre,
                Descripcion = promocion.Descripción,
                PrecioOriginal = (decimal)promocion.Precio,
                PrecioFinal = (decimal)promocion.PrecioPromocion!,


            };
            return View(vm);
        }




        [Route("promociones/{Id}")]
        public IActionResult Promociones(string Id)
        {
            Id = Id.Replace("-", " ");
            var datos = menuRepository_.GetAll().Where(x=>x.PrecioPromocion == null!).ToList();
            if(datos == null || !datos.Any())
            {
                return RedirectToAction("Index");
            }

            var promocion = datos.FirstOrDefault(x=>x.Nombre==Id);
            if(promocion == null)
            {
                return RedirectToAction("Index");
            }
            var vm = new PromocionesViewModel()
            {
                id=promocion.Id,
                Nombre=promocion.Nombre,
                Descripcion=promocion.Descripción,
                 PrecioFinal=(decimal)promocion.PrecioPromocion!,
                 PrecioOriginal=(decimal)promocion.Precio,
                  PromocionAnterior=datos.ElementAtOrDefault(datos.IndexOf(promocion)-1)?.Nombre?? promocion.Nombre,
                  PromocionSiguiente=datos.ElementAtOrDefault(datos.IndexOf(promocion)+1)?.Nombre?? promocion.Nombre

            };
            return View(vm);
        }
    }
}
