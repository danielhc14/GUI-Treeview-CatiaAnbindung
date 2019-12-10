using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_Treeview_CatiaAnbindung
{
    class Doppel_T_Träger
    {
        GUI callingGUI;
        T_Träger_Berechnungen berechnung = new T_Träger_Berechnungen();
        Überprüfung überprüfen = new Überprüfung();
        private double breite;
        private double höhe;
        private double s;
        private double t;
        private double tiefe;
        private double dichte;
        private double kosten;
        private double flaeche;
        private double volumen;
        private double gewicht;
        private double preis;
        private double Ixx;
        private double Iyy;
        private String eingabe;
        private double zahl;


        public Doppel_T_Träger(GUI sender, double breite1, double höhe1, double t1, double s1, double tiefe1, double dichte1, double kosten1)
        {
            callingGUI = sender;
            breite = breite1;
            höhe = höhe1;
            s = s1;
            t = t1;
            tiefe = tiefe1;
            dichte = dichte1;
            kosten = kosten1;
        }

        public void setFläche(double breite1, double höhe1, double t1, double s1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (breite1 > 0 & höhe1 > 0 & s1 > 0 & t1 > 0)
            {
                flaeche = berechnung.Flaechenberechnung(breite1, höhe1, t1, s1);
                //Ergebnis auf 2 Nachkommastellen runden
                flaeche = Math.Round(flaeche, 2);
                callingGUI.txtB_Ausgabe_T_Träger_Fläche.Text = Convert.ToString(flaeche);
                breite = breite1;
                höhe = höhe1;
                s = s1;
                t = t1;
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_T_Träger_Fläche.Text = "Fehler!";
            }
        }
        public double getFläche()
        {
            return flaeche;
        }
        public void setVolumen(double breite1, double höhe1, double t1, double s1, double tiefe1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (breite1 > 0 & höhe1 > 0 & s1 > 0 & t1 > 0 & tiefe1 > 0)
            {
                volumen = berechnung.Volumenberechnung(breite1, höhe1, t1, s1, tiefe1);
                //Ergebnis auf 2 Nachkommastellen runden
                volumen = Math.Round(volumen, 2);
                callingGUI.txtB_Ausgabe_T_Träger_Volumen.Text = Convert.ToString(volumen);
                breite = breite1;
                höhe = höhe1;
                s = s1;
                t = t1;
                tiefe = tiefe1;
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_T_Träger_Volumen.Text = "Fehler!";
            }
        }
        public double getVolumen()
        {
            return volumen;
        }
        public void setGewicht(double breite1, double höhe1, double t1, double s1, double tiefe1, double dichte1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (breite1 > 0 & höhe1 > 0 & s1 > 0 & t1 > 0 & tiefe1 > 0 & dichte1 > 0)
            {
                gewicht = berechnung.Gewichtsberechnung(breite1, höhe1, t1, s1, tiefe1, dichte1);
                //Ergebnis auf 2 Nachkommastellen runden
                gewicht = Math.Round(gewicht, 2);
                callingGUI.txtB_Ausgabe_T_Träger_Gewicht.Text = Convert.ToString(gewicht);
                breite = breite1;
                höhe = höhe1;
                s = s1;
                t = t1;
                tiefe = tiefe1;
                dichte = dichte1;
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_T_Träger_Gewicht.Text = "Fehler!";
            }
        }
        public double getGewicht()
        {
            return gewicht;
        }
        public void setPreis(double breite1, double höhe1, double t1, double s1, double tiefe1, double dichte1, double kosten1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (breite1 > 0 & höhe1 > 0 & s1 > 0 & t1 > 0 & tiefe1 > 0 & dichte1 > 0 & kosten1 > 0)
            {
                preis = berechnung.Preisberechnung(breite1, höhe1, t1, s1, tiefe1, dichte1, kosten1);
                //Ergebnis auf 2 Nachkommastellen runden
                preis = Math.Round(preis, 2);
                callingGUI.txtB_Ausgabe_T_Träger_Preis.Text = Convert.ToString(preis);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_T_Träger_Preis.Text = "Fehler!";
            }
        }
        public double getPreis()
        {
            return preis;
        }
        public void setFlächenträgheitsmoment(double breite1, double höhe1, double t1, double s1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (breite1 > 0 & höhe1 > 0 & s1 > 0 & t1 > 0)
            {
                Ixx = berechnung.Flächenträgheitsmoment_Ixx(breite1, höhe1, t1, s1);
                //Ergebnis auf 2 Nachkommastellen runden
                Ixx = Math.Round(Ixx, 2);
                callingGUI.txtB_Ausgabe_T_Träger_Ixx.Text = Convert.ToString(Ixx);

                Iyy = berechnung.Flächenträgheitsmoment_Iyy(breite1, höhe1, t1, s1);
                //Ergebnis auf 2 Nachkommastellen runden
                Iyy = Math.Round(Iyy, 2);
                callingGUI.txtB_Ausgabe_T_Träger_Iyy.Text = Convert.ToString(Iyy);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_T_Träger_Ixx.Text = "Fehler!";
                callingGUI.txtB_Ausgabe_T_Träger_Iyy.Text = "Fehler!";
            }
        }
        public double getFlächenträgheitmomentIxx()
        {
            return Ixx;
        }
        public double getFlächenträgheitmsomentIyy()
        {
            return Iyy;
        }
        public void deleteGrid()
        {
            //TextBoxen mit leerem String
            callingGUI.txtB_Ausgabe_T_Träger_Fläche.Text = "";
            callingGUI.txtB_Ausgabe_T_Träger_Gewicht.Text = "";
            callingGUI.txtB_Ausgabe_T_Träger_Ixx.Text = "";
            callingGUI.txtB_Ausgabe_T_Träger_Iyy.Text = "";
            callingGUI.txtB_Ausgabe_T_Träger_Preis.Text = "";
            callingGUI.txtB_Ausgabe_T_Träger_Volumen.Text = "";
            callingGUI.txtB_Breite_T_Träger.Text = "";
            callingGUI.txtB_dichte_T_Träger.Text = "";
            callingGUI.txtB_Höhe_T_Träger.Text = "";
            callingGUI.txtB_preis_T_Träger.Text = "";
            callingGUI.txtB_s_T_Träger.Text = "";
            callingGUI.txtB_tiefe_T_Träger.Text = "";
            callingGUI.txtB_t_T_Träger.Text = "";
            //Farbe der Textboxen auf die ursprüungliche Farbe zurücksetzen
            callingGUI.txtB_Breite_T_Träger.Background = Brushes.White;
            callingGUI.txtB_dichte_T_Träger.Background = Brushes.White;
            callingGUI.txtB_Höhe_T_Träger.Background = Brushes.White;
            callingGUI.txtB_preis_T_Träger.Background = Brushes.White;
            callingGUI.txtB_s_T_Träger.Background = Brushes.White;
            callingGUI.txtB_tiefe_T_Träger.Background = Brushes.White;
            callingGUI.txtB_t_T_Träger.Background = Brushes.White;
        }
        public void setHöhe(double laenge1)
        {
            //setzen der Höhe (für Catia benötigt)
            höhe = laenge1;
        }
        public double getHöhe()
        {
            return höhe;
        }
        public void setBreite(double breite1)
        {
            //setzen der Breite (für Catia benötigt)
            breite = breite1;
        }
        public double getBreite()
        {
            return breite;
        }
        public void sett(double t1)
        {
            //t setzen (für Catia benötigt)
            t = t1;
        }
        public double gett()
        {
            return t;
        }
        public void sets(double s1)
        {
            //s setzen (für Catia benötigt)
            s = s1;
        }
        public double gets()
        {
            return s;
        }
        public void setTiefe(double tiefe1)
        {
            //tiefe setzen (für Catia benötigt)
            tiefe = tiefe1;
        }
        public double getTiefe()
        {
            return tiefe;
        }
    }
}
