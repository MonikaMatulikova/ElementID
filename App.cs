using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace ElementID
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            string tabname = "Arkance Systems test";
            string panelname = "Test";

            a.CreateRibbonTab(tabname);
            var IDPanelNewTab = a.CreateRibbonPanel(tabname, panelname);
            var IDPanel = a.CreateRibbonPanel(panelname);

            IDPanel.AddItem(PushButtonData("2 Element ID", "Zapsat ID \n jeden objekt", "ElementID.OneElementID"));
            IDPanelNewTab.AddItem(PushButtonData("3 Element ID", "Zapsat ID \n jeden objekt", "ElementID.OneElementID"));
            IDPanelNewTab.AddItem(PushButtonData("4a Element ID", "Zapsat ID \n všechny objekty", "ElementID.AllElementsID"));
            IDPanelNewTab.AddItem(PushButtonData("4b Element ID", "Zapsat ID \n pouze vybrané", "ElementID.ElementID"));
            IDPanelNewTab.AddItem(PushButtonData("5 Element ID", "Zapsat ID \n vybrané/vybrat", "ElementID.ElementIDSel"));
            IDPanelNewTab.AddItem(PushButtonData("6 Element ID", "Zapsat ID \n dialog", "ElementID.ElemenIDDialog"));

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
        public PushButtonData PushButtonData(string name, string text, string elementId)
        {
            BitmapImage buttonImage = new BitmapImage(new Uri("pack://application:,,,/ElementID;component/Resources/CS_commandico.png"));

            var button = new PushButtonData(name, text, Assembly.GetExecutingAssembly().Location, elementId);
            button.ToolTip = "Tooltip";
            button.LongDescription = "Long desctiption";
            button.LargeImage = buttonImage;

            return button;
        }
    }
}
