using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace ElementID
{
    internal class ID
    {
        internal void SetIds(Document doc, List<Element> elems)
        {
            using (Transaction t = new Transaction(doc, "parameter"))
            {
                t.Start("param");
                try
                {
                    foreach (Element elem in elems)
                    {
                        SetParameterId(elem);
                    }
                }
                catch { }
                t.Commit();
            }
        }

        internal void SetIds(Document doc, ICollection<ElementId> ids)
        {
            using (Transaction t = new Transaction(doc, "parameter"))
            {
                t.Start("param");
                try
                {
                    foreach (ElementId id in ids)
                    {
                        var elem = doc.GetElement(id);
                        SetParameterId(elem);
                    }
                }
                catch { }
                t.Commit();
            }
        }

        internal void SetId(Document doc, Element elem)
        {
            SetIds(doc, new List<Element> { elem });
        }

        internal void SetParameterId(Element elem)
        {
            var elemId = elem.Id.IntegerValue;
            var paramId = elem.LookupParameter("ID");
            paramId.Set(elemId.ToString());
        }
    }
}
