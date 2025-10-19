using CivilEngineeringManager.Forms;
using System;
using System.Windows.Forms;

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
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new AddEditProjectSpecifications());
            //Application.Run(new FormTreeWithDTOs());
            //Application.Run(new Form1());
            //Application.Run(new AddSpecifications());
            //Application.Run(new TestProject());
        }
    }
}
