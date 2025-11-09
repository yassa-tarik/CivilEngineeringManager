using CivilEngineeringManager.Abstractions;
using CivilEngineeringManager.UI.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivilEngineeringManager.Implementations
{
    internal class ChildFormFactory: IChildFormFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ChildFormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CreateForm<T>() where T : Form
        {
            return _serviceProvider.GetRequiredService<T>();
        }
        // Overload for contextual parameters
        public T CreateForm<T>(params object[] parameters) where T : Form
        {
            return (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), parameters);
        }

        //public T CreateForm<T>(FormMode read) where T : Form
        //{
        //    return _serviceProvider.GetRequiredService<T>();
        //}
    }
}
