using System;
using System.Windows.Forms;
using CivilEngineeringManager.Forms;

namespace CivilEngineeringManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AddEditProjectSpecifications());
            //Application.Run(new FormTreeWithDTOs());
            //Application.Run(new Form1());
            //Application.Run(new AddSpecifications());
            //Application.Run(new TestProject());
        }
    }
}
