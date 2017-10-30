using Algenta.Colectica.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Colectica.SampleAddins.Options
{
    /// <summary>
    /// Interaction logic for SampleOptionsEditor.xaml
    /// </summary>
    [Export(typeof(IAddinOptionsEditor))]
    public partial class SampleOptionsEditor : UserControl, IAddinOptionsEditor
    {
        public SampleOptionsEditor()
        {
            InitializeComponent();
        }

        public string Title { get => "Sample Addin Options"; }

        public object LoadOptions()
        {
            return OptionsManager.LoadOptions<SampleOptions>("SampleOptions");
        }

        public void StoreOptions(object obj)
        {
            OptionsManager.StoreOptions("SampleOptions", obj);
        }
    }



    public class SampleOptions
    {
        public string One { get; set; } = "Hello, one";
        public int Two { get; set; } = 1;
        public int Three { get; set; } = 2;
    }

}
