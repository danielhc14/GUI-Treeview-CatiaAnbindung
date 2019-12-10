using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace GUI_Treeview_CatiaAnbindung
{
    class Program
    {
        public Program()
        {
            GUI myGUI = new GUI();
            myGUI.ShowDialog();
        }

        [STAThread]

        static void Main(string[] args)
        {
            new Program();
        }
    }

    public class Überprüfung
    {
        public String Eingabeüberprüfung(String eingabe)
        {
            //Hilfsvariable für die Überprüfung
            double zahl = 0;
            //Versuch die Eingabe in eine Double Variable umzuwandeln
            bool zahlAbfrage = double.TryParse(eingabe, out zahl);

            //Wenn der Versuch fehlschlägt => Fehlermeldung
            if (zahlAbfrage == false)
            {
                if (eingabe == "")
                {
                }
                else
                {
                    MessageBox.Show("Bitte geben Sie eine Zahl ein!", caption: "Fehler!");
                }
            }
            //Wenn eine Zahl eingegeben wurde, überprüfen ob es eine positive Zahl ist
            else
            {
                //Ist die Zahl keine positvie Zahl => Fehlermeldung
                if (zahl < 0)
                {
                    MessageBox.Show("Bitte geben Sie eine positive Zahl ein!", caption: "Fehler!");
                    eingabe = "!";
                }
            }

            // Rückgabe der Eingabe als String
            return eingabe;
        }
    }
}
