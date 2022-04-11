using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ElementID
{
    [Transaction(TransactionMode.Manual)]
    public class ElementIDSel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            var sel = uidoc.Selection;
            var ids = uidoc.Selection.GetElementIds();

            if (ids.Count == 0)
            {
                var pickedref = uidoc.Selection.PickObjects(ObjectType.Element, "Vyberte objekty");
                ids = (from Reference r in pickedref select r.ElementId).ToList();
            }

            ID id = new ID();
            id.SetIds(doc, ids);

            return Result.Succeeded;
        }
    }
}
