﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace DS.RVT.ExtCmd.FW4._8.MVVM1
{
    [Transaction(TransactionMode.Manual)]
    public class ExternalCommand : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
           ref string message, ElementSet elements)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();

            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}