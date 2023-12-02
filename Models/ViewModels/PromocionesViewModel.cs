namespace NeatBurger.Models.ViewModels
{
    public class PromocionesViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal PrecioOriginal { get;set; }
        public decimal PrecioFinal { get;set;}
        public string PromocionSiguiente { get; set; } = null!;
        public string PromocionAnterior {  get; set; }=null!;

    }
}
