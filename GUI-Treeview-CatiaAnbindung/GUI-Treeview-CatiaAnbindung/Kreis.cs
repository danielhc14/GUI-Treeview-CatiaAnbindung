using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_Treeview_CatiaAnbindung
{
    class Kreis
    {
        GUI callingGUI;
        Kreisprofil_Berechnung berechnung_kreis = new Kreisprofil_Berechnung();

        private double durchmesser;
        private double laenge;
        private double dichte;
        private double kosten;
        private double flaeche;
        private double volumen;
        private double gewicht;
        private double Ixx;
        private double Iyy;

        public Kreis(GUI sender, double durchmesser1, double laenge1, double dichte1, double kosten1)
        {
            durchmesser = durchmesser1;
            laenge = laenge1;
            dichte = dichte1;
            kosten = kosten1;
            callingGUI = sender;
        }
        public void setFläche(double durchmesser1)
        {
            //Überprüfung, ob die Eingabe eine positive Zahl ist
            if (durchmesser1 > 0)
            {
                flaeche = berechnung_kreis.Kreisprofil_Flaechenberechnung(durchmesser1);
                flaeche = Math.Round(flaeche, 2);


                callingGUI.txb_kreis_flaeche.Text = Convert.ToString(flaeche);
            }
            else //Wenn die Umwandlung fehlschlägt => Fehlermeldung im Ausgabefeld Fläche
            {
                callingGUI.txb_kreis_flaeche.Text = "Fehler!";
            }
        }
        public double getFläche()
        {
            return flaeche;
        }
        public void setVolumen(double durchmesser1, double laenge1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhalteten
            if (durchmesser1 > 0 & laenge1 > 0)
            {
                volumen = berechnung_kreis.Kreisprofil_Volumenberechnung(durchmesser1, laenge1);
                volumen = Math.Round(volumen, 2);
                callingGUI.txb_kreis_volumen.Text = Convert.ToString(volumen);
            }
            else //Wenn die Umwandlung fehlschlägt => Fehlermeldung im Ausgabefeld Fläche
            {
                callingGUI.txb_kreis_volumen.Text = "Fehler!";
            }
        }
        public double getVolumen()
        {
            return volumen;
        }
        public void setGewicht(double durchmesser1, double laenge1, double dichte1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhalteten
            if (durchmesser1 > 0 & laenge1 > 0 & dichte1 > 0)
            {
                gewicht = berechnung_kreis.Kreisprofil_Massenberechnung(durchmesser1, laenge1, dichte1);
                gewicht = Math.Round(gewicht, 2);
                callingGUI.txb_kreis_gewicht.Text = Convert.ToString(gewicht);
            }
            else //Wenn die umwandlung fehlschlägt => Fehlermeldung im Ausgabefeld Fläche
            {
                callingGUI.txb_kreis_gewicht.Text = "Fehler!";
            }
        }
        public double getGewicht()
        {
            return gewicht;
        }
        public void setPreis(double durchmesser1, double laenge1, double dichte1, double kosten1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (durchmesser1 > 0 & laenge1 > 0 & dichte1 > 0 & kosten1 > 0)
            {
                kosten = berechnung_kreis.Kreisprofil_Preisberechnung(durchmesser1, laenge1, dichte1, kosten1);
                kosten = Math.Round(kosten, 2);
                callingGUI.txb_kreis_preisberechnet.Text = Convert.ToString(kosten);
            }
            else //Wenn die Umwandlung fehlschlägt => Fehlermeldung Ausgabefeld Fläche
            {
                callingGUI.txb_kreis_preisberechnet.Text = "Fehler!";
            }
        }
        public double getPreis()
        {
            return kosten;
        }
        public void setFlächenträgheitsmoment(double durchmesser1)
        {
            //Überprüfung, ob beide Eingaben eine positive Zahl beinhaltet
            if (durchmesser1 > 0)
            {
                Ixx = berechnung_kreis.Kreisprofil_Flaechentraegheit_Ixx(durchmesser1);
                Ixx = Math.Round(Ixx, 2);
                callingGUI.txb_kreis_flaechentraegheit_ixx.Text = Convert.ToString(Ixx);

                Iyy = berechnung_kreis.Kreisprofil_Flaechentraegheit_Iyy(durchmesser1);
                Iyy = Math.Round(Iyy, 2);
                callingGUI.txb_kreis_flaechentraegheit_iyy.Text = Convert.ToString(Iyy);
            }
            else //Wenn die Umwandlung fehlschlägt => Fehlermeldung im Ausgabefeld Fläche
            {
                callingGUI.txb_kreis_flaechentraegheit_ixx.Text = "Fehler!";
                callingGUI.txb_kreis_flaechentraegheit_iyy.Text = "Fehler!";
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
            callingGUI.txb_kreis_flaeche.Text = "";
            callingGUI.txb_kreis_gewicht.Text = "";
            callingGUI.txb_kreis_flaechentraegheit_ixx.Text = "";
            callingGUI.txb_kreis_flaechentraegheit_iyy.Text = "";
            callingGUI.txb_kreis_preisberechnet.Text = "";
            callingGUI.txb_kreis_volumen.Text = "";
            callingGUI.txb_kreis_dichte.Text = "";
            callingGUI.txb_kreis_laenge.Text = "";
            callingGUI.txb_kreis_preis.Text = "";
            callingGUI.txb_kreis_durchmesser.Text = "";
            //Farbe der Textboxen auf die ursprüungliche Farbe zurücksetzen
            callingGUI.txb_kreis_durchmesser.Background = Brushes.White;
            callingGUI.txb_kreis_laenge.Background = Brushes.White;
            callingGUI.txb_kreis_dichte.Background = Brushes.White;
            callingGUI.txb_kreis_preis.Background = Brushes.White;
        }
    }
}
