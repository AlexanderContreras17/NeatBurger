namespace NeatBurger.Areas.Admin.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal PrecioOriginal { get; set; }
        public decimal? PrecioFinal { get; set; }

    }
}
