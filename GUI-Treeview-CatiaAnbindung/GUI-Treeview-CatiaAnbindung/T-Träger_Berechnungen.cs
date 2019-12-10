using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Treeview_CatiaAnbindung
{
    class T_Träger_Berechnungen
    {
        private double flaeche;
        private double volumen;
        private double höhe_2;
        private double breite_2;
        private double flaeche_innen;
        private double gewicht;
        private double preis;
        private double Ixx;
        private double Iyy;


        public double Flaechenberechnung(double breite, double höhe, double t, double s)
        {
            flaeche = breite * höhe;
            höhe_2 = höhe - (2 * t);
            breite_2 = (breite / 2) - s / 2;
            flaeche_innen = 2 * höhe_2 * breite_2;
            flaeche = flaeche - flaeche_innen;
            return flaeche;
        }

        public double Volumenberechnung(double breite, double höhe, double t, double s, double tiefe)
        {
            flaeche = Flaechenberechnung(breite, höhe, t, s);
            volumen = flaeche * tiefe;
            return volumen;
        }

        public double Gewichtsberechnung(double breite, double höhe, double t, double s, double tiefe, double dichte)
        {
            volumen = Volumenberechnung(breite, höhe, t, s, tiefe);
            gewicht = volumen * dichte;
            return gewicht;
        }

        public double Preisberechnung(double breite, double höhe, double t, double s, double tiefe, double dichte, double kosten)
        {
            gewicht = Gewichtsberechnung(breite, höhe, t, s, tiefe, dichte);
            preis = kosten * gewicht;
            return preis;
        }

        public double Flächenträgheitsmoment_Ixx(double breite, double höhe, double t, double s)
        {
            höhe_2 = höhe - (2 * t);
            breite_2 = (breite / 2) - s / 2;
            Ixx = ((breite * höhe * höhe * höhe) / 12) - 2 * (breite_2 * höhe_2 * höhe_2 * höhe_2 / 12);
            return Ixx;
        }

        public double Flächenträgheitsmoment_Iyy(double breite, double höhe, double t, double s)
        {
            höhe_2 = höhe - (2 * t);
            breite_2 = (breite / 2) - s / 2;
            Iyy = ((höhe * breite * breite * breite) / 12) - 2 * ((höhe_2 * breite_2 * breite_2 * breite_2 / 12) + (höhe_2 * breite_2 * (breite_2 / 2 + s / 2) * (breite_2 / 2 + s / 2)));
            return Iyy;
        }
    }
}
