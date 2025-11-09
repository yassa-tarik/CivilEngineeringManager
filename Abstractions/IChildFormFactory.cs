using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivilEngineeringManager.Abstractions
{
    public interface IChildFormFactory
    {
        T CreateForm<T>() where T : Form;
        //T CreateForm<T>(UI.Enums.FormMode read) where T : Form;
        T CreateForm<T>(params object[] parameters) where T : Form;
    }
}
