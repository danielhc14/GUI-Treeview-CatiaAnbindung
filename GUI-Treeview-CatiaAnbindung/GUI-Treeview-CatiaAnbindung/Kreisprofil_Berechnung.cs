using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Treeview_CatiaAnbindung
{
    class Kreisprofil_Berechnung
    {
        private double Pi = 3.14;
        private double flaeche;
        private double volumen;
        private double gewicht;
        private double Ixx;
        private double Iyy;
        private double Preis;
        private double dichte;
        private double laenge;

        public double Kreisprofil_Flaechenberechnung(double durchmesser)
        {
            flaeche = (durchmesser / 2.0) * (durchmesser / 2.0) * Pi;
            return flaeche;
        }

        public double Kreisprofil_Volumenberechnung(double durchmesser, double laenge)
        {
            flaeche = Kreisprofil_Flaechenberechnung(durchmesser);
            volumen = flaeche * laenge;
            return volumen;
        }

        public double Kreisprofil_Massenberechnung(double durchmesser, double laenge, double dichte)
        {
            volumen = Kreisprofil_Volumenberechnung(durchmesser, laenge);
            gewicht = volumen * dichte;
            return gewicht;
        }

        public double Kreisprofil_Flaechentraegheit_Ixx(double durchmesser)
        {
            Ixx = (Pi * durchmesser * durchmesser * durchmesser * durchmesser) / 64;
            return Ixx;
        }

        public double Kreisprofil_Flaechentraegheit_Iyy(double durchmesser)
        {
            Iyy = (Pi * durchmesser * durchmesser * durchmesser * durchmesser) / 64;
            return Iyy;
        }

        public double Kreisprofil_Preisberechnung(double durchmesser, double laenge, double dichte, double kosten)
        {
            gewicht = Kreisprofil_Massenberechnung(durchmesser, laenge, dichte);
            Preis = gewicht * kosten;
            return Preis;
        }
    }
}
