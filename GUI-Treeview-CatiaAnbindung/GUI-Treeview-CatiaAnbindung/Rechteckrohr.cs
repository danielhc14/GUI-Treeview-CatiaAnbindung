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
    class Rechteckrohr
    {
        GUI callingGUI;
        Rechteckrohrberechnung berechnung_rechteckR = new Rechteckrohrberechnung();
        private double laenge;
        private double breite;
        private double laenge2;
        private double breite2;
        private double tiefe;
        private double flaeche;
        private double volumen;
        private double dichte;
        private double gewicht;
        private double kosten;
        private double preis;
        private double Ixx;
        private double Iyy;

        public Rechteckrohr(GUI sender, double laenge1, double breite1, double laenge21, double breite21, double tiefe1, double dichte1, double kosten1)
        {
            laenge = laenge1;
            breite = breite1;
            laenge2 = laenge21;
            breite2 = breite21;
            tiefe = tiefe1;
            dichte = dichte1;
            kosten = kosten1;
            callingGUI = sender;


        }
        public void setFläche(double breite1, double laenge1, double breite21, double laenge21)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0 & laenge21 > 0 & breite21 > 0)
            {
                if (laenge1>laenge21 && breite1>breite21)
                {
                    flaeche = berechnung_rechteckR.FlaecheRechteckRohr(breite1, laenge1, breite21, laenge21);
                    //Ergebnis auf 2 Nachkommastellen runden
                    flaeche = Math.Round(flaeche, 2);
                    callingGUI.txtB_Ausgabe_Fläche_Rechteckrohr.Text = Convert.ToString(flaeche);
                    laenge = laenge1;
                    breite = breite1;
                    laenge2 = laenge21;
                    breite2 = breite21;
                }
                else
                {
                    callingGUI.txtB_Ausgabe_Fläche_Rechteckrohr.Text = "Fehler!";
                    MessageBox.Show("Die Tasche kann nicht gößer sein als das Profil!","Fehler!");
                }                
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Fläche_Rechteckrohr.Text = "Fehler!";
            }
        }
        public double getFläche()
        {
            return flaeche;
        }

        public void setVolumen(double breite1, double laenge1, double breite21, double laenge21, double tiefe1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0 & laenge21 > 0 & breite21 > 0 & tiefe1 > 0)
            {
                volumen = berechnung_rechteckR.VolumenRechteckRohr(breite1, laenge1, breite21, laenge21, tiefe1);
                //Ergebnis auf 2 Nachkommastellen runden
                volumen = Math.Round(volumen, 2);
                callingGUI.txtB_Ausgabe_Volumen_Rechteckrohr.Text = Convert.ToString(volumen);
                laenge = laenge1;
                breite = breite1;
                laenge2 = laenge21;
                breite2 = breite21;
                tiefe = tiefe1;

            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Volumen_Rechteckrohr.Text = "Fehler!";
            }
        }
        public double getVolumen()
        {
            return volumen;
        }
        public void setGewicht(double breite1, double laenge1, double breite21, double laenge21, double tiefe1, double dichte1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0 & laenge21 > 0 & breite21 > 0 & tiefe1 > 0 & dichte1 > 0)
            {
                gewicht = berechnung_rechteckR.DichteRechteckRohr(breite1, laenge1, breite21, laenge21, tiefe1, dichte1);
                //Ergebnis auf 2 Nachkommastellen runden
                gewicht = Math.Round(gewicht, 2);
                callingGUI.txtB_Ausgabe_Gewicht_Rechteckrohr.Text = Convert.ToString(gewicht);
                laenge = laenge1;
                breite = breite1;
                laenge2 = laenge21;
                breite2 = breite21;
                tiefe = tiefe1;
                dichte = dichte1;
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Gewicht_Rechteckrohr.Text = "Fehler!";
            }
        }
        public double getGewicht()
        {
            return gewicht;
        }
        public void setPreis(double breite1, double laenge1, double breite21, double laenge21, double tiefe1, double dichte1, double kosten1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0 & laenge21 > 0 & breite21 > 0 & tiefe1 > 0 & dichte1 > 0 & kosten1 > 0)
            {
                preis = berechnung_rechteckR.PreisRechteckRohr(breite1, laenge1, breite21, laenge21, tiefe1, dichte1, kosten1);
                //Ergebnis auf 2 Nachkommastellen runden
                preis = Math.Round(preis, 2);
                callingGUI.txtB_Ausgabe_Preis_Rechteckrohr.Text = Convert.ToString(preis);
                laenge = laenge1;
                breite = breite1;
                laenge2 = laenge21;
                breite2 = breite21;
                tiefe = tiefe1;
                dichte = dichte1;
                kosten = kosten1;
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Preis_Rechteckrohr.Text = "Fehler!";
            }
        }
        public double getPreis()
        {
            return preis;
        }
        public void setFlächenträgheitsmoment(double breite1, double laenge1, double breite21, double laenge21)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (laenge1 > 0 & breite1 > 0 & laenge21 > 0 & breite21 > 0)
            {
                Ixx = berechnung_rechteckR.IxxRechteckrohr(breite1, laenge1, breite21, laenge21);
                //Ergebnis auf 2 Nachkommastellen runden
                Ixx = Math.Round(Ixx, 2);
                callingGUI.txtB_Ausgabe_Ixx_Rechteckrohr.Text = Convert.ToString(Ixx);

                Iyy = berechnung_rechteckR.IyyRechteckrohr(breite1, laenge1, breite21, laenge21);
                //Ergebnis auf 2 Nachkommastellen runden
                Iyy = Math.Round(Iyy, 2);
                callingGUI.txtB_Ausgabe_Iyy_Rechteckrohr.Text = Convert.ToString(Iyy);
                laenge = laenge1;
                breite = breite1;
                laenge2 = laenge21;
                breite2 = breite21;
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Ixx_Rechteckrohr.Text = "Fehler!";
                callingGUI.txtB_Ausgabe_Iyy_Rechteckrohr.Text = "Fehler!";
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
            //TextBoxen mit leerem String
            callingGUI.txtB_Ausgabe_Fläche_Rechteckrohr.Text = "";
            callingGUI.txtB_Ausgabe_Gewicht_Rechteckrohr.Text = "";
            callingGUI.txtB_Ausgabe_Ixx_Rechteckrohr.Text = "";
            callingGUI.txtB_Ausgabe_Iyy_Rechteckrohr.Text = "";
            callingGUI.txtB_Ausgabe_Preis_Rechteckrohr.Text = "";
            callingGUI.txtB_Ausgabe_Volumen_Rechteckrohr.Text = "";
            callingGUI.txtB_Breite_Rechteckrohr.Text = "";
            callingGUI.txtB_dichte_Rechteckrohr.Text = "";
            callingGUI.txtB_Höhe_Rechteckrohr.Text = "";
            callingGUI.txtB_preis_Rechteckrohr.Text = "";
            callingGUI.txtB_breite_Rechteckrohr.Text = "";
            callingGUI.txtB_tiefe_Rechteckrohr.Text = "";
            callingGUI.txtB_höhe_Rechteckrohr.Text = "";
            //Farbe der Textboxen auf die ursprüungliche Farbe zurücksetzen
            callingGUI.txtB_Breite_Rechteckrohr.Background = Brushes.White;
            callingGUI.txtB_dichte_Rechteckrohr.Background = Brushes.White;
            callingGUI.txtB_Höhe_Rechteckrohr.Background = Brushes.White;
            callingGUI.txtB_preis_Rechteckrohr.Background = Brushes.White;
            callingGUI.txtB_breite_Rechteckrohr.Background = Brushes.White;
            callingGUI.txtB_tiefe_Rechteckrohr.Background = Brushes.White;
            callingGUI.txtB_höhe_Rechteckrohr.Background = Brushes.White;
        }
    }
}
