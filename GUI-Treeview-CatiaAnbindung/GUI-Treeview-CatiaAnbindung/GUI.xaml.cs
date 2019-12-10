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
    /// <summary>
    /// Interaktionslogik für GUI.xaml
    /// </summary>
    public partial class GUI : Window
    {
        CatiaCon cc = new CatiaCon();
        // Objekte definieren
        //Objekt für die Rechteckberechnung
        Überprüfung überprüfen = new Überprüfung();
        Rohrprofil_Berechnungen berechnung_Rohr = new Rohrprofil_Berechnungen();
        Kreisprofil_Berechnung berechnung_kreis = new Kreisprofil_Berechnung();
        Rechteck mein_Rechteck;
        Rechteckrohr mein_Rechteckrohr;
        Doppel_T_Träger mein_doppel_T_Träger;
        Kreis mein_Kreis;
        Rohr mein_Rohr;


        //deklaration der Variablen für die Berechnungen
        private double aussendurchmesser;
        private double innendurchmesser;
        private double breite;
        private double laenge;
        private double breite2;
        private double laenge2;
        private double tiefe;
        private double dichte;
        private double flaeche_Rohr;
        private double volumen_Rohr;
        private double gewicht;
        private double kosten;
        private String eingabe;
        private double Ixx;
        private double Iyy;
        private double höhe;
        private double s;
        private double t;

        private double durchmesser;
        private double Pi = Math.PI;
        private double preis;



        public GUI()
        {
            InitializeComponent();
            mein_Rechteck = new Rechteck(this, 0, 0, 0, 0, 0);
            mein_Rechteckrohr = new Rechteckrohr(this, 0, 0, 0, 0, 0, 0, 0);
            mein_doppel_T_Träger = new Doppel_T_Träger(this, 0, 0, 0, 0, 0, 0, 0);
            mein_Kreis = new Kreis(this, 0, 0, 0, 0);
            mein_Rohr = new Rohr(this, 0, 0, 0, 0, 0);
        }

        private void TreeViewItem_Rechteck_Selected(object sender, RoutedEventArgs e)
        {
            //Grid Sichtbar, bzw unsichtbar machen, bei entsprechender Auswahl
            Grid_Rechteck.Visibility = Visibility.Visible;
            Grid_Rechteckrohr.Visibility = Visibility.Hidden;
            Grid_Doppel_T_Träger.Visibility = Visibility.Hidden;
            Grid_Kreis.Visibility = Visibility.Hidden;
            Grid_Rohr.Visibility = Visibility.Hidden;
            img_Begrüßung.Visibility = Visibility.Hidden;
        }
        private void TreeViewItem_Rechteckrohr_Selected(object sender, RoutedEventArgs e)
        {
            //Grid Sichtbar, bzw unsichtbar machen, bei entsprechender Auswahl
            Grid_Rechteck.Visibility = Visibility.Hidden;
            Grid_Rechteckrohr.Visibility = Visibility.Visible;
            Grid_Doppel_T_Träger.Visibility = Visibility.Hidden;
            Grid_Kreis.Visibility = Visibility.Hidden;
            Grid_Rohr.Visibility = Visibility.Hidden;
            img_Begrüßung.Visibility = Visibility.Hidden;

        }
        private void TreeViewItem_DoppelTTräger_Selected(object sender, RoutedEventArgs e)
        {
            //Grid Sichtbar, bzw unsichtbar machen, bei entsprechender Auswahl
            Grid_Rechteck.Visibility = Visibility.Hidden;
            Grid_Rechteckrohr.Visibility = Visibility.Hidden;
            Grid_Doppel_T_Träger.Visibility = Visibility.Visible;
            Grid_Kreis.Visibility = Visibility.Hidden;
            Grid_Rohr.Visibility = Visibility.Hidden;
            img_Begrüßung.Visibility = Visibility.Hidden;
        }
        private void TreeViewItem_Kreis_Selected(object sender, RoutedEventArgs e)
        {
            //Grid Sichtbar, bzw unsichtbar machen, bei entsprechender Auswahl
            Grid_Rechteck.Visibility = Visibility.Hidden;
            Grid_Rechteckrohr.Visibility = Visibility.Hidden;
            Grid_Doppel_T_Träger.Visibility = Visibility.Hidden;
            Grid_Kreis.Visibility = Visibility.Visible;
            Grid_Rohr.Visibility = Visibility.Hidden;
            img_Begrüßung.Visibility = Visibility.Hidden;
        }
        private void TreeViewItem_Rohr_Selected(object sender, RoutedEventArgs e)
        {
            //Grid Sichtbar, bzw unsichtbar machen, bei entsprechender Auswahl
            Grid_Rechteck.Visibility = Visibility.Hidden;
            Grid_Rechteckrohr.Visibility = Visibility.Hidden;
            Grid_Doppel_T_Träger.Visibility = Visibility.Hidden;
            Grid_Kreis.Visibility = Visibility.Hidden;
            Grid_Rohr.Visibility = Visibility.Visible;
            img_Begrüßung.Visibility = Visibility.Hidden;
        }

        //Rechteck
        private void btn_Fläche_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteck.setFläche(laenge, breite);
        }

        private void btn_Volumen_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteck.setVolumen(laenge, breite, tiefe);
        }


        private void btn_gewicht_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteck.setGewicht(laenge, breite, tiefe, dichte);
        }

        private void btn_preis_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteck.setPreis(laenge, breite, tiefe, dichte, kosten);
        }

        private void btn_Flächenträgheitsmoment_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteck.setFlächenträgheitsmoment(laenge, breite);
        }

        // Doppel T-Träger
        private void btn_Fläche_T_Träger_Click(object sender, RoutedEventArgs e)
        {
            mein_doppel_T_Träger.setFläche(breite, höhe, t, s);
        }

        private void btn_Fläche_T_Träger1_Click(object sender, RoutedEventArgs e)//Volumen!
        {
            mein_doppel_T_Träger.setVolumen(breite, höhe, t, s, tiefe);
        }


        private void btn_Gewicht_T_Träger_Click_1(object sender, RoutedEventArgs e)
        {
            mein_doppel_T_Träger.setGewicht(breite, höhe, t, s, tiefe, dichte);
        }

        private void btn_Preis_T_Träger1_Click(object sender, RoutedEventArgs e)
        {
            mein_doppel_T_Träger.setPreis(breite, höhe, t, s, tiefe, dichte, kosten);
        }

        private void btn_Flächenträgheitsmoment_T_Träger_Click(object sender, RoutedEventArgs e)
        {
            mein_doppel_T_Träger.setFlächenträgheitsmoment(breite, höhe, t, s);
        }

        private void btn_Eingabe_Löschen_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteck.deleteGrid();
        }
        private void btn_Eingabe_Löschen_Rohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rohr.deleteGrid();
        }
        private void btn_T_Träger_Eingaben_Löschen_Click(object sender, RoutedEventArgs e)
        {
            mein_doppel_T_Träger.deleteGrid();
        }
        private void btn_Fläche_Rohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rohr.setFläche(aussendurchmesser, innendurchmesser);
        }
        private void btn_Volumen_Rohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rohr.setVolumen(aussendurchmesser, innendurchmesser, laenge);
        }
        private void btn_gewicht_Rohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rohr.setGewicht(aussendurchmesser, innendurchmesser, laenge, dichte);
        }
        private void btn_preis_Rohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rohr.setPreis(aussendurchmesser, innendurchmesser, laenge, dichte, kosten);
        }

        private void btn_Flächenträgheitsmoment_Rohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rohr.setFlächenträgheitsmoment(aussendurchmesser, innendurchmesser);
        }

        private void btn_kreis_flaeche_Click(object sender, RoutedEventArgs e)
        {
            mein_Kreis.setFläche(durchmesser);
        }

        private void btn_kreis_volumen_Click(object sender, RoutedEventArgs e)
        {
            mein_Kreis.setVolumen(durchmesser, laenge);
        }

        private void btn_kreis_gewicht_Click(object sender, RoutedEventArgs e)
        {
            mein_Kreis.setGewicht(durchmesser, laenge, dichte);
        }

        private void btn_kreis_preis_Click(object sender, RoutedEventArgs e)
        {
            mein_Kreis.setPreis(durchmesser, laenge, dichte, preis);
        }

        private void btn_kreis_flaechentraegheit_Click(object sender, RoutedEventArgs e)
        {
            mein_Kreis.setFlächenträgheitsmoment(durchmesser);
        }

        private void btn_kreis_loeschen_Click(object sender, RoutedEventArgs e)
        {
            mein_Kreis.deleteGrid();
        }



        private void txtB_Länge_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Länge.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out laenge);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Länge.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Länge.Background = Brushes.White;
                //Breite für mein_Rechteck setzen (benötigt für die Übergabe an Catia)
                mein_Rechteck.setLänge(laenge);
            }
        }

        private void txtB_Breite_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Breite.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out breite);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Breite.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Breite.Background = Brushes.White;
                //Breite für mein_Rechteck setzen (benötigt für die Übergabe an Catia)
                mein_Rechteck.setBreite(breite);
            }
        }

        private void txtB_tiefe_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_tiefe.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out tiefe);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_tiefe.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_tiefe.Background = Brushes.White;
                //Tiefe für mein_Rechteck setzen (benötigt für die Übergabe an Catia)
                mein_Rechteck.setTiefe(tiefe);
            }
        }

        private void txtB_dichte_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_dichte.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out dichte);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_dichte.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_dichte.Background = Brushes.White;
            }
        }

        private void txtB_Preis_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Preis.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out kosten);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Preis.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Preis.Background = Brushes.White;
            }
        }

        private void txtB_Höhe_T_Träger_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Höhe_T_Träger.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out höhe);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Höhe_T_Träger.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Höhe_T_Träger.Background = Brushes.White;
                mein_doppel_T_Träger.setHöhe(höhe);
            }
        }

        private void txtB_Breite_T_Träger_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Breite_T_Träger.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out breite);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Breite_T_Träger.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Breite_T_Träger.Background = Brushes.White;
                mein_doppel_T_Träger.setBreite(breite);
            }
        }

        private void txtB_t_T_Träger_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_t_T_Träger.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out t);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_t_T_Träger.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_t_T_Träger.Background = Brushes.White;
                mein_doppel_T_Träger.sett(t);
            }
        }

        private void txtB_s_T_Träger_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_s_T_Träger.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out s);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_s_T_Träger.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_s_T_Träger.Background = Brushes.White;
                mein_doppel_T_Träger.sets(s);
            }
        }

        private void txtB_tiefe_T_Träger_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_tiefe_T_Träger.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out tiefe);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_tiefe_T_Träger.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_tiefe_T_Träger.Background = Brushes.White;
                mein_doppel_T_Träger.setTiefe(tiefe);
            }
        }

        private void txtB_dichte_T_Träger_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_dichte_T_Träger.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out dichte);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_dichte_T_Träger.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_dichte_T_Träger.Background = Brushes.White;
            }
        }

        private void txtB_preis_T_Träger_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_preis_T_Träger.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out kosten);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_preis_T_Träger.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_preis_T_Träger.Background = Brushes.White;
            }
        }

        private void txtB_preis_T_Träger_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_preis_T_Träger.Background == Brushes.Red)
            {
                txtB_preis_T_Träger.Text = "";
            }
        }

        private void txtB_Höhe_T_Träger_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Höhe_T_Träger.Background == Brushes.Red)
            {
                txtB_Höhe_T_Träger.Text = "";
            }
        }

        private void txtB_Breite_T_Träger_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Breite_T_Träger.Background == Brushes.Red)
            {
                txtB_Breite_T_Träger.Text = "";
            }
        }

        private void txtB_t_T_Träger_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_t_T_Träger.Background == Brushes.Red)
            {
                txtB_t_T_Träger.Text = "";
            }
        }

        private void txtB_s_T_Träger_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_s_T_Träger.Background == Brushes.Red)
            {
                txtB_s_T_Träger.Text = "";
            }
        }

        private void txtB_tiefe_T_Träger_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_tiefe_T_Träger.Background == Brushes.Red)
            {
                txtB_tiefe_T_Träger.Text = "";
            }
        }

        private void txtB_dichte_T_Träger_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_dichte_T_Träger.Background == Brushes.Red)
            {
                txtB_dichte_T_Träger.Text = "";
            }
        }

        private void txtB_Länge_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Länge.Background == Brushes.Red)
            {
                txtB_Länge.Text = "";
            }
        }

        private void txtB_Breite_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Breite.Background == Brushes.Red)
            {
                txtB_Breite.Text = "";
            }
        }

        private void txtB_tiefe_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_tiefe.Background == Brushes.Red)
            {
                txtB_tiefe.Text = "";
            }
        }

        private void txtB_dichte_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_dichte.Background == Brushes.Red)
            {
                txtB_dichte.Text = "";
            }
        }

        private void txtB_Preis_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Preis.Background == Brushes.Red)
            {
                txtB_Preis.Text = "";
            }

        }

        private void btn_Werte_einlesen_Mouse_Move(object sender, MouseEventArgs e)
        {
            //Popup Info anzeigen, wenn die Maus über dem Button ist
            this.Popup_Werte_Einlesen.IsOpen = true;
        }

        private void btn_Werte_einlesen_Mouse_Leave(object sender, MouseEventArgs e)
        {
            //Popup Info ausblenden, wenn die Maus den Button verlässt
            this.Popup_Werte_Einlesen.IsOpen = false;
        }

        private void btn_Werte_einlesen_Click(object sender, RoutedEventArgs e)
        {
            //Berechnete Werte in Textboxen ausgeben
            txtB_Ausgabe_Flaeche.Text = Convert.ToString(mein_Rechteck.getFläche());
            txtB_Ausgabe_Gewicht.Text = Convert.ToString(mein_Rechteck.getGewicht());
            txtB_Ausgabe_Ixx.Text = Convert.ToString(mein_Rechteck.getFlächenträgheitsmomentIxx());
            txtB_Ausgabe_Iyy.Text = Convert.ToString(mein_Rechteck.getFlächenträgheitsmomentIyy());
            txtB_Ausgabe_Preis.Text = Convert.ToString(mein_Rechteck.getPreis());
            txtB_Ausgabe_Volumen.Text = Convert.ToString(mein_Rechteck.getVolumen());
        }

        private void btn_Ergebnisse_Wieder_Einlesen_Mouse_Move(object sender, MouseEventArgs e)
        {
            //Popup Info anzeigen, wenn die Maus über dem Button ist
            this.Popup_Ergebnisse_Einlesen_T.IsOpen = true;
        }

        private void btn_Ergebnisse_Wieder_Einlesen_Mouse_Leave(object sender, MouseEventArgs e)
        {
            //Popup Info ausblenden, wenn die Maus den Button verlässt
            this.Popup_Ergebnisse_Einlesen_T.IsOpen = false;
        }

        private void btn_Ergebnisse_Wieder_Einlesen_Click(object sender, RoutedEventArgs e)
        {
            txtB_Ausgabe_T_Träger_Fläche.Text = Convert.ToString(mein_doppel_T_Träger.getFläche());
            txtB_Ausgabe_T_Träger_Gewicht.Text = Convert.ToString(mein_doppel_T_Träger.getGewicht());
            txtB_Ausgabe_T_Träger_Ixx.Text = Convert.ToString(mein_doppel_T_Träger.getFlächenträgheitmomentIxx());
            txtB_Ausgabe_T_Träger_Iyy.Text = Convert.ToString(mein_doppel_T_Träger.getFlächenträgheitmsomentIyy());
            txtB_Ausgabe_T_Träger_Preis.Text = Convert.ToString(mein_doppel_T_Träger.getPreis());
            txtB_Ausgabe_T_Träger_Volumen.Text = Convert.ToString(mein_doppel_T_Träger.getVolumen());
        }

        private void txb_kreis_durchmesser_LostFocus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txb_kreis_durchmesser.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out durchmesser);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {

                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txb_kreis_durchmesser.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txb_kreis_durchmesser.Background = Brushes.White;
            }
        }

        private void txb_kreis_laenge_LostFocus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txb_kreis_laenge.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out laenge);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txb_kreis_laenge.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txb_kreis_laenge.Background = Brushes.White;
            }
        }

        private void txb_kreis_dichte_LostFocus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txb_kreis_dichte.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out dichte);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txb_kreis_dichte.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txb_kreis_dichte.Background = Brushes.White;
            }
        }

        private void txb_kreis_preis_LostFocus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txb_kreis_preis.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out preis);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txb_kreis_preis.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txb_kreis_preis.Background = Brushes.White;
            }
        }

        private void btn_Fläche_Rechteckrohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteckrohr.setFläche(breite, laenge, breite2, laenge2);
        }

        private void btn_Volumen_Rechteckrohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteckrohr.setVolumen(breite, laenge, breite2, laenge2, tiefe);
        }

        private void btn_Gewicht_Rechteckrohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteckrohr.setGewicht(breite, laenge, breite2, laenge2, tiefe, dichte);
        }

        private void btn_Preis_Rechteckrohr1_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteckrohr.setPreis(breite, laenge, breite2, laenge2, tiefe, dichte, kosten);
        }

        private void btn_Flächenträgheitsmoment_Rechteckrohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteckrohr.setFlächenträgheitsmoment(breite, laenge, breite2, laenge2);
        }
        private void txtB_Höhe_Rechteckrohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Höhe_Rechteckrohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out laenge);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Höhe_Rechteckrohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Höhe_Rechteckrohr.Background = Brushes.White;
            }
        }

        private void txtB_Breite_Rechteckrohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Breite_Rechteckrohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out breite);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Breite_Rechteckrohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Breite_Rechteckrohr.Background = Brushes.White;
            }
        }

        private void txtB_höhe_Rechteckrohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_höhe_Rechteckrohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out laenge2);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_höhe_Rechteckrohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_höhe_Rechteckrohr.Background = Brushes.White;
            }
        }

        private void txtB_breite_Rechteckrohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_breite_Rechteckrohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out breite2);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_breite_Rechteckrohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_breite_Rechteckrohr.Background = Brushes.White;
            }
        }

        private void txtB_tiefe_Rechteckrohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_tiefe_Rechteckrohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out tiefe);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_tiefe_Rechteckrohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_tiefe_Rechteckrohr.Background = Brushes.White;
            }
        }

        private void txtB_dichte_Rechteckrohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_dichte_Rechteckrohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out dichte);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_dichte_Rechteckrohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_dichte_Rechteckrohr.Background = Brushes.White;
            }
        }

        private void txtB_preis_Rechteckrohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_preis_Rechteckrohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out kosten);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_preis_Rechteckrohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_preis_Rechteckrohr.Background = Brushes.White;
            }
        }

        private void txtB_preis_Rechteckrohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_preis_Rechteckrohr.Background == Brushes.Red)
            {
                txtB_preis_Rechteckrohr.Text = "";
            }
        }

        private void txtB_Höhe_Rechteckrohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Höhe_Rechteckrohr.Background == Brushes.Red)
            {
                txtB_Höhe_Rechteckrohr.Text = "";
            }
        }

        private void txtB_Breite_Rechteckrohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Breite_Rechteckrohr.Background == Brushes.Red)
            {
                txtB_Breite_Rechteckrohr.Text = "";
            }
        }

        private void txtB_höhe_Rechteckrohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_höhe_Rechteckrohr.Background == Brushes.Red)
            {
                txtB_höhe_Rechteckrohr.Text = "";
            }
        }

        private void txtB_breite_Rechteckrohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_breite_Rechteckrohr.Background == Brushes.Red)
            {
                txtB_breite_Rechteckrohr.Text = "";
            }
        }

        private void txtB_tiefe_Rechteckrohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_tiefe_Rechteckrohr.Background == Brushes.Red)
            {
                txtB_tiefe_Rechteckrohr.Text = "";
            }
        }

        private void txtB_dichte_Rechteckrohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_dichte_Rechteckrohr.Background == Brushes.Red)
            {
                txtB_dichte_Rechteckrohr.Text = "";
            }
        }
        private void btn_Rechteckrohr_Eingaben_Löschen_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteckrohr.deleteGrid();
        }
        private void btn_Ergebnisse_Wieder_Einlesen_Mouse_Move_Rechteckrohr(object sender, MouseEventArgs e)
        {
            //Popup Info anzeigen, wenn die Maus über dem Button ist
            this.Popup_Ergebnisse_Einlesen_Rechteckrohr.IsOpen = true;
        }

        private void btn_Ergebnisse_Wieder_Einlesen_Mouse_Leave_Rechteckrohr(object sender, MouseEventArgs e)
        {
            //Popup Info ausblenden, wenn die Maus den Button verlässt
            this.Popup_Ergebnisse_Einlesen_Rechteckrohr.IsOpen = false;
        }

        private void btn_Ergebnisse_Wieder_Einlesen_Click_Rechteckrohr(object sender, RoutedEventArgs e)
        {
            //Berechnete Werte in Textboxen ausgeben
            txtB_Ausgabe_Fläche_Rechteckrohr.Text = Convert.ToString(mein_Rechteckrohr.getFläche());
            txtB_Ausgabe_Gewicht_Rechteckrohr.Text = Convert.ToString(mein_Rechteckrohr.getGewicht());
            txtB_Ausgabe_Ixx_Rechteckrohr.Text = Convert.ToString(mein_Rechteckrohr.getFlächenträgheitsmomentIxx());
            txtB_Ausgabe_Iyy_Rechteckrohr.Text = Convert.ToString(mein_Rechteckrohr.getFlächenträgheitsmomentIyy());
            txtB_Ausgabe_Preis_Rechteckrohr.Text = Convert.ToString(mein_Rechteckrohr.getPreis());
            txtB_Ausgabe_Volumen_Rechteckrohr.Text = Convert.ToString(mein_Rechteckrohr.getVolumen());
        }

        private void btn_kreis_eingaben_einlesen(object sender, RoutedEventArgs e)
        {
            txb_kreis_flaeche.Text = Convert.ToString(mein_Kreis.getFläche());
            txb_kreis_gewicht.Text = Convert.ToString(mein_Kreis.getGewicht());
            txb_kreis_preisberechnet.Text = Convert.ToString(mein_Kreis.getPreis());
            txb_kreis_flaechentraegheit_ixx.Text = Convert.ToString(mein_Kreis.getFlächenträgheitsmomentIxx());
            txb_kreis_flaechentraegheit_iyy.Text = Convert.ToString(mein_Kreis.getFlächenträgheitsmomentIyy());
            txb_kreis_volumen.Text = Convert.ToString(mein_Kreis.getVolumen());
        }

        private void btn_kreis_eingaben_einlesen_Mouse_Move(object sender, MouseEventArgs e)
        {
            this.Popup_Werte_Einlesen_Kreis.IsOpen = true;
        }

        private void btn_kreis_eingaben_einlesen_Mouse_Leave(object sender, MouseEventArgs e)
        {
            this.Popup_Werte_Einlesen_Kreis.IsOpen = false;
        }

        private void txtB_aussendurchmesser_Rohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Aussendurchmesser_Rohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out aussendurchmesser);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Aussendurchmesser_Rohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Aussendurchmesser_Rohr.Background = Brushes.White;
            }
        }
        private void txtB_Aussendurchmesser_Rohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Aussendurchmesser_Rohr.Background == Brushes.Red)
            {
                txtB_Aussendurchmesser_Rohr.Text = "";
            }
        }
        private void txtB_Innendurchmesser_Rohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Innendurchmesser_Rohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out innendurchmesser);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Innendurchmesser_Rohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Innendurchmesser_Rohr.Background = Brushes.White;
            }
        }


        private void txtB_t_Rohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_t_Rohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out laenge);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_t_Rohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_t_Rohr.Background = Brushes.White;
            }
        }

        private void txtB_t_Rohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_t_Rohr.Background == Brushes.Red)
            {
                txtB_t_Rohr.Text = "";
            }
        }

        private void txtB_Dichte_Rohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Dichte_Rohr.Background == Brushes.Red)
            {
                txtB_Dichte_Rohr.Text = "";
            }
        }

        private void txtB_Dichte_Rohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Dichte_Rohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out dichte);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Dichte_Rohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Dichte_Rohr.Background = Brushes.White;
            }
        }

        private void txtB_Preis_Rohr_Lost_Focus(object sender, RoutedEventArgs e)
        {
            //Nach dem verlassen der Textbox wird die Eingabeüberprüfung initiiert
            eingabe = überprüfen.Eingabeüberprüfung(txtB_Preis_Rohr.Text);
            bool überprüfung_Eingabe = double.TryParse(eingabe, out kosten);
            //Abfragen, ob die Überprüfung erfolgreich war
            if (überprüfung_Eingabe == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    //Bei Fehleingabe wird der Hintergrund der Textbox Rot gefärbt
                    txtB_Preis_Rohr.Background = Brushes.Red;
                }
            }
            else
            {
                //Bei Richtiger Eingabe wird der Hintergrund der Textbox Weiß gefärbt
                txtB_Preis_Rohr.Background = Brushes.White;
            }
        }

        private void txtB_Innendurchmesser_Rohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Innendurchmesser_Rohr.Background == Brushes.Red)
            {
                txtB_Innendurchmesser_Rohr.Text = "";
            }
        }

        private void btn_Werte_einlesen_Rohr_Click(object sender, RoutedEventArgs e)
        {
            txtB_Ausgabe_Flaeche_Rohr.Text = Convert.ToString(mein_Rohr.getFläche());
            txtB_Ausgabe_Gewicht_Rohr.Text = Convert.ToString(mein_Rohr.getGewicht());
            txtB_Ausgabe_Ixx_Rohr.Text = Convert.ToString(mein_Rohr.getFlächenträgheitsmomentIxx());
            txtB_Ausgabe_Iyy_Rohr.Text = Convert.ToString(mein_Rohr.getFlächenträgheitsmomentIyy());
            txtB_Ausgabe_Preis_Rohr.Text = Convert.ToString(mein_Rohr.getPreis());
            txtB_Ausgabe_Volumen_Rohr.Text = Convert.ToString(mein_Rohr.getVolumen());
        }

        private void btn_Alle_Berechnungen_durchführen_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteck.setFläche(laenge, breite);
            mein_Rechteck.setFlächenträgheitsmoment(laenge, breite);
            mein_Rechteck.setGewicht(laenge, breite, tiefe, dichte);
            mein_Rechteck.setPreis(laenge, breite, tiefe, dichte, kosten);
            mein_Rechteck.setVolumen(laenge, breite, tiefe);
        }

        private void btn_Alle_Berechnungen_Durchführen_Click_1(object sender, RoutedEventArgs e)
        {
            mein_doppel_T_Träger.setVolumen(breite, höhe, t, s, tiefe);
            mein_doppel_T_Träger.setPreis(breite, höhe, t, s, tiefe, dichte, kosten);
            mein_doppel_T_Träger.setGewicht(breite, höhe, t, s, tiefe, dichte);
            mein_doppel_T_Träger.setFlächenträgheitsmoment(breite, höhe, t, s);
            mein_doppel_T_Träger.setFläche(breite, höhe, t, s);
        }

        private void btn_Alle_Berechnungen_Durchführen_Rechteckrohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rechteckrohr.setFläche(breite, laenge, breite2, laenge2);
            mein_Rechteckrohr.setFlächenträgheitsmoment(breite, laenge, breite2, laenge2);
            mein_Rechteckrohr.setGewicht(breite, laenge, breite2, laenge2, tiefe, dichte);
            mein_Rechteckrohr.setPreis(breite, laenge, breite2, laenge2, tiefe, dichte, kosten);
            mein_Rechteckrohr.setVolumen(breite, laenge, breite2, laenge2, tiefe);
        }

        private void btn_Alle_Berechnungen_Durchführen_Kreis_Click(object sender, RoutedEventArgs e)
        {
            mein_Kreis.setVolumen(durchmesser, laenge);
            mein_Kreis.setFläche(durchmesser);
            mein_Kreis.setGewicht(durchmesser, laenge, dichte);
            mein_Kreis.setPreis(durchmesser, laenge, dichte, preis);
            mein_Kreis.setFlächenträgheitsmoment(durchmesser);
        }

        private void btn_Alle_Berechnungen_Durchführen_Rohr_Click(object sender, RoutedEventArgs e)
        {
            mein_Rohr.setFläche(aussendurchmesser, innendurchmesser);
            mein_Rohr.setFlächenträgheitsmoment(aussendurchmesser, innendurchmesser);
            mein_Rohr.setGewicht(aussendurchmesser, innendurchmesser, laenge, dichte);
            mein_Rohr.setPreis(aussendurchmesser, innendurchmesser, laenge, dichte, kosten);
            mein_Rohr.setVolumen(aussendurchmesser, innendurchmesser, laenge);
        }

        private void txtB_Preis_Rohr_Focus(object sender, RoutedEventArgs e)
        {
            //Löschen der Textbox, wenn zuvor eine Fehleingabe eingegeben wurde
            if (txtB_Preis_Rohr.Background == Brushes.Red)
            {
                txtB_Preis_Rohr.Text = "";
            }
        }

        private void btn_CATIA_Rechteck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cc.CatiaLauft();
                try
                {
                    cc.ErzeugePart();
                    try
                    {
                        cc.ErstelleLeereSkizze();
                        try
                        {
                            cc.ErzeugeProfilRechteck(mein_Rechteck.getLänge(), mein_Rechteck.getBreite());
                            try
                            {
                                cc.ErzeugeBalken(mein_Rechteck.getTiefe());
                            }
                            catch
                            {
                                MessageBox.Show("Fehler beim Erzeugen des Körpers");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Fehler beim Erzeugen des Profils");
                        }
                    }
                    catch 
                    {
                        MessageBox.Show("Fehler beim Erstellen einer neuen Skizze");
                    }
                }
                catch
                {
                    MessageBox.Show("Fehler bei der Erzeugung des Parts");
                }
            }
            catch
            {
                MessageBox.Show("Bitte überprüfen Sie, ob Catia läuft");
            }
            
            
           
            
            
        }

        private void btn_Catia_Doppel_T_Träger_Click(object sender, RoutedEventArgs e)
        {
            cc.CatiaLauft();
            cc.ErzeugePart();
            cc.ErstelleLeereSkizze();
            cc.ErzeugeProfilDoppelTTräger(mein_doppel_T_Träger.getBreite(), mein_doppel_T_Träger.getHöhe());
            cc.ErzeugeBalkenDoppelTTräger(mein_doppel_T_Träger.getTiefe());
            cc.ErzeugeSkizzeTascheDoppelTTräger(mein_doppel_T_Träger.getBreite(),mein_doppel_T_Träger.getHöhe(),mein_doppel_T_Träger.gets(),mein_doppel_T_Träger.gett());
            cc.ErzeugeTascheDoppelTTräger(mein_doppel_T_Träger.getTiefe());
        }
    }
}
