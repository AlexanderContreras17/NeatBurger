namespace NeatBurger.Models.ViewModels
{
    public class ClasificacionModel
    {
        public string Nombre { get; set; } = null!;
        public IEnumerable<HamburguesaModel> Hamburguesas { get; set; } = Enumerable.Empty<HamburguesaModel>();
    }
}
