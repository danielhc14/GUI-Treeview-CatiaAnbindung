using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUI_Treeview_CatiaAnbindung
{
    class Rohr
    {
        GUI callingGUI;
        Rohrprofil_Berechnungen berechnung = new Rohrprofil_Berechnungen();
        Überprüfung überprüfen = new Überprüfung();

        private double aussendurchmesser;
        private double innendurchmesser;
        private double laenge;
        private double dichte;
        private double kosten;
        private double flaeche;
        private double volumen;
        private double gewicht;
        private double preis;
        private double ixx;
        private double iyy;
        private string eingabe;
        private bool fehler1;
        private bool fehler;

        public Rohr(GUI sender, double aussendurchmesser1, double innendurchmesser1, double laenge1, double dichte1, double kosten1)
        {
            aussendurchmesser = aussendurchmesser1;
            innendurchmesser = innendurchmesser1;
            laenge = laenge1;
            dichte = dichte1;
            kosten = kosten1;
            callingGUI = sender;

        }
        public void setFläche(double aussendurchmesser1, double innendurchmesser1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (aussendurchmesser1 > 0 & innendurchmesser1 > 0)
            {
                if (aussendurchmesser1>innendurchmesser1)
                {
                    flaeche = berechnung.Rohrprofil_Flaechenberechnung(aussendurchmesser1, innendurchmesser1);
                    //Ergebnis auf 2 Nachkommastellen runden
                    flaeche = Math.Round(flaeche, 2);
                    callingGUI.txtB_Ausgabe_Flaeche_Rohr.Text = Convert.ToString(flaeche);
                }
                else
                {
                    callingGUI.txtB_Ausgabe_Flaeche_Rohr.Text = "Fehler!";
                    MessageBox.Show("Die Tasche kann nicht gößer sein als das Profil!", "Fehler!");
                }

            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Flaeche_Rohr.Text = "Fehler!";
            }
        }
        public double getFläche()
        {
            return flaeche;
        }
        public void setVolumen(double aussendurchmesser1, double innendurchmesser1, double laenge1)

        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (aussendurchmesser1 > 0 & innendurchmesser1 > 0 & laenge1 > 0)
            {
                volumen = berechnung.Rohrprofil_Volumenberechnung(aussendurchmesser1, innendurchmesser1, laenge1);
                volumen = Math.Round(volumen, 2);
                callingGUI.txtB_Ausgabe_Volumen_Rohr.Text = Convert.ToString(volumen);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Volumen_Rohr.Text = "Fehler!";
            }

        }
        public double getVolumen()
        {
            return volumen;
        }
        public void setGewicht(double aussendurchmesser1, double innendurchmesser1, double laenge1, double dichte1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (aussendurchmesser1 > 0 & innendurchmesser1 > 0 & laenge1 > 0 & dichte1 > 0)
            {
                gewicht = berechnung.Rohrprofil_Gewichtsberechnung(aussendurchmesser1, innendurchmesser1, laenge1, dichte1);
                //Ergebnis auf 2 Nachkommastellen runden
                gewicht = Math.Round(gewicht, 2);
                callingGUI.txtB_Ausgabe_Gewicht_Rohr.Text = Convert.ToString(gewicht);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Gewicht_Rohr.Text = "Fehler!";
            }
        }
        public double getGewicht()
        {
            return gewicht;
        }
        public void setPreis(double aussendurchmesser1, double innendurchmesser1, double laenge1, double dichte1, double kosten1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (aussendurchmesser1 > 0 & innendurchmesser1 > 0 & laenge1 > 0 & dichte1 > 0 & kosten1 > 0)
            {
                preis = berechnung.Rohrprofil_Preisberechnung(aussendurchmesser1, innendurchmesser1, laenge1, dichte1, kosten1);
                //Ergebnis auf 2 Nachkommastellen runden
                preis = Math.Round(preis, 2);
                callingGUI.txtB_Ausgabe_Preis_Rohr.Text = Convert.ToString(preis);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Preis_Rohr.Text = "Fehler!";
            }
        }
        public double getPreis()
        {
            return preis;
        }
        public void setFlächenträgheitsmoment(double aussendurchmesser1, double innendurchmesser1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (aussendurchmesser1 > 0 & innendurchmesser1 > 0)
            {
                ixx = berechnung.Rohrprofil_Flaechentraegheit_Ixx(aussendurchmesser1, innendurchmesser1);
                //Ergebnis auf 2 Nachkommastellen runden
                ixx = Math.Round(ixx, 2);
                callingGUI.txtB_Ausgabe_Ixx_Rohr.Text = Convert.ToString(ixx);

                iyy = berechnung.Rohrprofil_Flaechentraegheit_Iyy(aussendurchmesser1, innendurchmesser1);
                //Ergebnis auf 2 Nachkommastellen runden
                iyy = Math.Round(iyy, 2);
                callingGUI.txtB_Ausgabe_Iyy_Rohr.Text = Convert.ToString(iyy);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung ausgabefeld Fläche
            {
                callingGUI.txtB_Ausgabe_Ixx_Rohr.Text = "Fehler!";
                callingGUI.txtB_Ausgabe_Iyy_Rohr.Text = "Fehler!";
            }
        }
        public double getFlächenträgheitsmomentIxx()
        {
            return ixx;
        }
        public double getFlächenträgheitsmomentIyy()
        {
            return iyy;
        }
        public void deleteGrid()
        {
            //TextBoxen mit leerem String
            callingGUI.txtB_Ausgabe_Flaeche_Rohr.Text = "";
            callingGUI.txtB_Ausgabe_Gewicht_Rohr.Text = "";
            callingGUI.txtB_Ausgabe_Ixx_Rohr.Text = "";
            callingGUI.txtB_Ausgabe_Iyy_Rohr.Text = "";
            callingGUI.txtB_Ausgabe_Preis_Rohr.Text = "";
            callingGUI.txtB_Ausgabe_Volumen_Rohr.Text = "";
            callingGUI.txtB_Aussendurchmesser_Rohr.Text = "";
            callingGUI.txtB_Dichte_Rohr.Text = "";
            callingGUI.txtB_Innendurchmesser_Rohr.Text = "";
            callingGUI.txtB_Preis_Rohr.Text = "";
            callingGUI.txtB_t_Rohr.Text = "";
            //Farbe der Textboxen auf die ursprüungliche Farbe zurücksetzen
            callingGUI.txtB_Aussendurchmesser_Rohr.Background = Brushes.White;
            callingGUI.txtB_Innendurchmesser_Rohr.Background = Brushes.White;
            callingGUI.txtB_t_Rohr.Background = Brushes.White;
            callingGUI.txtB_Preis_Rohr.Background = Brushes.White;
            callingGUI.txtB_Dichte_Rohr.Background = Brushes.White;
        }
        public void setADurchmesser(double aussendurchmesser1)
        {
            //Setzen des Durchmessers für CATIA
            aussendurchmesser = aussendurchmesser1;
        }
        public double getADurchmesser()
        {
            //Holen des DUrchmessers für Übertragung an CATIA
            return aussendurchmesser;
        }
        public void setIDurchmesser(double innendurchmesser1)
        {
            //Setzen des Durchmessers für CATIA
            innendurchmesser = innendurchmesser1;
        }
        public double getIDurchmesser()
        {
            //Holen des DUrchmessers für Übertragung an CATIA
            return innendurchmesser;
        }
        public void setLaenge(double laenge1)
        {
            //setzen der Länge (für Catia benötigt)
            laenge = laenge1;
        }
        public double getLaenge()
        {
            //Holen der Länge, um dies an Catia zu übertragen
            return laenge;
        }
        public bool Fehler (double aussendurchmesser, double innendurchmesser)
        {
            if (aussendurchmesser>innendurchmesser)
            {
                fehler = false;
            }
            else
            {
                fehler = true;
            }
            return fehler;
        }
        public bool getFehler ()
        {
            return fehler;
        }
    }
}
