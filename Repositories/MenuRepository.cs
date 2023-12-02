using Microsoft.EntityFrameworkCore;
using NeatBurger.Models.Entities;
using NuGet.Protocol.Core.Types;

namespace NeatBurger.Repositories
{
    public class MenuRepository(NeatContext context)
    {
        public IEnumerable<Menu> GetAll()
        {
            return context.Menu
            .Include(x => x.IdClasificacionNavigation)
            .OrderBy(x => x.IdClasificacionNavigation.Nombre)
            .ThenBy(x => x.Nombre);
        }

        public Menu? GetByNombre(string nombre)
        {
            return context.Menu
            .Include(x => x.IdClasificacionNavigation)
            .FirstOrDefault(x => x.Nombre == nombre);
        }
    }
}
