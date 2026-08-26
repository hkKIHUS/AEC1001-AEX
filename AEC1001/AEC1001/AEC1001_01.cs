
// ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
// frmAEC1001                                                          #0000 Inhaltsverzeichnis
// ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




// 20260825-1000 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q

// frmAEC1001                                                          #0001 Load
// frmAEC1001                                                          #0002 AEC0001
// frmAEC1001                                                          #0003 SUB0002
// frmAEC1001                                                          #0004 SUB0004
// frmAEC1001                                                          #0005 Assemblys Interop
// frmAEC1001                                                          #0006 SUB0005
// frmAEC1001                                                          #0007 SUB0006
// frmAEC1001                                                          #0008 SUB0007
// frmAEC1001                                                          #0009 SUB0008
// frmAEC1001                                                          #0010 SUB0009
// frmAEC1001                                                          #0011 SUB0010
// frmAEC1001                                                          #0012 SUB0011
// frmAEC1001                                                          #0013 SUB0012
// frmAEC1001                                                          #0014 AEC0014
// frmAEC1001                                                          #0015 AEC0015
// frmAEC1001                                                          #0016 AEC0016
// frmAEC1001                                                          #0017 Leer
// frmAEC1001                                                          #0018 Leer
// frmAEC1001                                                          #0019 Leer
// frmAEC1001                                                          #0020 AEC0020
// frmAEC1001                                                          #0021 AEC0021
// frmAEC1001                                                          #0022 AEC0022
// frmAEC1001                                                          #0023 AEC0023
// frmAEC1001                                                          #0024 Leer
// frmAEC1001                                                          #0025 PointContainer2D
// frmAEC1001                                                          #0026 Module AecHelper
// frmAEC1001                                                          #0027 PointContainer




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
        // frmAEC1001                                                          #1001 Load
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
        // frmAEC1001_01                                                       #0001 AEC1001
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




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
        // frmAEC1001_01                                                       #0002 AEC1002
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q

        [CommandMethod("AEC1002")]
        public void AEC1002()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            string layerName = "000#90001#0001-00000#0000-01 LayerLeer";
            ObjectId layerId = ObjectId.Null;

            try
            {
                using (var trans = doc.Database.TransactionManager.StartTransaction())
                {
                    if (trans.GetObject(doc.Database.LayerTableId, AcOpenMode.ForRead) is not LayerTable lt) return;

                    if (lt.Has(layerName))
                    {
                        if (trans.GetObject(lt[layerName], AcOpenMode.ForWrite) is not LayerTableRecord ltr) return;

                        // NEU: Vorab-Prüfung, ob der Layer bereits der aktuelle Layer ist
                        if (doc.Database.Clayer == ltr.ObjectId)
                        {
                            doc.Editor.WriteMessage($"\nHinweis: Der Layer '{layerName}' ist bereits der aktuelle Layer.");
                            return; // Beendet die Routine sauber ohne Fehler
                        }

                        // Eigenschaften ändern
                        ltr.IsFrozen = false;
                        ltr.IsLocked = false;
                        ltr.IsOff = false;

                        layerId = ltr.ObjectId;
                        trans.Commit();
                    }
                    else
                    {
                        doc.Editor.WriteMessage($"\nLayer '{layerName}' nicht gefunden.");
                        return;
                    }
                }

                // Layer-Wechsel nach dem Commit ausführen
                if (layerId != ObjectId.Null)
                {
                    doc.Database.Clayer = layerId;
                    doc.Editor.Regen();
                    doc.Editor.WriteMessage($"\nKommando AEC1002 ausgeführt: Layer '{layerName}' ist nun AKTUELL.");
                }
            }
            catch (System.Exception ex)
            {
                doc.Editor.WriteMessage($"\nFehler in AEC1002: {ex.Message}");
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #0003 AEC1003
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q

        [CommandMethod("AEC1003")]
        public void AEC1003()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            // KORREKTUR: Layer auf "0" fixiert
            string layerName = "0";
            ObjectId layerId = ObjectId.Null;

            try
            {
                using (var trans = doc.Database.TransactionManager.StartTransaction())
                {
                    if (trans.GetObject(doc.Database.LayerTableId, AcOpenMode.ForRead) is not LayerTable lt) return;

                    if (lt.Has(layerName))
                    {
                        if (trans.GetObject(lt[layerName], AcOpenMode.ForWrite) is not LayerTableRecord ltr) return;

                        // Vorab-Prüfung, ob der Layer "0" bereits der aktuelle Layer ist
                        if (doc.Database.Clayer == ltr.ObjectId)
                        {
                            doc.Editor.WriteMessage($"\nHinweis: Der Layer '{layerName}' ist bereits der aktuelle Layer.");
                            return;
                        }

                        // Eigenschaften aufheben
                        ltr.IsFrozen = false;
                        ltr.IsLocked = false;
                        ltr.IsOff = false;

                        layerId = ltr.ObjectId;
                        trans.Commit();
                    }
                    else
                    {
                        doc.Editor.WriteMessage($"\nLayer '{layerName}' nicht gefunden.");
                        return;
                    }
                }

                // Layer-Wechsel nach dem Commit ausführen
                if (layerId != ObjectId.Null)
                {
                    doc.Database.Clayer = layerId;
                    doc.Editor.Regen();
                    doc.Editor.WriteMessage($"\nKommando AEC1003 ausgeführt: Layer '{layerName}' ist nun AKTUELL.");
                }
            }
            catch (System.Exception ex)
            {
                doc.Editor.WriteMessage($"\nFehler in AEC1003: {ex.Message}");
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #0012 AEC1012
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // 20260825-1100 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q



        [CommandMethod("AEC1012")]
        public void AEC1012()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            var ed = doc.Editor;

            try
            {
                // KORREKTUR: SystemToUse entfernt - Objekttyp wird direkt im String definiert
                var entOpts = new PromptEntityOptions("\nWählen Sie den auszurichtenden Text (TEXT/MTEXT) aus: ");
                entOpts.SetRejectMessage("Das gewählte Objekt muss ein TEXT oder MTEXT sein.");
                entOpts.AddAllowedClass(typeof(DBText), false);
                entOpts.AddAllowedClass(typeof(MText), false);

                var entRes = ed.GetEntity(entOpts);
                if (entRes.Status != PromptStatus.OK) return;

                var p1 = ed.GetPoint("\nErsten Zielpunkt angeben (Einfügepunkt): "); if (p1.Status != PromptStatus.OK) return;

                var pOpt2 = new PromptPointOptions("\nZweiten Zielpunkt angeben (X-Achse): ") { UseBasePoint = true, BasePoint = p1.Value };
                var p2 = ed.GetPoint(pOpt2); if (p2.Status != PromptStatus.OK) return;

                var pOpt3 = new PromptPointOptions("\nDritten Zielpunkt angeben (3D-Ebene): ") { UseBasePoint = true, BasePoint = p1.Value };
                var p3 = ed.GetPoint(pOpt3); if (p3.Status != PromptStatus.OK) return;

                using var tr = doc.Database.TransactionManager.StartTransaction();
                if (tr.GetObject(entRes.ObjectId, AcOpenMode.ForWrite) is not Entity ent) return;

                Point3d sOrg; Vector3d sNormal, sX;

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

                var srcCS = new CoordinateSystem3d(sOrg, sX, sNormal.CrossProduct(sX).GetNormal());

                var tX = p1.Value.GetVectorTo(p2.Value);
                var v13 = p1.Value.GetVectorTo(p3.Value);
                var tZRaw = tX.CrossProduct(v13);

                if (tX.IsZeroLength() || v13.IsZeroLength() || tZRaw.IsZeroLength())
                {
                    ed.WriteMessage("\nFehler: Ungültige Geometrie (Punkte identisch oder auf einer Linie).");
                    return;
                }

                var tXNorm = tX.GetNormal();
                var tZNorm = tZRaw.GetNormal();
                var tgtCS = new CoordinateSystem3d(p1.Value, tXNorm, tZNorm.CrossProduct(tXNorm).GetNormal());

                ent.TransformBy(Matrix3d.AlignCoordinateSystem(srcCS.Origin, srcCS.Xaxis, srcCS.Yaxis, srcCS.Zaxis, tgtCS.Origin, tgtCS.Xaxis, tgtCS.Yaxis, tgtCS.Zaxis));
                tr.Commit();
                ed.WriteMessage("\nText erfolgreich per 3D-Matrix ausgerichtet.");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nFehler im Befehl AEC1012: {ex.Message}");
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #0014 AEC1014
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
            // frmAEC1001_01                                                       #0020 AEC1020
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

    }
}













































