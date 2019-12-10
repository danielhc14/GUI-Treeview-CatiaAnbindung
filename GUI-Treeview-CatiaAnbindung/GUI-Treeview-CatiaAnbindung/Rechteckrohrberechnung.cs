using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Treeview_CatiaAnbindung
{
    class Rechteckrohrberechnung
    {
        private double flaeche;
        private double volumen;
        private double gewicht;
        private double preis;
        private double Ixx;
        private double Iyy;

        public double FlaecheRechteckRohr(double breite, double laenge, double breite2, double laenge2)
        {
            flaeche = laenge * breite - laenge2 * breite2;
            return flaeche;
        }

        public double VolumenRechteckRohr(double breite, double laenge, double breite2, double laenge2, double tiefe)
        {

            flaeche = FlaecheRechteckRohr(breite, laenge, breite2, laenge2);
            volumen = flaeche * tiefe;
            return volumen;
        }

        public double DichteRechteckRohr(double breite, double laenge, double breite2, double laenge2, double tiefe, double dichte)
        {
            volumen = VolumenRechteckRohr(breite, laenge, breite2, laenge2, tiefe);
            gewicht = volumen * dichte;
            return gewicht;
        }

        public double PreisRechteckRohr(double breite, double laenge, double breite2, double laenge2, double tiefe, double dichte, double kosten)
        {
            gewicht = DichteRechteckRohr(breite, laenge, breite2, laenge2, tiefe, dichte);
            preis = gewicht * kosten;
            return preis;
        }
        public double IxxRechteckrohr(double breite, double laenge, double laenge2, double breite2)
        {
            Ixx = ((breite * laenge * laenge * laenge) - (breite2 * laenge2 * laenge2 * laenge2)) / 12;
            return Ixx;
        }

        public double IyyRechteckrohr(double breite, double laenge, double laenge2, double breite2)
        {
            Iyy = ((laenge * breite * breite * breite) - (laenge2 * breite2 * breite2 * breite2)) / 12;
            return Iyy;
        }
    }
}
