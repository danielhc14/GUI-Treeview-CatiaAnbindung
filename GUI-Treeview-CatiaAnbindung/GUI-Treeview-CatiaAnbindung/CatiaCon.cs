using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFITF;
using MECMOD;
using PARTITF;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ProductStructureTypeLib;

namespace GUI_Treeview_CatiaAnbindung
{
    class CatiaCon
    {
        INFITF.Application catiaAnwendung;
        PartDocument catiaPart;
        Sketch catiaSketch;
        Sketch catiaSketch1;
        ProductDocument activedocproduct;
        Product product1;

        private bool skizzeerstellt;

        public bool CatiaLauft()
        {
            try
            {
                object co = System.Runtime.InteropServices.Marshal.GetActiveObject("CATIA.Application");
                catiaAnwendung = (INFITF.Application)co;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            bool abfrage = true;
            String inputBoxEingabe;
            INFITF.Documents catDocuments1 = catiaAnwendung.Documents;
            catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            string partnummer1;
            try
            {
                catiaPart = (MECMOD.PartDocument)catiaAnwendung.ActiveDocument;
                product1 = catiaPart.Product;
            }
            catch
            {
                try
                {
                    activedocproduct = (ProductStructureTypeLib.ProductDocument)catiaAnwendung.ActiveDocument;
                    product1 = activedocproduct.Product;
                    abfrage = true;
                }
                catch
                {
                    MessageBox.Show("Teilenummer konnte nicht ermittelt werden");
                    abfrage = false;
                }
            }


            partnummer1 = product1.get_PartNumber();
            inputBoxEingabe = Interaction.InputBox("Möchten Sie dem Part eine neue Teilenummer zuweisen?", "Zugriff auf Catia V5", partnummer1);
            if ((string)inputBoxEingabe == "")
            {
                inputBoxEingabe = partnummer1;
            }
            product1.set_PartNumber(ref inputBoxEingabe);
            return abfrage;

        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies = catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler");
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            Sketches catSketches2 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            catiaSketch = catSketches1.Add(catReference1);
            catiaSketch1 = catSketches2.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            catiaPart.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            catiaSketch.SetAbsoluteAxisData(arr);
        }

        public bool ErzeugeProfilRechteck(Double b, Double h)
        {
            if (b == 0 & h == 0)
            {
                MessageBox.Show("Fehler beim Erstellen des Profils:\rDie Werte dürfen nicht null sein!");
                skizzeerstellt = false;
            }
            else
            {
                b = b / 2;
                h = h / 2;
                // Skizze umbenennen
                catiaSketch.set_Name("Rechteck");

                // Rechteck in Skizze einzeichnen
                // Skizze oeffnen
                Factory2D catFactory2D1 = catiaSketch.OpenEdition();

                // Rechteck erzeugen

                // erst die Punkte
                Point2D catPoint2D1 = catFactory2D1.CreatePoint(-b, h);
                Point2D catPoint2D2 = catFactory2D1.CreatePoint(b, h);
                Point2D catPoint2D3 = catFactory2D1.CreatePoint(b, -h);
                Point2D catPoint2D4 = catFactory2D1.CreatePoint(-b, -h);

                // dann die Linien
                Line2D catLine2D1 = catFactory2D1.CreateLine(-b, h, b, h);
                catLine2D1.StartPoint = catPoint2D1;
                catLine2D1.EndPoint = catPoint2D2;

                Line2D catLine2D2 = catFactory2D1.CreateLine(b, h, b, -h);
                catLine2D2.StartPoint = catPoint2D2;
                catLine2D2.EndPoint = catPoint2D3;

                Line2D catLine2D3 = catFactory2D1.CreateLine(b, -h, -b, -h);
                catLine2D3.StartPoint = catPoint2D3;
                catLine2D3.EndPoint = catPoint2D4;

                Line2D catLine2D4 = catFactory2D1.CreateLine(-b, -h, -b, h);
                catLine2D4.StartPoint = catPoint2D4;
                catLine2D4.EndPoint = catPoint2D1;

                // Skizzierer verlassen
                catiaSketch.CloseEdition();
                // Part aktualisieren
                catiaPart.Part.Update();
                skizzeerstellt = true;
            }
            return skizzeerstellt;
        }

        public void ErzeugeBalken(Double l, bool skizzeerstellt)
        {
            // Hauptkoerper in Bearbeitung definieren
            catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;
            if (skizzeerstellt == true)
            {
                if (l > 0)
                {
                    // Hauptkoerper in Bearbeitung definieren
                    catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;

                    // Block(Balken) erzeugen
                    ShapeFactory catShapeFactory1 = (ShapeFactory)catiaPart.Part.ShapeFactory;
                    Pad catPad1 = catShapeFactory1.AddNewPad(catiaSketch, l);

                    // Block umbenennen
                    catPad1.set_Name("Balken");
                    // Block umbenennen
                    catPad1.set_Name("Balken");

                    // Part aktualisieren
                    catiaPart.Part.Update();
                    // Part aktualisieren
                    catiaPart.Part.Update();
                }
                else
                {
                    MessageBox.Show("Fehler beim Erzeugen des Körpers:\rDer Werte darf nicht null sein!");
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Erzeugen des Körpers:\rEs konnte keine Skizze erstellt werden!");
            }
        }
        public bool ErzeugeProfilDoppelTTräger(Double b, Double h)
        {
            b = b / 2;
            h = h / 2;
            if (b > 0 & h > 0)
            {
                // Skizze umbenennen
                catiaSketch.set_Name("Doppel T-Träger");

                // Rechteck in Skizze einzeichnen
                // Skizze oeffnen
                Factory2D catFactory2D1 = catiaSketch.OpenEdition();

                // Rechteck erzeugen

                // erst die Punkte
                Point2D catPoint2D1 = catFactory2D1.CreatePoint(-b, h);
                Point2D catPoint2D2 = catFactory2D1.CreatePoint(b, h);
                Point2D catPoint2D3 = catFactory2D1.CreatePoint(b, -h);
                Point2D catPoint2D4 = catFactory2D1.CreatePoint(-b, -h);

                // dann die Linien
                Line2D catLine2D1 = catFactory2D1.CreateLine(-b, h, b, h);
                catLine2D1.StartPoint = catPoint2D1;
                catLine2D1.EndPoint = catPoint2D2;

                Line2D catLine2D2 = catFactory2D1.CreateLine(b, h, b, -h);
                catLine2D2.StartPoint = catPoint2D2;
                catLine2D2.EndPoint = catPoint2D3;

                Line2D catLine2D3 = catFactory2D1.CreateLine(b, -h, -b, -h);
                catLine2D3.StartPoint = catPoint2D3;
                catLine2D3.EndPoint = catPoint2D4;

                Line2D catLine2D4 = catFactory2D1.CreateLine(-b, -h, -b, h);
                catLine2D4.StartPoint = catPoint2D4;
                catLine2D4.EndPoint = catPoint2D1;

                // Skizzierer verlassen
                catiaSketch.CloseEdition();
                // Part aktualisieren
                catiaPart.Part.Update();
                skizzeerstellt = true;
            }
            else
            {
                MessageBox.Show("Fehler beim Erstellen des Profils:\rDie Werte dürfen nicht null sein!");
                skizzeerstellt = false;
            }
            return skizzeerstellt;
        }
        
        public bool ErzeugeBalkenDoppelTTräger(Double l,bool skizzeerstellt)
        {
            if (skizzeerstellt == true)
            {
                if (l > 0)
                {
                    // Hauptkoerper in Bearbeitung definieren
                    catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;

                    // Block(Balken) erzeugen
                    ShapeFactory catShapeFactory1 = (ShapeFactory)catiaPart.Part.ShapeFactory;
                    Pad catPad1 = catShapeFactory1.AddNewPad(catiaSketch, l);                   

                    // Block umbenennen
                    catPad1.set_Name("Balken");
                    // Block umbenennen
                    catPad1.set_Name("Balken");

                    // Part aktualisieren
                    catiaPart.Part.Update();
                    // Part aktualisieren
                    catiaPart.Part.Update();
                }
                else
                {
                    MessageBox.Show("Fehler beim Erstellen des Körpers:\rDer Werte darf nicht null sein!");
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Ezeugen des Körpers:\rEs konnte keine Skizze gefunden werden!");
            }

            return skizzeerstellt;
        }
        public bool ErzeugeSkizzeTascheDoppelTTräger (double b, double h, double s, double t, bool skizzeerstellt)
        {
            if (skizzeerstellt==true)
            {
                if (b>0&h>0&s>0&t>0)
                {
                    // Skizze umbenennen
                    catiaSketch1.set_Name("Tasche");

                    // Rechteck in Skizze einzeichnen
                    // Skizze oeffnen
                    Factory2D catFactory2D1 = catiaSketch1.OpenEdition();

                    // Rechteck erzeugen

                    // erst die Punkte
                    Point2D catPoint2D1 = catFactory2D1.CreatePoint(s / 2, h / 2 - t);
                    Point2D catPoint2D2 = catFactory2D1.CreatePoint(b / 2, h / 2 - t);
                    Point2D catPoint2D3 = catFactory2D1.CreatePoint(b / 2, -(h / 2 - t));
                    Point2D catPoint2D4 = catFactory2D1.CreatePoint(s / 2, -(h / 2 - t));

                    // dann die Linien
                    Line2D catLine2D1 = catFactory2D1.CreateLine(s / 2, h / 2 - t, b / 2, h / 2 - t);
                    catLine2D1.StartPoint = catPoint2D1;
                    catLine2D1.EndPoint = catPoint2D2;

                    Line2D catLine2D2 = catFactory2D1.CreateLine(b / 2, h / 2 - t, b / 2, -(h / 2 - t));
                    catLine2D2.StartPoint = catPoint2D2;
                    catLine2D2.EndPoint = catPoint2D3;

                    Line2D catLine2D3 = catFactory2D1.CreateLine(b / 2, -(h / 2 - t), s / 2, -(h / 2 - t));
                    catLine2D3.StartPoint = catPoint2D3;
                    catLine2D3.EndPoint = catPoint2D4;

                    Line2D catLine2D4 = catFactory2D1.CreateLine(s / 2, -(h / 2 - t), s / 2, h / 2 - t);
                    catLine2D4.StartPoint = catPoint2D4;
                    catLine2D4.EndPoint = catPoint2D1;

                    // erst die Punkte
                    Point2D catPoint2D5 = catFactory2D1.CreatePoint(-s / 2, h / 2 - t);
                    Point2D catPoint2D6 = catFactory2D1.CreatePoint(-b / 2, h / 2 - t);
                    Point2D catPoint2D7 = catFactory2D1.CreatePoint(-b / 2, -(h / 2 - t));
                    Point2D catPoint2D8 = catFactory2D1.CreatePoint(-s / 2, -(h / 2 - t));

                    // dann die Linien
                    Line2D catLine2D5 = catFactory2D1.CreateLine(-s / 2, h / 2 - t, -b / 2, h / 2 - t);
                    catLine2D1.StartPoint = catPoint2D1;
                    catLine2D1.EndPoint = catPoint2D2;

                    Line2D catLine2D6 = catFactory2D1.CreateLine(-b / 2, h / 2 - t, -b / 2, -(h / 2 - t));
                    catLine2D2.StartPoint = catPoint2D2;
                    catLine2D2.EndPoint = catPoint2D3;

                    Line2D catLine2D7 = catFactory2D1.CreateLine(-b / 2, -(h / 2 - t), -s / 2, -(h / 2 - t));
                    catLine2D3.StartPoint = catPoint2D3;
                    catLine2D3.EndPoint = catPoint2D4;

                    Line2D catLine2D8 = catFactory2D1.CreateLine(-s / 2, -(h / 2 - t), -s / 2, h / 2 - t);
                    catLine2D4.StartPoint = catPoint2D4;
                    catLine2D4.EndPoint = catPoint2D1;

                    // Skizzierer verlassen
                    catiaSketch1.CloseEdition();
                    // Part aktualisieren
                    catiaPart.Part.Update();
                    skizzeerstellt = true;
                }
                else
                {
                    MessageBox.Show("Fehler beim Erstellen des Profils:\rDie Werte dürfen nicht null sein!");
                    skizzeerstellt = false;
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Erstellen des Profils:\rEs konnte keine Skizze erstellt werden!");
                skizzeerstellt = false;
            }
            

            return skizzeerstellt;
        }
        public bool ErzeugeTascheDoppelTTräger(double l,bool skizzeerstellt)
        {
            if (skizzeerstellt==true)
            {
                if (l>0)
                {
                    // Hauptkoerper in Bearbeitung definieren
                    catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;

                    // Block(Balken) erzeugen
                    ShapeFactory catShapeFactory2 = (ShapeFactory)catiaPart.Part.ShapeFactory;
                    Pocket catPocket = catShapeFactory2.AddNewPocket(catiaSketch1, -l);
                    /*Limit catLimit = catPocket.FirstLimit;
                    catLimit.LimitMode = catPocket.SecondLimit*/
                    // Block umbenennen
                    catPocket.set_Name("Tasche");

                    // Part aktualisieren
                    catiaPart.Part.Update();
                    skizzeerstellt = true;
                }
                else
                {
                    skizzeerstellt = false;
                    MessageBox.Show("Fehler beim Erzeugen der Tasche:\rDer Werte darf nicht null sein!");
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Erzeugen der Tasche:\rEs wurde keine Skizze gefunden!");
                skizzeerstellt = false;
            }
            
            
            return skizzeerstellt;
        }

        public bool ErzeugeProfilKreis(Double d)
        {
            if (d > 0)
            {
                // Skizze umbenennen
                catiaSketch.set_Name("Kreisprofil");

                // Rechteck in Skizze einzeichnen
                // Skizze oeffnen
                Factory2D catFactory2D1 = catiaSketch.OpenEdition();

                Circle2D circle2D1 = catFactory2D1.CreateClosedCircle(0, 0, d/2);
                Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
                circle2D1.CenterPoint = catPoint2D1;

                catiaSketch.CloseEdition();
                catiaPart.Part.Update();
                skizzeerstellt = true;
            }
            else
            {
                MessageBox.Show("Fehler beim Erstellen des Profils:\rDie Werte dürfen nicht null sein!");
                skizzeerstellt = false;
            }
            return skizzeerstellt;
        }

        public bool ErzeugeStange(Double d, bool skizzeerstellt)
        {
            if (skizzeerstellt == true)
            {
                if (d > 0)
                {
                    // Hauptkoerper in Bearbeitung definieren
                    catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;

                    // Block(Balken) erzeugen
                    ShapeFactory catShapeFactory1 = (ShapeFactory)catiaPart.Part.ShapeFactory;
                    Pad catPad1 = catShapeFactory1.AddNewPad(catiaSketch, d);

                    // Block umbenennen
                    catPad1.set_Name("Kreisprofil");

                    // Part aktualisieren
                    catiaPart.Part.Update();
                }
                else
                {
                    MessageBox.Show("Fehler beim Erstellen des Körpers:\rDer Werte darf nicht null sein!");
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Ezeugen des Körpers:\rEs konnte keine Skizze gefunden werden!");
            }

            return skizzeerstellt;
        }

        /*
        public bool ErzeugeProfilRohr(Double Ad)
        {
            if (Ad >0)
            {
                // Skizze umbenennen
                catiaSketch.set_Name("Rohr");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = catiaSketch.OpenEdition();

            Circle2D circle2D1 = catFactory2D1.CreateClosedCircle(0.000000, 0.000000, 20.000000);
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            circle2D1.CenterPoint = catPoint2D1;

            catiaSketch.CloseEdition();
            catiaPart.Part.Update();
                skizzeerstellt = true;
            }
            else
            {
                MessageBox.Show("Fehler beim Erstellen des Profils:\rDie Werte dürfen nicht null sein!");
                skizzeerstellt = false;
            }
            return skizzeerstellt;

        }

        public bool ErzeugeBalkenRohr(Double l, bool skizzeerstellt)
        {
            if (skizzeerstellt == true)
            {
                if (l > 0)
                {
                    // Hauptkoerper in Bearbeitung definieren
                    catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(catiaSketch, l);

            // Block umbenennen
            catPad1.set_Name("BalkenRohr");

            // Part aktualisieren
            catiaPart.Part.Update();
                }
                else
                {
                    MessageBox.Show("Fehler beim Erstellen des Körpers:\rDer Werte darf nicht null sein!");
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Ezeugen des Körpers:\rEs konnte keine Skizze gefunden werden!");
            }

            return skizzeerstellt;
        }
        public bool ErzeugeProfilTascheRohr(Double Id, bool skizzeerstellt)
        {
            if (skizzeerstellt == true)
            {
                if (Id > 0)
                {
                    // Skizze umbenennen
                    catiaSketch1.set_Name("Rohrinnen");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = catiaSketch1.OpenEdition();

            Circle2D circle2D1 = catFactory2D1.CreateClosedCircle(0.000000, 0.000000, 20.000000);
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            circle2D1.CenterPoint = catPoint2D1;

            catiaSketch1.CloseEdition();
            catiaPart.Part.Update();
                    skizzeerstellt = true;
                }
                else
                {
                    MessageBox.Show("Fehler beim Erstellen des Profils:\rDie Werte dürfen nicht null sein!");
                    skizzeerstellt = false;
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Erstellen des Profils:\rEs konnte keine Skizze erstellt werden!");
                skizzeerstellt = false;
            }


            return skizzeerstellt;

        }
        public bool ErzeugeTascheRohr(double l, bool skizzeerstellt)
        {
            if (skizzeerstellt == true)
            {
                if (l > 0)
                {
                    // Hauptkoerper in Bearbeitung definieren
                    catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory2 = (ShapeFactory)catiaPart.Part.ShapeFactory;
            Pocket catPocket = catShapeFactory2.AddNewPocket(catiaSketch1, -l);
            /*Limit catLimit = catPocket.FirstLimit;
            catLimit.LimitMode = catPocket.SecondLimit
            // Block umbenennen
            catPocket.set_Name("TascheRohr");

            // Part aktualisieren
            catiaPart.Part.Update();
                    skizzeerstellt = true;
                }
                else
                {
                    skizzeerstellt = false;
                    MessageBox.Show("Fehler beim Erzeugen der Tasche:\rDer Werte darf nicht null sein!");
                }
            }
            else
            {
                MessageBox.Show("Fehler beim Erzeugen der Tasche:\rEs wurde keine Skizze gefunden!");
                skizzeerstellt = false;
            }


            return skizzeerstellt;
        } 
        */

        public CatiaCon()
        {

        }
    
    }
}
