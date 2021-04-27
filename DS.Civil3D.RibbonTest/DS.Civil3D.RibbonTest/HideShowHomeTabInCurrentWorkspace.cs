using Autodesk.AutoCAD.Runtime;
using System.Windows.Forms;
using acApp = Autodesk.AutoCAD.ApplicationServices.Application;

namespace DS.Civil3D.RibbonTest
{
    public class Commands : IExtensionApplication
    {
        // функция инициализации (выполняется при загрузке плагина)
        public void Initialize()
        {
            MessageBox.Show("Hello!");
        }

        // функция, выполняемая при выгрузке плагина
        public void Terminate()
        {
            MessageBox.Show("Goodbye!");
        }

        // эта функция будет вызываться при выполнении в AutoCAD команды «TestCommand»
        [CommandMethod("TestCommand")]
        public void MyCommand()
        {
            MessageBox.Show("Habr!");
        }

        [CommandMethod("HideShowHomeTabInCurrentWorkspace")]

        static public void HideShowHomeTabInCurrentWorkspace()

        {

            string menuName =

              (string)acApp.GetSystemVariable("MENUNAME");



            string curWorkspace =

              (string)acApp.GetSystemVariable("WSCURRENT");



            Autodesk.AutoCAD.Customization.CustomizationSection cs =

              new Autodesk.AutoCAD.Customization.CustomizationSection(

                menuName + ".cuix");



            Autodesk.AutoCAD.Customization.WSRibbonRoot rr =

              cs.getWorkspace(curWorkspace).WorkspaceRibbonRoot;



            Autodesk.AutoCAD.Customization.WSRibbonTabSourceReference tab =

              rr.FindTabReference("ACAD", "ID_TabHome3D");



            if (tab != null)

                tab.Show = !tab.Show;



            if (cs.IsModified)

            {

                cs.Save();



                // Reload to see the changes

                acApp.ReloadAllMenus();

            }

        }
    }
}
