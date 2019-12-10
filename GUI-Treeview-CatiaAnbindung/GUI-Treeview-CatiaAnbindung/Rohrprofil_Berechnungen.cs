using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Treeview_CatiaAnbindung
{
    class Rohrprofil_Berechnungen
    {
        private double flaeche;
        private double volumen;
        private double laenge;
        private double gewicht;
        private double dichte;
        private string i;
        private double aussendurchmesser;
        private double innendurchmesser;
        private double Ixx;
        private double Iyy;
        private double Pi = Math.PI;
        private double kosten;
        private double preis;

        public double Rohrprofil_Flaechenberechnung(double aussendurchmesser, double innendurchmesser)
        {
            flaeche = ((aussendurchmesser * aussendurchmesser * Pi) - (innendurchmesser * innendurchmesser * Pi)) / 4;
            return flaeche;

        }
        public double Rohrprofil_Volumenberechnung(double aussendurchmesser, double innendurchmesser, double tiefe)
        {
            flaeche = Rohrprofil_Flaechenberechnung(aussendurchmesser, innendurchmesser);
            volumen = flaeche * tiefe;
            return volumen;

        }
        public double Rohrprofil_Gewichtsberechnung(double aussendurchmesser, double innendurchmesser, double tiefe, double dichte)
        {
            volumen = Rohrprofil_Volumenberechnung(aussendurchmesser, innendurchmesser, tiefe);
            gewicht = volumen * dichte;
            return gewicht;

        }
        public double Rohrprofil_Preisberechnung(double aussendurchmesser, double innendurchmesser, double tiefe, double dichte, double kosten)
        {
            gewicht = Rohrprofil_Gewichtsberechnung(aussendurchmesser, innendurchmesser, tiefe, dichte);
            preis = gewicht * kosten;
            return preis;
        }
        public double Rohrprofil_Flaechentraegheit_Ixx(double aussendurchmesser, double innendurchmesser)
        {
            Ixx = ((aussendurchmesser * aussendurchmesser * aussendurchmesser * aussendurchmesser) - (innendurchmesser * innendurchmesser * innendurchmesser * innendurchmesser)) * (Pi / 64);
            return Ixx;

        }
        public double Rohrprofil_Flaechentraegheit_Iyy(double aussendurchmesser, double innendurchmesser)
        {
            Iyy = ((aussendurchmesser * aussendurchmesser * aussendurchmesser * aussendurchmesser) - (innendurchmesser * innendurchmesser * innendurchmesser * innendurchmesser)) * (Pi / 64);
            return Iyy;
        }
    }
}
