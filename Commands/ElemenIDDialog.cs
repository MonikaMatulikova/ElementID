using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ElementID
{
    [Transaction(TransactionMode.Manual)]
    public class ElemenIDDialog : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Service.Start(commandData.Application);

            return Result.Succeeded;
        }
    }
}
        