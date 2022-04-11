using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ElementID
{
    [Transaction(TransactionMode.Manual)]
    public class ElemenIDWithDialog : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            TaskDialog mainDialog = new TaskDialog("Element ID");
            mainDialog.MainInstruction = "Element ID";
            mainDialog.MainContent = "Zapíše pro vybrané objekty hodnoty jejich ID";

            mainDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "Všechny objekty v aktuálním pohledu");
            mainDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "Pouze vybrané objekty v aktuálním pohledu");
            mainDialog.CommonButtons = TaskDialogCommonButtons.Close | TaskDialogCommonButtons.Ok;
            mainDialog.DefaultButton = TaskDialogResult.Close;
            TaskDialogResult tResult = mainDialog.Show();

            if (TaskDialogResult.CommandLink1 == tResult)
            {
                var elems = new List<Element>();
                var col = new FilteredElementCollector(doc).WhereElementIsNotElementType();

                foreach (Element e in col)
                {
                    if (null != e.Category && e.Category.HasMaterialQuantities)
                    {
                        elems.Add(e);
                    }
                }

                ID id = new ID();
                id.SetIds(doc, elems);
            }
            else if (TaskDialogResult.CommandLink2 == tResult)
            {
                var ids = uidoc.Selection.GetElementIds();

                if (ids.Count == 0)
                {
                    var pickedref = uidoc.Selection.PickObjects(ObjectType.Element, "Vyberte objekty");
                    ids = (from Reference r in pickedref select r.ElementId).ToList();
                }

                ID id = new ID();
                id.SetIds(doc, ids);
            }

            return Result.Succeeded;
        }
    }
}