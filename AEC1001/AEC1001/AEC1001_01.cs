
// ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
// frmAEC1001                                                          #0000 Inhaltsverzeichnis
// ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




// 20260826-1800 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q

// frmAEC1001_01                                                       #1000 Load
// frmAEC1001_01                                                       #1001 AEC1001
// frmAEC1001_01                                                       #1002 AEC1002
// frmAEC1001_01                                                       #1003 AEC1003
// frmAEC1001_01                                                       #1004 AEC1004
// frmAEC1001_01                                                       #1005 AEC1005


// frmAEC1001_01                                                       #1012 AEC1012

// frmAEC1001_01                                                       #1014 AEC1014

// frmAEC1001_01                                                       #1020 AEC1020





using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using AcOpenMode = Autodesk.AutoCAD.DatabaseServices.OpenMode;
using Application = Autodesk.AutoCAD.ApplicationServices.Application; // Mehrdeutigkeit auflösen
using WinIO = System.IO;

// Löst die Mehrdeutigkeit mit System.IO oder VB-Konstanten auf:
using OpenMode = Autodesk.AutoCAD.DatabaseServices.OpenMode;




namespace AEC1001

{
    public partial class frmAEC1001_01 : Form
    {
        // Definiert den Befehl, der in AutoCAD eingetippt wird
        [CommandMethod("AEC#")]
        public void ConnectToAutoCAD()
        {
            // 1. Zugriff auf das aktive Dokument und die Applikation
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            // 2. Zugriff auf die Datenbank und den Editor (Befehlszeile) des Dokuments
            Database db = doc.Database;
            Editor ed = doc.Editor;

            // Erfolgsmeldung in der AutoCAD-Kommandozeile ausgeben
            ed.WriteMessage("\n[Erfolg] Verbindung mit der AutoCAD .NET API erfolgreich hergestellt!");
        }

        public frmAEC1001_01()
        {
            // Initialisiert alle visuellen Komponenten aus dem Designer
            InitializeComponent();
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001                                                          #1000 Load
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // 20260825-0800 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q
        private void FrmAEC1001_01_Load(object sender, EventArgs e)
        {
            // ----------
            // 0100INF0002 Form Size
            // ----------

            this.Left = 100;
            this.Top = 100;

            this.Width = 465; // 320
            this.Height = 1005; // 970
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1001 AEC1001
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // Öffne FrmAEC0001.exe


        // 20260825-1100 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q
        [CommandMethod("AEC1001")]
        public void AEC1001()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            string exePath = @"E:\AEC1001 AEX\AEC1001\AEC1001\bin\x64\Debug\net10.0-windows10.0.26100.0\AEC1001.exe";

            try
            {
                if (!System.IO.File.Exists(exePath))
                {
                    doc.Editor.WriteMessage($"\nFehler: Datei '{exePath}' nicht gefunden.");
                    return;
                }

                doc.Editor.WriteMessage("\nStarte AEC1001.exe...");
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = exePath, UseShellExecute = true });

                string? folderPath = System.IO.Path.GetDirectoryName(exePath);
                if (!string.IsNullOrEmpty(folderPath) && System.IO.Directory.Exists(folderPath))
                {
                    doc.Editor.WriteMessage($"\nÖffne Explorer-Pfad: {folderPath}");
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "explorer.exe", Arguments = $"\"{folderPath}\"", UseShellExecute = true });
                }
            }
            catch (System.Exception ex)
            {
                doc.Editor.WriteMessage($"\nFehler beim Ausführen: {ex.Message}");
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1002 AEC1002
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // LayerLeer aktuell


        [CommandMethod("AEC1002")]
        public void AEC1002()
        {
            Document? doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            Database db = doc.Database;
            Editor ed = doc.Editor;

            string layerName = "000#90001#0001-00000#0000-01 LayerLeer";
            ObjectId layerId = ObjectId.Null;

            // Modernes 'using' ohne geschweifte Klammern für die Transaktion
            using var trans = db.TransactionManager.StartTransaction();
            try
            {
                // KORREKTUR: Eindeutiger OpenMode-Pfad für .NET 10
                if (trans.GetObject(db.LayerTableId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) is not LayerTable lt) return;

                if (lt.Has(layerName))
                {
                    // KORREKTUR: Eindeutiger OpenMode-Pfad für .NET 10
                    if (trans.GetObject(lt[layerName], Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite) is not LayerTableRecord ltr) return;

                    // Vorab-Prüfung, ob der Layer bereits der aktuelle Layer ist
                    if (db.Clayer == ltr.ObjectId)
                    {
                        ed.WriteMessage($"\n[AEC1002] Hinweis: Der Layer '{layerName}' ist bereits der aktuelle Layer.");
                        return;
                    }

                    // Eigenschaften ändern/reaktivieren
                    ltr.IsFrozen = false;
                    ltr.IsLocked = false;
                    ltr.IsOff = false;

                    layerId = ltr.ObjectId;
                    trans.Commit();
                }
                else
                {
                    ed.WriteMessage($"\n[AEC1002] Layer '{layerName}' nicht gefunden.");
                    return;
                }

                // Layer-Wechsel sicher nach dem Commit ausführen
                if (layerId != ObjectId.Null)
                {
                    db.Clayer = layerId;
                    ed.Regen();
                    ed.WriteMessage($"\n[AEC1002] {"".PadLeft(15)} L a y e r L e e r {"".PadLeft(10)} aufgetaut, entsperrt und als AKTUELL gesetzt.");
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\n[AEC1002] Fehler: {ex.Message}");
                trans.Abort();
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1003 AEC1003
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // LayerNull [0] aktuell


        [CommandMethod("AEC1003")]
        public void AEC1003()
        {
            Document? doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            Database db = doc.Database;
            Editor ed = doc.Editor;

            string layerName = "0";
            ObjectId layerId = ObjectId.Null;

            // Modernes 'using' ohne geschweifte Klammern für die Transaktion
            using var trans = db.TransactionManager.StartTransaction();
            try
            {
                // KORREKTUR: Eindeutiger OpenMode-Pfad für .NET 10
                if (trans.GetObject(db.LayerTableId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) is not LayerTable lt) return;

                if (lt.Has(layerName))
                {
                    // KORREKTUR: Eindeutiger OpenMode-Pfad für .NET 10
                    if (trans.GetObject(lt[layerName], Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite) is not LayerTableRecord ltr) return;

                    // Vorab-Prüfung, ob der Layer bereits der aktuelle Layer ist
                    if (db.Clayer == ltr.ObjectId)
                    {
                        ed.WriteMessage($"\n[AEC1003] Hinweis: Der Layer '{layerName}' ist bereits der aktuelle Layer.");
                        return;
                    }

                    // Eigenschaften ändern/reaktivieren
                    ltr.IsFrozen = false;
                    ltr.IsLocked = false;
                    ltr.IsOff = false;

                    layerId = ltr.ObjectId;
                    trans.Commit();
                }
                else
                {
                    ed.WriteMessage($"\n[AEC1003] Layer '{layerName}' nicht gefunden.");
                    return;
                }

                // Layer-Wechsel sicher nach dem Commit ausführen
                if (layerId != ObjectId.Null)
                {
                    db.Clayer = layerId;
                    ed.Regen();
                    ed.WriteMessage($"\n[AEC1003] {"".PadLeft(15)} L a y e r N u l l {"".PadLeft(10)} aufgetaut, entsperrt und als AKTUELL gesetzt.");
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\n[AEC1003] Fehler: {ex.Message}");
                trans.Abort();
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1005 AEC1004
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // Die Routine AEC1004 ermittelt vollautomatisch den mathematischen Schwerpunkt (Centroid) einer ausgewählten Region oder
        // planaren Oberfläche (PlaneSurface) und platziert an dieser Position ein AutoCAD-Punkt-Objekt (DBPoint).


        [CommandMethod("AEC1004")]
        public void AEC1004()
        {
            Document? doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            Database db = doc.Database;
            Editor ed = doc.Editor;

            // 1. Filter für die Auswahl definieren
            PromptEntityOptions options = new("\nWählen Sie eine Region oder eine planare Fläche aus:");
            options.SetRejectMessage("Das ausgewählte Objekt ist keine Region und keine planare Fläche.");
            options.AddAllowedClass(typeof(Autodesk.AutoCAD.DatabaseServices.Region), true);
            options.AddAllowedClass(typeof(Autodesk.AutoCAD.DatabaseServices.PlaneSurface), true);

            // 2. Objekt vom Benutzer auswählen lassen
            PromptEntityResult result = ed.GetEntity(options);
            if (result.Status != PromptStatus.OK) return;

            // Modernes 'using' ohne geschweifte Klammern für die Transaktion
            using var tr = db.TransactionManager.StartTransaction();
            try
            {
                // Objekt aus der Datenbank öffnen
                if (tr.GetObject(result.ObjectId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) is not Entity entity) return;

                Point3d centroid = new Point3d();
                bool schwerpunktGefunden = false;

                // 3. Fall A: Das Objekt ist eine Region
                if (entity is Autodesk.AutoCAD.DatabaseServices.Region region)
                {
                    using Plane regionPlane = region.GetPlane();
                    CoordinateSystem3d cs = regionPlane.GetCoordinateSystem();
                    Point3d origin = cs.Origin;
                    Vector3d xAxis = cs.Xaxis;
                    Vector3d yAxis = cs.Yaxis;

                    RegionAreaProperties areaProps = region.AreaProperties(ref origin, ref xAxis, ref yAxis);
                    centroid = regionPlane.EvaluatePoint(areaProps.Centroid);
                    schwerpunktGefunden = true;
                }
                // 4. Fall B: Das Objekt ist eine PlaneSurface (Assoziative Fläche)
                else if (entity is Autodesk.AutoCAD.DatabaseServices.PlaneSurface planeSurface)
                {
                    // Trick: Wir holen uns die Grenzkurven der planaren Fläche
                    using DBObjectCollection curves = new();
                    planeSurface.Explode(curves);

                    if (curves.Count > 0)
                    {
                        // Aus den Kurven eine temporäre Region erzeugen, um die MassProperties zu nutzen
                        using DBObjectCollection regions = Autodesk.AutoCAD.DatabaseServices.Region.CreateFromCurves(curves);
                        if (regions.Count > 0 && regions[0] is Autodesk.AutoCAD.DatabaseServices.Region tempRegion)
                        {
                            using Plane tempPlane = tempRegion.GetPlane();
                            CoordinateSystem3d cs = tempPlane.GetCoordinateSystem();
                            Point3d origin = cs.Origin;
                            Vector3d xAxis = cs.Xaxis;
                            Vector3d yAxis = cs.Yaxis;

                            RegionAreaProperties areaProps = tempRegion.AreaProperties(ref origin, ref xAxis, ref yAxis);
                            centroid = tempPlane.EvaluatePoint(areaProps.Centroid);
                            schwerpunktGefunden = true;
                        }
                    }
                }

                // Sicherheitsabbruch, falls der Schwerpunkt nicht berechnet werden konnte
                if (!schwerpunktGefunden)
                {
                    ed.WriteMessage("\n[AEC1004] Fehler: Schwerpunkt konnte nicht berechnet werden.");
                    return;
                }

                // 5. Aktuellen Space öffnen (Model Space oder Layout)
                if (tr.GetObject(db.CurrentSpaceId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite) is not BlockTableRecord blockTableRec) return;

                // 6. Neues AutoCAD-Punkt-Objekt am Schwerpunkt erstellen
                DBPoint acPoint = new DBPoint(centroid);

                // Punkt der Zeichnung hinzufügen
                blockTableRec.AppendEntity(acPoint);
                tr.AddNewlyCreatedDBObject(acPoint, true);

                // Transaktion speichern
                tr.Commit();

                // Erfolgsmeldung und Koordinatenausgabe in der Befehlszeile
                ed.WriteMessage($"\n[AEC1004] Schwerpunkt gefunden bei X:{centroid.X:F2}, Y:{centroid.Y:F2}, Z:{centroid.Z:F2}. Punkt wurde erstellt.");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\n[AEC1004] Fehler: {ex.Message}");
                tr.Abort();
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1005 AEC1005
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // Diese Routine ermittelt vollautomatisch den mathematischen Schwerpunkt (Centroid) eines angeklickten 3D-Volumenkörpers
        // und platziert an genau dieser Koordinate ein AutoCAD-Punkt-Objekt (DBPoint).


        [CommandMethod("AEC1005")]
        public void AEC1005()
        {
            Document? doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            Database db = doc.Database;
            Editor ed = doc.Editor;

            // 1. Filter für die Auswahl definieren (Nur 3D-Solids zulassen) - KORREKTUR: \n statt Constants.vbLf
            PromptEntityOptions options = new("\nWählen Sie einen Volumenkörper (3D-Solid):");
            options.SetRejectMessage("Ausgewähltes Objekt ist kein Volumenkörper.");
            options.AddAllowedClass(typeof(Solid3d), true);

            // 2. Objekt vom Benutzer auswählen lassen
            PromptEntityResult result = ed.GetEntity(options);
            if (result.Status != PromptStatus.OK) return;

            // Modernes 'using' ohne geschweifte Klammern für die Transaktion
            using var tr = db.TransactionManager.StartTransaction();
            try
            {
                // Volumenkörper öffnen - KORREKTUR: Eindeutiger OpenMode-Pfad
                if (tr.GetObject(result.ObjectId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) is not Solid3d solid) return;

                // 4. Schwerpunkt (Centroid) auslesen
                Point3d centroid = solid.MassProperties.Centroid;

                // 5. Aktuellen Space öffnen - KORREKTUR: Eindeutiger OpenMode-Pfad
                if (tr.GetObject(db.CurrentSpaceId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite) is not BlockTableRecord blockTableRec) return;

                // 6. Neues AutoCAD-Punkt-Objekt am Schwerpunkt erstellen
                using DBPoint acPoint = new(centroid);

                // Punkt der Zeichnung hinzufügen
                blockTableRec.AppendEntity(acPoint);
                tr.AddNewlyCreatedDBObject(acPoint, true);

                // Transaktion speichern
                tr.Commit();

                // Erfolgsmeldung - KORREKTUR: Modernes String-Format ($) und \n statt vbLf
                ed.WriteMessage($"\n[AEC1005] Schwerpunkt gefunden bei X:{centroid.X:F2}, Y:{centroid.Y:F2}, Z:{centroid.Z:F2}. Punkt wurde erstellt.");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\n[AEC1005] Fehler: {ex.Message}");
                tr.Abort();
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1012 AEC1012
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // Diese Routine richtet einen ausgewählten Text/MText im Raum über eine 3D-Ausrichtungsmatrix aus.


        // 20260826-1600 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q
        [CommandMethod("AEC1012")]
        public void AEC1012()
        {
            Document? doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            Editor ed = doc.Editor;

            try
            {
                PromptEntityOptions entOpts = new("\nWählen Sie den auszurichtenden Text (TEXT/MTEXT) aus: ");
                entOpts.SetRejectMessage("Das gewählte Objekt muss ein TEXT oder MTEXT sein.");
                entOpts.AddAllowedClass(typeof(DBText), false);
                entOpts.AddAllowedClass(typeof(MText), false);

                PromptEntityResult entRes = ed.GetEntity(entOpts);
                if (entRes.Status != PromptStatus.OK) return;

                PromptPointResult p1 = ed.GetPoint("\nErsten Zielpunkt angeben (Einfügepunkt): "); if (p1.Status != PromptStatus.OK) return;

                PromptPointOptions pOpt2 = new("\nWählen Sie den zweiten Zielpunkt (X-Achse): ") { UseBasePoint = true, BasePoint = p1.Value };
                PromptPointResult p2 = ed.GetPoint(pOpt2); if (p2.Status != PromptStatus.OK) return;

                PromptPointOptions pOpt3 = new("\nWählen Sie den dritten Zielpunkt (3D-Ebene): ") { UseBasePoint = true, BasePoint = p1.Value };
                PromptPointResult p3 = ed.GetPoint(pOpt3); if (p3.Status != PromptStatus.OK) return;

                using var tr = doc.Database.TransactionManager.StartTransaction();

                // KORREKTUR: Eindeutiger OpenMode-Pfad für .NET 10
                if (tr.GetObject(entRes.ObjectId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite) is not Entity ent) return;

                Point3d sOrg;
                Vector3d sNormal, sX;

                if (ent is DBText dbTxt)
                {
                    (sOrg, sNormal) = (dbTxt.Position, dbTxt.Normal);
                    sX = new Vector3d(Math.Cos(dbTxt.Rotation), Math.Sin(dbTxt.Rotation), 0).TransformBy(Matrix3d.PlaneToWorld(sNormal)).GetNormal();
                }
                else if (ent is MText mTxt)
                {
                    (sOrg, sNormal, sX) = (mTxt.Location, mTxt.Normal, mTxt.Direction.GetNormal());
                }
                else return;

                CoordinateSystem3d srcCS = new(sOrg, sX, sNormal.CrossProduct(sX).GetNormal());

                Vector3d tX = p1.Value.GetVectorTo(p2.Value);
                Vector3d v13 = p1.Value.GetVectorTo(p3.Value);
                Vector3d tZRaw = tX.CrossProduct(v13);

                if (tX.IsZeroLength() || v13.IsZeroLength() || tZRaw.IsZeroLength())
                {
                    ed.WriteMessage("\n[AEC1012] Fehler: Ungültige Geometrie (Punkte identisch oder auf einer Linie).");
                    return;
                }

                Vector3d tXNorm = tX.GetNormal();
                Vector3d tZNorm = tZRaw.GetNormal();
                CoordinateSystem3d tgtCS = new(p1.Value, tXNorm, tZNorm.CrossProduct(tXNorm).GetNormal());

                ent.TransformBy(Matrix3d.AlignCoordinateSystem(srcCS.Origin, srcCS.Xaxis, srcCS.Yaxis, srcCS.Zaxis, tgtCS.Origin, tgtCS.Xaxis, tgtCS.Yaxis, tgtCS.Zaxis));

                tr.Commit();
                ed.WriteMessage("\n[AEC1012] Text erfolgreich per 3D-Matrix ausgerichtet.");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\n[AEC1012] Fehler: {ex.Message}");
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1014 AEC1014
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // 3D-Align für Volumenkörper: Einmalig 3 Basispunkte wählen dann 3 Zielpunkte wählen, Körper wird kopiert und auf Ziel-
        // punkten abgelegt. Anschließend wieder drei Zielpunkte wählen, Körper wird kopiert und auf Zielpunkten abgelegt ...


        // 20260826-1600 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q
        private class SolidAlignJig : DrawJig
        {
            private readonly Entity? _preview;
            private readonly Point3d _sOrg;
            private readonly CoordinateSystem3d _srcCS;
            private readonly Point3d _tOrg;
            private Point3d _tXPt, _tYPt;

            public int CurrentStep { get; set; } = 2;

            public SolidAlignJig(Entity? ent, Point3d sOrg, CoordinateSystem3d sCS, Point3d tOrg)
            {
                _preview = ent?.Clone() as Entity;
                (_sOrg, _srcCS, _tOrg) = (sOrg, sCS, tOrg);
                (_tXPt, _tYPt) = (tOrg + sCS.Xaxis, tOrg + sCS.Yaxis);
            }

            public void CleanUp() => (_preview as IDisposable)?.Dispose();

            public Matrix3d GetCurrentMatrix()
            {
                Vector3d tX = _tOrg.GetVectorTo(_tXPt).GetNormal();
                Vector3d tYTmp = CurrentStep == 2 ? tX.GetPerpendicularVector() : _tOrg.GetVectorTo(_tYPt);
                Vector3d tZ = tX.CrossProduct(tYTmp).GetNormal();
                Vector3d tY = tZ.CrossProduct(tX).GetNormal();

                return Matrix3d.AlignCoordinateSystem(_sOrg, _srcCS.Xaxis, _srcCS.Yaxis, _srcCS.Zaxis, _tOrg, tX, tY, tZ);
            }

            protected override bool WorldDraw(Autodesk.AutoCAD.GraphicsInterface.WorldDraw? d)
            {
                if (_preview == null || d?.Geometry == null) return true;

                d.Geometry.PushModelTransform(GetCurrentMatrix());
                d.Geometry.Draw(_preview);
                d.Geometry.PopModelTransform();
                return true;
            }

            protected override SamplerStatus Sampler(JigPrompts? prompts)
            {
                if (prompts == null) return SamplerStatus.Cancel;

                string promptMsg = CurrentStep == 2 ? "\nZielpunkt für X-Achse angeben: " : "\nZielpunkt für Y-Achse angeben: ";

                JigPromptPointOptions opts = new(promptMsg)
                {
                    UserInputControls = UserInputControls.Accept3dCoordinates,
                    UseBasePoint = true,
                    BasePoint = _tOrg
                };

                PromptPointResult res = prompts.AcquirePoint(opts);
                if (res.Status != PromptStatus.OK) return SamplerStatus.Cancel;

                if (CurrentStep == 2) _tXPt = res.Value; else _tYPt = res.Value;
                return SamplerStatus.OK;
            }
        }

        public class AEC1014Routine
        {
            [CommandMethod("AEC1014")]
            public void AEC1014()
            {
                Document? doc = Application.DocumentManager.MdiActiveDocument;
                if (doc == null) return;

                Editor ed = doc.Editor;

                PromptEntityOptions entOpts = new("\nWählen Sie einen 3D-Volumenkörper für die Ausrichtung aus: ");
                entOpts.SetRejectMessage("\nDas gewählte Objekt ist kein gültiger 3D-Volumenkörper!");
                entOpts.AddAllowedClass(typeof(Solid3d), false);

                PromptEntityResult entRes = ed.GetEntity(entOpts);
                if (entRes.Status != PromptStatus.OK) return;

                // Modernes 'using var' spart geschweifte Klammern für die gesamte Transaktion
                using var tr = doc.Database.TransactionManager.StartTransaction();
                try
                {
                    // KORREKTUR: Eindeutiger OpenMode-Pfad für .NET 10
                    if (tr.GetObject(entRes.ObjectId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) is not Solid3d solid) return;

                    // Quellpunkte einlesen
                    PromptPointResult p1 = ed.GetPoint("\nErsten Quellpunkt angeben (Basis): "); if (p1.Status != PromptStatus.OK) return;
                    PromptPointResult p2 = ed.GetPoint("\nZweiten Quellpunkt angeben (X-Achse): "); if (p2.Status != PromptStatus.OK) return;
                    PromptPointResult p3 = ed.GetPoint("\nDritten Quellpunkt angeben (Y-Achse): "); if (p3.Status != PromptStatus.OK) return;

                    // Quell-Koordinatensystem aufbauen
                    Vector3d sX = p1.Value.GetVectorTo(p2.Value).GetNormal();
                    Vector3d sZ = sX.CrossProduct(p1.Value.GetVectorTo(p3.Value)).GetNormal();
                    CoordinateSystem3d srcCS = new(p1.Value, sX, sZ.CrossProduct(sX).GetNormal());

                    int loopCount = 0;
                    while (true)
                    {
                        PromptPointResult tgtRes = ed.GetPoint("\nNächsten Ziel-Basispunkt angeben (oder ESC): ");
                        if (tgtRes.Status != PromptStatus.OK) break;

                        SolidAlignJig jig = new(solid, p1.Value, srcCS, tgtRes.Value);

                        jig.CurrentStep = 2; if (ed.Drag(jig).Status != PromptStatus.OK) { jig.CleanUp(); break; }
                        jig.CurrentStep = 3; if (ed.Drag(jig).Status != PromptStatus.OK) { jig.CleanUp(); break; }

                        if (solid.Clone() is not Solid3d cloned) { jig.CleanUp(); break; }

                        cloned.TransformBy(jig.GetCurrentMatrix());
                        jig.CleanUp();

                        // KORREKTUR: Eindeutiger OpenMode-Pfad für den aktuellen Speicherbereich
                        if (tr.GetObject(doc.Database.CurrentSpaceId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite) is BlockTableRecord currentSpace)
                        {
                            currentSpace.AppendEntity(cloned);
                            tr.AddNewlyCreatedDBObject(cloned, true);
                            ed.WriteMessage($"\n[AEC1014] Kopie {++loopCount} erfolgreich platziert.");
                        }
                    }

                    tr.Commit();
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage($"\n[AEC1014] Fehler: {ex.Message}");
                    tr.Abort();
                }
            }






            // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
            // frmAEC1001_01                                                       #1020 AEC1020
            // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




            // 20260826-1400 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q
            [CommandMethod("AEC1020")]
            public void AEC1020()
            {
                Document? doc = Application.DocumentManager.MdiActiveDocument;
                if (doc == null) return;

                Database db = doc.Database;
                Editor ed = doc.Editor;

                // 1. Blockreferenz vom Benutzer auswählen lassen
                PromptEntityOptions peo = new("\nWählen Sie eine Blockreferenz aus: ");
                peo.SetRejectMessage("\nDas gewählte Objekt ist kein Block.");
                peo.AddAllowedClass(typeof(BlockReference), true);

                PromptEntityResult per = ed.GetEntity(peo);
                if (per.Status != PromptStatus.OK) return;

                // Modernes 'using' ohne geschweifte Klammern für die Transaktion
                using var trans = db.TransactionManager.StartTransaction();
                try
                {
                    BlockReference? blockRef = trans.GetObject(per.ObjectId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockReference;
                    if (blockRef == null) return;

                    BlockTableRecord? blockDef = trans.GetObject(blockRef.BlockTableRecord, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockTableRecord;
                    if (blockDef == null) return;

                    BlockTable? bt = trans.GetObject(db.BlockTableId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockTable;
                    if (bt == null) return;

                    BlockTableRecord? modelSpace = trans.GetObject(bt[BlockTableRecord.ModelSpace], Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockTableRecord;
                    if (modelSpace == null) return;

                    // Layer-Sperrenprüfung aus der alten Variante übernommen
                    if (trans.GetObject(blockRef.LayerId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) is LayerTableRecord blockLayer && blockLayer.IsLocked)
                    {
                        ed.WriteMessage($"\n[AEC1020] Fehler: Layer '{blockLayer.Name}' ist gesperrt. Abbruch.");
                        return;
                    }

                    bool? bestimmterNeuerZustand = null;
                    int trefferZaehler = 0;

                    // 2. Schleife durch Objekte im Block
                    foreach (ObjectId entId in blockDef)
                    {
                        DBObject obj = trans.GetObject(entId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead);
                        if (obj is not DBPoint bPoint) continue;

                        // Koordinaten-Transformation in den echten Modellbereich
                        Point3d wcsPointPosition = bPoint.Position.TransformBy(blockRef.BlockTransform);

                        // 3. Im Modellbereich nach Texten suchen (Toleranzprüfung < 0.1)
                        foreach (ObjectId msId in modelSpace)
                        {
                            if (msId.IsErased) continue;
                            DBObject msObj = trans.GetObject(msId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead);

                            // Ruft die ausgelagerte, klammeroptimierte Hilfsmethode auf
                            UpdateTextVisibility(msObj, wcsPointPosition, ref bestimmterNeuerZustand, ref trefferZaehler);
                        }
                    }

                    trans.Commit();
                    ed.Regen();

                    string statusInfo = bestimmterNeuerZustand == true ? "sichtbar" : "unsichtbar";
                    ed.WriteMessage(trefferZaehler > 0
                        ? $"\n[AEC1020] Erfolg! {trefferZaehler} Texte wurden {statusInfo} geschaltet.\n"
                        : "\n[AEC1020] Keine passenden Texte an den Koordinaten gefunden.\n");
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage("\n[AEC1020] Kritischer Fehler: " + ex.Message);
                    trans.Abort();
                }
            }

            // Hilfsmethode zur Auslagerung der Text-Prüfung (spart geschweifte Klammern)
            private void UpdateTextVisibility(DBObject obj, Point3d targetPos, ref bool? newStatus, ref int counter)
            {
                if (obj is DBText txt && targetPos.DistanceTo(txt.Position) < 0.1)
                {
                    newStatus ??= !txt.Visible;
                    if (txt.Visible == newStatus) return;

                    txt.UpgradeOpen();
                    txt.Visible = (bool)newStatus;
                    counter++;
                }
                else if (obj is MText mtxt && targetPos.DistanceTo(mtxt.Location) < 0.1)
                {
                    newStatus ??= !mtxt.Visible;
                    if (mtxt.Visible == newStatus) return;

                    mtxt.UpgradeOpen();
                    mtxt.Visible = (bool)newStatus;
                    counter++;
                }
            }
        }

        private void Lbl0204_Click(object sender, EventArgs e)
        {

        }





        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1021 AEC1021 Teil 1
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // 20260827-1600 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q





        [CommandMethod("AEC1021")]
        public void AEC1021()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            try
            {
                // =================================================================
                // ASYNCHRONER TIMEOUT-DIALOG (WINFORMS)
                // =================================================================

                using (var infoForm = new System.Windows.Forms.Form())
                  
                {
                    infoForm.Text = "AEC1021 " + new string(' ', 18) + " 6 s" + new string(' ', 18) + " Information";
                    infoForm.Size = new System.Drawing.Size(480, 160);
                    infoForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    infoForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                    infoForm.MaximizeBox = false;
                    infoForm.MinimizeBox = false;
                    infoForm.ShowInTaskbar = false;

                    var lblText = new System.Windows.Forms.Label
                    {
                        // Fügt eine Leerzeile ganz am Anfang ein und setzt den Text auf 6 Sekunden
                        Text = Environment.NewLine + 
                               $"Ursprung Aktuelles BKS   X - R i c h t u n g   !{Environment.NewLine}" +
                               $"Knotennummerierung   1   3   5   7   9   …",
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.TopCenter, // Auf TopCenter geändert, damit die Leerzeile oben wirkt
                        Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular)
                    };
                    infoForm.Controls.Add(lblText);

                    // WICHTIG: Den Timer auf 6 Sekunden (6000 Millisekunden) anpassen
                    var formTimer = new System.Windows.Forms.Timer { Interval = 6000 };

                    formTimer.Tick += (sender, e) => { formTimer.Stop(); infoForm.Close(); formTimer.Dispose(); };
                    formTimer.Start();

                    infoForm.ShowDialog(new AutoCADWindowWrapper(Application.MainWindow.Handle));
                }

                // 1. Abfrage der Texthöhe mit Keyword-Validierung
                double finaleHoehe = 0.035;
                var pdo = new PromptDoubleOptions($"\nAbsolute Texthöhe eingeben <{finaleHoehe}>:")
                {
                    AllowNone = true,
                    AllowNegative = false,
                    AllowZero = false
                };

                PromptDoubleResult pdr = ed.GetDouble(pdo);
                if (pdr.Status == PromptStatus.OK) finaleHoehe = pdr.Value;
                else if (pdr.Status == PromptStatus.Cancel) return;

                // 2. Auswahl der Blockreferenz
                var peoBlock = new PromptEntityOptions("\nBlock auswählen, der die Polylinien und Punkte enthält:");
                peoBlock.SetRejectMessage("Es muss eine Blockreferenz sein.");
                peoBlock.AddAllowedClass(typeof(BlockReference), true);

                PromptEntityResult perBlock = ed.GetEntity(peoBlock);
                if (perBlock.Status != PromptStatus.OK) return;

                Matrix3d bksMatrix = ed.CurrentUserCoordinateSystem;
                Matrix3d weltInBksMatrix = bksMatrix.Inverse();

                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    var blkRef = (BlockReference)tr.GetObject(perBlock.ObjectId, OpenMode.ForRead);
                    ObjectId blockLayerId = blkRef.LayerId;
                    var blockDef = (BlockTableRecord)tr.GetObject(blkRef.BlockTableRecord, OpenMode.ForRead);
                    Matrix3d blockTransform = blkRef.BlockTransform;

                    var allePunkteWcs = new List<Point3d>();
                    var gefundenePolylinienWcs = new List<Curve>();

                    foreach (ObjectId id in blockDef)
                    {
                        Entity ent = (Entity)tr.GetObject(id, OpenMode.ForRead);

                        if (ent is DBPoint p)
                        {
                            allePunkteWcs.Add(p.Position.TransformBy(blockTransform));
                        }
                        else if (ent is Polyline || ent is Polyline2d || ent is Polyline3d)
                        {
                            Curve wcsKurve = (Curve)ent.Clone();
                            wcsKurve.TransformBy(blockTransform);
                            gefundenePolylinienWcs.Add(wcsKurve);
                        }
                    }

                    // Fehlerprüfung 1: Kurvenanzahl prüfen
                    if (gefundenePolylinienWcs.Count != 2)
                    {
                        ed.WriteMessage($"\nFehler: Der Block muss EXAKT zwei Polylinien enthalten! (Gefunden: {gefundenePolylinienWcs.Count})");
                        foreach (Curve c in gefundenePolylinienWcs) c.Dispose();
                        tr.Abort();
                        return;
                    }

                    // Fehlerprüfung 2: Sicherstellen, dass Punkte existieren
                    if (allePunkteWcs.Count == 0)
                    {
                        ed.WriteMessage("\nFehler: Der ausgewählte Block enthält keine Punkt-Objekte!");
                        foreach (Curve c in gefundenePolylinienWcs) c.Dispose();
                        tr.Abort();
                        return;
                    }

                    Curve polyA = gefundenePolylinienWcs[0];
                    Curve polyB = gefundenePolylinienWcs[1];

                    var punkteA_Raw = new List<(Point3d Pt, double X)>();
                    var punkteB_Raw = new List<(Point3d Pt, double X)>();

                    foreach (Point3d ptWcs in allePunkteWcs)
                    {
                        try
                        {
                            double distA = ptWcs.DistanceTo(polyA.GetClosestPointTo(ptWcs, false));
                            double distB = ptWcs.DistanceTo(polyB.GetClosestPointTo(ptWcs, false));
                            double bksX = ptWcs.TransformBy(weltInBksMatrix).X;

                            if (distA <= distB) punkteA_Raw.Add((ptWcs, bksX));
                            else punkteB_Raw.Add((ptWcs, bksX));
                        }
                        catch { }
                    }

                    var punkteA = punkteA_Raw.OrderBy(p => p.X).Select(p => p.Pt).ToList();
                    var punkteB = punkteB_Raw.OrderBy(p => p.X).Select(p => p.Pt).ToList();

                    // Ausfallsichere Berechnung der Y-Mittelwerte
                    double avgYA = punkteA.Count > 0 ? punkteA.Average(p => p.TransformBy(weltInBksMatrix).Y) : 0.0;
                    double avgYB = punkteB.Count > 0 ? punkteB.Average(p => p.TransformBy(weltInBksMatrix).Y) : 0.0;

                    var basisPunkte = avgYA <= avgYB ? punkteA : punkteB;
                    var entferntePunkte = avgYA <= avgYB ? punkteB : punkteA;
                    Curve basisPoly = avgYA <= avgYB ? polyA : polyB;
                    Curve entferntPoly = avgYA <= avgYB ? polyB : polyA;

                    var currentSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    // Texte schreiben: Basis-Linie (Ungerade)
                    int zaehlerBasis = 1;
                    foreach (var weltPos in basisPunkte)
                    {
                        double rotWinkel = BerechneKurvenWinkel(basisPoly, weltPos, bksMatrix);
                        ErstelleEchtenText(currentSpace, tr, db, weltPos, zaehlerBasis.ToString(), finaleHoehe, rotWinkel, blockLayerId);
                        zaehlerBasis += 2;
                    }

                    // Texte schreiben: Entfernte Linie (Gerade)
                    int zaehlerEntfernt = 2;
                    foreach (var weltPos in entferntePunkte)
                    {
                        double rotWinkel = BerechneKurvenWinkel(entferntPoly, weltPos, bksMatrix);
                        ErstelleEchtenText(currentSpace, tr, db, weltPos, zaehlerEntfernt.ToString(), finaleHoehe, rotWinkel, blockLayerId);
                        zaehlerEntfernt += 2;
                    }

                    polyA.Dispose();
                    polyB.Dispose();

                    tr.Commit();
                }

                // Bildschirm regenerieren, um die neuen blauen Texte sofort sichtbar zu machen
                ed.Regen();
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nFehler im Befehl AEC1021: {ex.Message}");
            }
        }
    
    



    // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
    // frmAEC1001_01                                                       #1021 AEC1021 Teil 2
    // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q


 
       
            private double BerechneKurvenWinkel(Curve kurve, Point3d weltPunkt, Matrix3d bksMatrix)
        {
            try
            {
                Point3d ptAufKurve = kurve.GetClosestPointTo(weltPunkt, false);
                Vector3d tangente = kurve.GetFirstDerivative(ptAufKurve);
                return bksMatrix.CoordinateSystem3d.Xaxis.GetAngleTo(tangente, bksMatrix.CoordinateSystem3d.Zaxis);
            }
            catch
            {
                return 0.0;
            }
        }

        private void ErstelleEchtenText(BlockTableRecord btr, Transaction tr, Database db, Point3d position, string inhalt, double hoehe, double winkel, ObjectId layerId)
        {
            var text = new DBText
            {
                Position = position,
                TextString = inhalt,
                Height = hoehe,
                Rotation = winkel,
                LayerId = layerId,
                Justify = AttachmentPoint.MiddleCenter,
                AlignmentPoint = position
            };
            text.SetDatabaseDefaults(db);

            // Reines AutoCAD-Blau erzwingen
            text.ColorIndex = 5;

            btr.AppendEntity(text);
            tr.AddNewlyCreatedDBObject(text, true);
        }
    }
}


        public class AutoCADWindowWrapper : System.Windows.Forms.IWin32Window
        {
            public IntPtr Handle { get; }
            public AutoCADWindowWrapper(IntPtr handle) => Handle = handle;
        }
    
































        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #1022 AEC1022
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




// 20260827-1600 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q













































































































