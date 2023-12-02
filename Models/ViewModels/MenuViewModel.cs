﻿namespace NeatBurger.Models.ViewModels
{
    public class MenuViewModel
    {
        public HamburguesaModel Hamburguesa { get; set; } = null!;
        public IEnumerable<ClasificacionModel> Clasificaciones { get; set; } = Enumerable.Empty<ClasificacionModel>();
    }
}
