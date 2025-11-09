using CivilEngineeringManager.Abstractions;
using CivilEngineeringManager.Forms;
using CivilEngineeringManager.Implementations;
using Composition;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace CivilEngineeringManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            //****************** Using DI ********************************
            // 1. Create the container builder
            var services = new ServiceCollection();
            //IServiceProvider service = services.BuildServiceProvider();
            

            // 2. Register all components using the extension method
            services.RegisterCoreServices();

            // 3. Register the Main Form itself (must be Transient)
            services.AddSingleton<IChildFormFactory, ChildFormFactory>();
            services.AddTransient<frmAddNewCategoryDesignation>();
            services.AddSingleton<frmProjects>();
            services.AddScoped<AddEditProjectSpecifications>();
            services.AddTransient<frmAddEditReadProject>();
            services.AddSingleton<frmMain>();
            

            // 4. Build the provider
            var serviceProvider = services.BuildServiceProvider();

            // 5. Run the application by resolving the Main Form
            // This resolves the MainForm, and the container automatically injects 
            // IProjectService (and all its dependencies) into it.
            Application.Run(serviceProvider.GetRequiredService<frmMain>());
            //Application.Run(serviceProvider.GetRequiredService<AddEditProjectSpecifications>());
            //**************************************************************



            //System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<frmAddNewCategoryDesignation>());
            //System.Windows.Forms.Application.Run(new AddEditProjectSpecifications());
            //Application.Run(new FormTreeWithDTOs());
            //Application.Run(new Form1());
            //Application.Run(new AddSpecifications());
            //Application.Run(new TestProject());
            //Application.Run(new frmMain());
        }
    }
}
