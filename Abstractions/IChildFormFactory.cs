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
