using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ElementID
{
    [Transaction(TransactionMode.Manual)]
    public class ElementID : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            var pickedref = uidoc.Selection.PickObjects(ObjectType.Element, "Vyberte objekty");
            var ids = (from Reference r in pickedref select r.ElementId).ToList();

            ID id = new ID();
            id.SetIds(doc, ids);

            return Result.Succeeded;
        }
    }
}
