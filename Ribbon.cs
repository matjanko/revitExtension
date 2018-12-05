using System;
using Autodesk.Revit.UI;

namespace matjanko.RevitExtension
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Automatic)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class Ribbon : IExternalApplication
    {
        private static readonly string assemblyPath = typeof(Ribbon).Assembly.Location;
              
        public Result OnStartup (UIControlledApplication app)
        {
            try
            {
                CreateRibbon(app);
                return Result.Succeeded;
            }
            catch (Exception)
            {                
                return Result.Failed;
            }
        }
       
        public Result OnShutdown (UIControlledApplication app)
        {
            return Result.Succeeded;
        }
        
        private void CreateRibbon (UIControlledApplication application)
        {
            string tabName = "matjanko";
            application.CreateRibbonTab(tabName);

            string panelName = "matjanko Revit Extension";
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, panelName);

            PushButton button1 = ribbonPanel.AddItem(new PushButtonData("button1", "Wyeksportuj projekt", assemblyPath, "matjankoRevitExtension.ExcludedProjectToNewFile")) as PushButton;          
        }
    }
}
