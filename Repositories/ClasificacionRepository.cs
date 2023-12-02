
using Microsoft.EntityFrameworkCore;
using NeatBurger.Models.Entities;

namespace NeatBurger.Repositories

{
    public class ClasificacionRepository(NeatContext context)
    {
      //  public ClasificacionRepository(NeatContext context) : base(context) { }
        public IEnumerable<Clasificacion> GetAll()
        {
            return context.Clasificacion
                .Include(x => x.Menu)
                .OrderBy(x => x.Nombre);

        }

    }
}
