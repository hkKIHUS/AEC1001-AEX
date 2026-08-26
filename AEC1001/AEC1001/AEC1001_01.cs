
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


        private class SolidAlignJig : DrawJig
        {
            private Entity? _preview;
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

            protected override bool WorldDraw(Autodesk.AutoCAD.GraphicsInterface.WorldDraw d)
            {
                if (_preview == null || d?.Geometry == null) return true;
                d.Geometry.PushModelTransform(GetCurrentMatrix());
                d.Geometry.Draw(_preview);
                d.Geometry.PopModelTransform();
                return true;
            }

            protected override SamplerStatus Sampler(JigPrompts prompts)
            {
                if (prompts == null) return SamplerStatus.Cancel;

                var opts = new JigPromptPointOptions($"\nZielpunkt für {(CurrentStep == 2 ? "X-Achse" : "Y-Achse")} angeben: ")
                {
                    UserInputControls = UserInputControls.Accept3dCoordinates,
                    UseBasePoint = true,
                    BasePoint = _tOrg
                };

                var res = prompts.AcquirePoint(opts);
                if (res.Status != PromptStatus.OK) return SamplerStatus.Cancel;

                if (CurrentStep == 2) _tXPt = res.Value; else _tYPt = res.Value;
                return SamplerStatus.OK;
            }
        }

        [CommandMethod("AEC1014")]
        public void AEC1014()
        {
            Document? doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            Editor ed = doc.Editor;
            // KORREKTUR: SystemToUse entfernt - Objekttyp wird direkt im String definiert
            var entOpts = new PromptEntityOptions("\nVolumenkörper für Ausrichtung anklicken: ");
            entOpts.SetRejectMessage("\nDas gewählte Objekt ist kein gültiger 3D-Volumenkörper!");
            entOpts.AddAllowedClass(typeof(Solid3d), false);

            var entRes = ed.GetEntity(entOpts);
            if (entRes.Status != PromptStatus.OK) return;

            try
            {
                using var tr = doc.Database.TransactionManager.StartTransaction();
                if (tr.GetObject(entRes.ObjectId, AcOpenMode.ForRead) is not Solid3d solid) return;

                // Quellpunkte einlesen
                var p1 = ed.GetPoint("\nErsten Quellpunkt angeben (Basis): "); if (p1.Status != PromptStatus.OK) return;
                var p2 = ed.GetPoint("\nZweiten Quellpunkt angeben (X-Achse): "); if (p2.Status != PromptStatus.OK) return;
                var p3 = ed.GetPoint("\nDritten Quellpunkt angeben (Y-Achse): "); if (p3.Status != PromptStatus.OK) return;

                // Quell-Koordinatensystem kompakt aufbauen
                var sX = p1.Value.GetVectorTo(p2.Value).GetNormal();
                var sZ = sX.CrossProduct(p1.Value.GetVectorTo(p3.Value)).GetNormal();
                var srcCS = new CoordinateSystem3d(p1.Value, sX, sZ.CrossProduct(sX).GetNormal());

                int loopCount = 0;
                while (true)
                {
                    var tgtRes = ed.GetPoint("\nNächsten Ziel-Basispunkt angeben (oder ESC): ");
                    if (tgtRes.Status != PromptStatus.OK) break;

                    var jig = new SolidAlignJig(solid, p1.Value, srcCS, tgtRes.Value);

                    jig.CurrentStep = 2; if (ed.Drag(jig).Status != PromptStatus.OK) { jig.CleanUp(); break; }
                    jig.CurrentStep = 3; if (ed.Drag(jig).Status != PromptStatus.OK) { jig.CleanUp(); break; }

                    var cloned = (Solid3d)solid.Clone();
                    cloned.TransformBy(jig.GetCurrentMatrix());
                    jig.CleanUp();

                    var currentSpace = (BlockTableRecord)tr.GetObject(doc.Database.CurrentSpaceId, AcOpenMode.ForWrite);
                    currentSpace.AppendEntity(cloned);
                    tr.AddNewlyCreatedDBObject(cloned, true);

                    ed.WriteMessage($"\nKopie {++loopCount} platziert.");
                }
                tr.Commit();
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nFehler: {ex.Message}");
            }
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #0020 AEC1020_20260826_1307
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // 20260825-1100 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q


        [CommandMethod("AEC1020_20260826_1307")]
        public void AEC1020_20260826_1307()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null) return;

            var ed = doc.Editor;

            try
            {
                string targetLayerName = "";
                using (var tr = doc.Database.TransactionManager.StartTransaction())
                {
                    if (tr.GetObject(doc.Database.Clayer, AcOpenMode.ForRead) is not LayerTableRecord lyRec) return;
                    if (lyRec.IsLocked)
                    {
                        ed.WriteMessage($"\nAEC1020: Fehler - Der aktuelle Layer '{lyRec.Name}' ist gesperrt. Aktion abgebrochen.");
                        return;
                    }
                    targetLayerName = lyRec.Name;
                }

                // 2. Auswahlfilter: Nur TEXT/MTEXT auf dem aktuellen Layer
                var filter = new SelectionFilter(new[]
                {
                    new TypedValue((int)DxfCode.Operator, "<AND"),
                    new TypedValue((int)DxfCode.LayerName, EscapeAutoCADWildcards(targetLayerName)),
                    new TypedValue((int)DxfCode.Operator, "<OR"),
                    new TypedValue((int)DxfCode.Start, "TEXT"),
                    new TypedValue((int)DxfCode.Start, "MTEXT"),
                    new TypedValue((int)DxfCode.Operator, "OR>"),
                    new TypedValue((int)DxfCode.Operator, "AND>")
                });

                var selResult = ed.SelectAll(filter);
                if (selResult.Status != PromptStatus.OK || selResult.Value == null)
                {
                    ed.WriteMessage($"\nAEC1020: Keine Texte auf dem aktuellen Layer '{targetLayerName}' gefunden.");
                    return;
                }

                var textIds = selResult.Value.GetObjectIds();
                if (textIds == null || textIds.Length == 0) return;

                // 3. Sichtbarkeit umschalten
                using (var tr = doc.Database.TransactionManager.StartTransaction())
                {
                    if (tr.GetObject(textIds[0], AcOpenMode.ForRead) is not Entity ersterText) return;
                    bool neuerZustand = !ersterText.Visible;
                    int zaehler = 0;

                    foreach (var id in textIds)
                    {
                        if (id.IsErased) continue;
                        if (tr.GetObject(id, AcOpenMode.ForRead) is Entity ent && ent.Visible != neuerZustand)
                        {
                            ent.UpgradeOpen();
                            ent.Visible = neuerZustand;
                            zaehler++;
                        }
                    }

                    tr.Commit();
                    ed.Regen();
                    ed.WriteMessage($"\nAEC1020: {zaehler} Texte auf Layer '{targetLayerName}' wurden {(neuerZustand ? "sichtbar" : "unsichtbar")} geschaltet.");
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nAEC1020: Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
            }
        }

        private string EscapeAutoCADWildcards(string input)
        {
            if (string.IsNullOrEmpty(input)) return input; git
            const string wildcards = "#@.*?[,`~";
            var sb = new System.Text.StringBuilder(input.Length * 2);
            foreach (char c in input)
            {
                if (wildcards.Contains(c)) sb.Append('`');
                sb.Append(c);
            }
            return sb.ToString();
        }




        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q
        // frmAEC1001_01                                                       #0020 AEC1020
        // ====•===1====•====2====•====3====•====4====•====5====•====6====•====7====•====H====•====9====•====0====•====1====•====Q




        // 20260825-1100 #~~~2~~~~•~~~~3~~~~•~~~~4~~~~•~~~~5~~~~•~~~~6~~~~•~~~~7~~~~•~~~~H~~~~•~~~~9~~~~•~~~~0~~~~•~~~~1~~~~•~~~~Q







        public class AEC1020Routine
        {
            [CommandMethod("AEC1020")]
            public void AEC1020()
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Database db = doc.Database;
                Editor ed = doc.Editor;

                // 1. Benutzer fragen: Ein oder Aus
                PromptKeywordOptions pko = new PromptKeywordOptions("\n[AEC1020] Text-Sichtbarkeit wählen [Ein/Aus]: ");
                pko.Keywords.Add("Ein");
                pko.Keywords.Add("Aus");

                PromptResult prResult = ed.GetKeywords(pko);
                if (prResult.Status != PromptStatus.OK) return;

                bool setVisible = (prResult.StringResult == "Ein");

                // 2. Blockreferenz auswählen lassen
                PromptEntityOptions peo = new PromptEntityOptions("\nWählen Sie eine Blockreferenz aus: ");
                peo.SetRejectMessage("\nDas gewählte Objekt ist kein Block.");
                peo.AddAllowedClass(typeof(BlockReference), true);

                PromptEntityResult per = ed.GetEntity(peo);
                if (per.Status != PromptStatus.OK) return;

                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        // Blockreferenz öffnen
                        BlockReference? blockRef = trans.GetObject(per.ObjectId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockReference;
                        if (blockRef == null) return;

                        // Blockdefinition öffnen
                        BlockTableRecord? blockDef = trans.GetObject(blockRef.BlockTableRecord, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockTableRecord;
                        if (blockDef == null) return;

                        // Modellbereich öffnen
                        BlockTable? bt = trans.GetObject(db.BlockTableId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockTable;
                        BlockTableRecord? modelSpace = trans.GetObject(bt[BlockTableRecord.ModelSpace], Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockTableRecord;

                        int trefferZaehler = 0;

                        // 3. Schleife durch alle Objekte im Block (Hier wird entId genutzt)
                        foreach (ObjectId entId in blockDef)
                        {
                            DBObject obj = trans.GetObject(entId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead);

                            if (obj is DBPoint bPoint)
                            {
                                // Position in Weltkoordinaten umrechnen
                                Point3d pointInBlock = bPoint.Position;
                                Point3d wcsPointPosition = pointInBlock.TransformBy(blockRef.BlockTransform);

                                // 4. Im Modellbereich nach dem zugehörigen Text suchen
                                foreach (Autodesk.AutoCAD.DatabaseServices.ObjectId msId in modelSpace!)
                                {
                                    DBObject msObj = trans.GetObject(msId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead);

                                    if (msObj is DBText dbText)
                                    {
                                        // Abstandsprüfung mit 0.1 Einheiten Toleranz
                                        if (wcsPointPosition.DistanceTo(dbText.Position) < 0.1)
                                        {
                                            dbText.UpgradeOpen();
                                            dbText.Visible = setVisible;
                                            trefferZaehler++;
                                        }
                                    }
                                    else if (msObj is MText mText)
                                    {
                                        if (wcsPointPosition.DistanceTo(mText.Location) < 0.1)
                                        {
                                            mText.UpgradeOpen();
                                            mText.Visible = setVisible;
                                            trefferZaehler++;
                                        }
                                    }
                                }
                            }
                        }

                        trans.Commit();
                        ed.WriteMessage($"\n[AEC1020] Fertig! Sichtbarkeit von {trefferZaehler} Texten wurde auf '{setVisible}' gesetzt.\n");
                    }
                    catch (System.Exception ex)
                    {
                        ed.WriteMessage("\n[Fehler] Problem in Routine AEC1020: " + ex.Message);
                        trans.Abort();
                    }
                }
            }
        }
    }
}
    













































































