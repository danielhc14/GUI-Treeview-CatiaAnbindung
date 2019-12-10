using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Treeview_CatiaAnbindung
{
    class Rechteckberechnung
    {
        private double flaeche;
        private double volumen;
        private double gewicht;
        private double preis;
        private double Ixx;
        private double Iyy;
        public double Rechteck_Flaechenberechnung(double laenge, double breite)
        {
            flaeche = laenge * breite;
            return flaeche;
        }

        public double Rechteck_Volumenberechnung(double laenge, double breite, double tiefe)
        {
            flaeche = Rechteck_Flaechenberechnung(laenge, breite);
            volumen = flaeche * tiefe;
            return volumen;
        }

        public double Rechteck_Massenberechnung(double laenge, double breite, double tiefe, double dichte)
        {
            volumen = Rechteck_Volumenberechnung(laenge, breite, tiefe);
            gewicht = volumen * dichte;
            return gewicht;
        }

        public double Rechteck_Preis(double laenge, double breite, double tiefe, double dichte, double kosten)
        {
            gewicht = Rechteck_Massenberechnung(laenge, breite, tiefe, dichte);
            preis = gewicht * kosten;
            return preis;
        }
        public double Rechteck_Flächenträgheit_Ixx(double laenge, double breite)
        {
            Ixx = (breite * laenge * laenge * laenge) / 12;
            return Ixx;
        }

        public double Rechteck_Flächenträgheit_Iyy(double laenge, double breite)
        {
            Iyy = (laenge * breite * breite * breite) / 12;
            return Iyy;
        }
    }
}
