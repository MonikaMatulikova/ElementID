using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ElementID
{
    [Transaction(TransactionMode.Manual)]
    public class OneElementID : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            var sel = uiapp.ActiveUIDocument.Selection;
            var elem = doc.GetElement(sel.PickObject(ObjectType.Element, "Vyberte objekt"));

            ID id = new ID();
            id.SetId(doc, elem);

            return Result.Succeeded;
        }
    }
}
