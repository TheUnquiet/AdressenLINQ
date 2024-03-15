using System;

namespace BL.models
{
    public class Adres
    {
        public string Provincie { get; set; }
        public string Gemeente { get; set; }
        public string StraatNaam { get; set; }

        public Adres(string provincie, string gemeente, string straatNaam)
        {
            Provincie = provincie;
            Gemeente = gemeente;
            StraatNaam = straatNaam;
        }
    }
}
