﻿using System;
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
        ProductDocument activedocproduct;
        Product product1;
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
            bool bla = true;
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
                    bla = true;
                }
                catch
                {
                    MessageBox.Show("Teilenummer konnte nicht ermittelt werden");
                    bla = false;
                }
            }

            partnummer1 = product1.get_PartNumber();
            inputBoxEingabe = Interaction.InputBox("Möchten Sie dem Part eine neue Teilenummer zuweisen?", "Zugriff auf Catia V5", partnummer1);
            if ((string)inputBoxEingabe == "")
            {
                inputBoxEingabe = partnummer1;
            }
            product1.set_PartNumber(ref inputBoxEingabe);

            return bla;

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
            OriginElements catOriginElements = catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            catiaSketch = catSketches1.Add(catReference1);

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

        public void ErzeugeProfilRechteck(Double b, Double h)
        {
            // Skizze umbenennen
            catiaSketch.set_Name("Rechteck");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = catiaSketch.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-50, 50);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(50, 50);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(50, -50);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-50, -50);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-50, 50, 50, 50);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(50, 50, 50, -50);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(50, -50, -50, -50);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-50, -50, -50, 50);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            catiaSketch.CloseEdition();
            // Part aktualisieren
            catiaPart.Part.Update();
        }

        public void ErzeugeBalken(Double l)
        {
            // Hauptkoerper in Bearbeitung definieren
            catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(catiaSketch, l);

            // Block umbenennen
            catPad1.set_Name("Balken");

            // Part aktualisieren
            catiaPart.Part.Update();
        }
        public void ErzeugeProfilDoppelTTräger(Double b, Double h)
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
            Line2D catLine2D1 = catFactory2D1.CreateLine(-b, b, h, h);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(b, b, h, -h);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(b, -b, -h, -h);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-b, -b, -h, h);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            catiaSketch.CloseEdition();
            // Part aktualisieren
            catiaPart.Part.Update();
        }
        public void ErzeugeBalkenDoppelTTräger(Double l)
        {
            // Hauptkoerper in Bearbeitung definieren
            catiaPart.Part.InWorkObject = catiaPart.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(catiaSketch, l);

            // Block umbenennen
            catPad1.set_Name("Balken");

            // Part aktualisieren
            catiaPart.Part.Update();
        }
        public CatiaCon()
        {

        }
    
    }
}
