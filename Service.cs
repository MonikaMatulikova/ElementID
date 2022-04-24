using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace ElementID
{
    public class Service
    {
        #region PROPERTIES
        static UIDocument uiapp;
        static Document doc;

        static VM_MainWindow vM_MainWindow;
        static MainWindow window;
        static ICollection<ElementId> ids;
        #endregion

        #region PUBLIC METHODS
        public static void Start(UIApplication uiapp)
        {
            InitializeProperties(uiapp);

            window = new MainWindow();
            vM_MainWindow = new VM_MainWindow();
            window.VM_MainWindow = vM_MainWindow;
            window.SetupForm();
            window.ShowDialog();
        }

        public static void InitializeProperties(UIApplication uiapp)
        {
            Service.uiapp = uiapp.ActiveUIDocument;
            doc = uiapp.ActiveUIDocument.Document;
        }

        public static void RunProcess()
        {
            if (vM_MainWindow.AllObjects)
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
            else
            {
                if (ids == null)
                {
                    ids = uiapp.Selection.GetElementIds();
                }
                ID id = new ID();
                id.SetIds(doc, ids);
                ids = null;
            }
        }

        public static void SelectObjects()
        {
            var pickedref = uiapp.Selection.PickObjects(ObjectType.Element, "Vyberte objekty");
            ids = (from Reference r in pickedref select r.ElementId).ToList();
        }
        #endregion
    }
}
