using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ElementID
{
    [Transaction(TransactionMode.Manual)]
    public class AllElementsID : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

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

            return Result.Succeeded;
        }
    }
}
