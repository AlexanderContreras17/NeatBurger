﻿namespace NeatBurger.Areas.Admin.Models.ViewModels
{
    public class QuitarPromocionViewModel
    {
        public int IdMenu { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal PrecioOriginal {  get; set; }
        public decimal PrecioFinal { get; set; }
    }
}
