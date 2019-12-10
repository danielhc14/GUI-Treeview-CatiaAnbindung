using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_Treeview_CatiaAnbindung
{
    class Rechteck
    {
        GUI callingGUI;
        Rechteckberechnung Berechnung = new Rechteckberechnung();
        private double laenge;
        private double breite;
        private double tiefe;
        private double flaeche;
        private double volumen;
        private double dichte;
        private double gewicht;
        private double kosten;
        private double preis;
        private double Ixx;
        private double Iyy;

        public Rechteck(GUI sender, double laenge1, double breite1, double tiefe1, double dichte1, double kosten1)
        {
            laenge = laenge1;
            breite = breite1;
            tiefe = tiefe1;
            dichte = dichte1;
            kosten = kosten1;
            callingGUI = sender;

        }

        public void setFläche(double laenge_1, double breite_1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge_1 > 0 & breite_1 > 0)
            {
                flaeche = Berechnung.Rechteck_Flaechenberechnung(laenge_1, breite_1);
                //Ergebnis auf 2 Nachkommastellen runden
                flaeche = Math.Round(flaeche, 2);
                callingGUI.txtB_Ausgabe_Flaeche.Text = Convert.ToString(flaeche);

            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Flaeche.Text = "Fehler!";
            }
        }

        public double getFläche()
        {
            return flaeche;
        }

        public void setVolumen(double laenge1, double breite1, double tiefe1)
        {

            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0 & tiefe1 > 0)
            {
                volumen = Berechnung.Rechteck_Volumenberechnung(laenge1, breite1, tiefe1);
                //Ergebnis auf 2 Nachkommastellen runden
                volumen = Math.Round(volumen, 2);
                callingGUI.txtB_Ausgabe_Volumen.Text = Convert.ToString(volumen);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Volumen.Text = "Fehler!";
            }
        }
        public double getVolumen()
        {
            return volumen;
        }

        public void setGewicht(double laenge1, double breite1, double tiefe1, double dichte1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0 & tiefe1 > 0 & dichte1 > 0)
            {
                gewicht = Berechnung.Rechteck_Massenberechnung(laenge1, breite1, tiefe1, dichte1);
                //Ergebnis auf 2 Nachkommastellen runden
                gewicht = Math.Round(gewicht, 2);
                callingGUI.txtB_Ausgabe_Gewicht.Text = Convert.ToString(gewicht);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Gewicht.Text = "Fehler!";
            }
        }
        public double getGewicht()
        {
            return gewicht;
        }
        public void setPreis(double laenge1, double breite1, double tiefe1, double dichte1, double kosten1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0 & tiefe1 > 0 & dichte1 > 0 & kosten1 > 0)
            {
                preis = Berechnung.Rechteck_Preis(laenge1, breite1, tiefe1, dichte1, kosten1);
                //Ergebnis auf 2 Nachkommastellen runden
                preis = Math.Round(preis, 2);
                callingGUI.txtB_Ausgabe_Preis.Text = Convert.ToString(preis);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Preis.Text = "Fehler!";
            }
        }
        public double getPreis()
        {
            return preis;
        }
        public void setFlächenträgheitsmoment(double laenge1, double breite1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0)
            {
                Ixx = Berechnung.Rechteck_Flächenträgheit_Ixx(laenge1, breite1);
                //Ergebnis auf 2 Nachkommastellen runden
                Ixx = Math.Round(Ixx, 2);
                callingGUI.txtB_Ausgabe_Ixx.Text = Convert.ToString(Ixx);

                Iyy = Berechnung.Rechteck_Flächenträgheit_Iyy(laenge1, breite1);
                //Ergebnis auf 2 Nachkommastellen runden
                Iyy = Math.Round(Iyy, 2);
                callingGUI.txtB_Ausgabe_Iyy.Text = Convert.ToString(Iyy);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Ixx.Text = "Fehler!";
                callingGUI.txtB_Ausgabe_Iyy.Text = "Fehler!";
            }
        }
        public double getFlächenträgheitsmomentIxx()
        {
            return Ixx;
        }
        public double getFlächenträgheitsmomentIyy()
        {
            return Iyy;
        }
        public void deleteGrid()
        {
            //TextBoxen mit leerem String füllen
            callingGUI.txtB_Ausgabe_Flaeche.Text = "";
            callingGUI.txtB_Ausgabe_Gewicht.Text = "";
            callingGUI.txtB_Ausgabe_Ixx.Text = "";
            callingGUI.txtB_Ausgabe_Iyy.Text = "";
            callingGUI.txtB_Ausgabe_Preis.Text = "";
            callingGUI.txtB_Ausgabe_Volumen.Text = "";
            callingGUI.txtB_Breite.Text = "";
            callingGUI.txtB_dichte.Text = "";
            callingGUI.txtB_Länge.Text = "";
            callingGUI.txtB_Preis.Text = "";
            callingGUI.txtB_tiefe.Text = "";
            //Farbe der Textboxen auf die ursprüungliche Farbe zurücksetzen
            callingGUI.txtB_Breite.Background = Brushes.White;
            callingGUI.txtB_dichte.Background = Brushes.White;
            callingGUI.txtB_Länge.Background = Brushes.White;
            callingGUI.txtB_Preis.Background = Brushes.White;
            callingGUI.txtB_tiefe.Background = Brushes.White;
        }
        public void setLänge(double laenge1)
        {
            //setzen der Länge (für Catia benötigt)
            laenge = laenge1;
        }
        public double getLänge()
        {
            //Holen der Länge, um dies an Catia zu übertragen
            return laenge;
        }
        public void setBreite(double breite1)
        {
            //setzen der Breite (für Catia benötigt)
            breite = breite1;
        }
        public double getBreite()
        {
            //Holen der Breite, um dies an Catia zu übertragen
            return breite;
        }
        public void setTiefe(double tiefe1)
        {
            //setzen der Tiefe (für Catia benötigt)
            tiefe = tiefe1;
        }
        public double getTiefe()
        {
            //Holen der Tiefe, um dies an Catia zu übertragen
            return tiefe;
        }
    }
}
