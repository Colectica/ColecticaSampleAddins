using Algenta.Colectica.Model;
using Algenta.Colectica.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Colectica.SampleAddins.Views
{
    /// <summary>
    /// A docking view Addin should be derived from the WPF UserControl class,
    /// and implement the IDockingView interface.
    /// </summary>
    [Export(typeof(IDockingView))]
    public partial class SampleDockingView : UserControl, IDockingView
    {
        /// <summary>
        /// Designer will set this property to indicate whether your control
        /// is currently visible to the user. If it is not visible, you may wish
        /// to skip certain operations, since the user would not see the 
        /// results.
        /// </summary>
        public bool IsDisplayed { get; set; }

        public SampleDockingView()
        {
            InitializeComponent();
            
            // Create a ViewModel and assign it to your control's DataContext.
            this.DataContext = new SampleDockingViewModel();
        }

        /// <summary>
        /// The title determines what is displayed in the view's title bar.
        /// </summary>
        public string Title
        {
            get { return "Sample Docking View"; }
        }
    }

    public class SampleDockingViewModel : NotificationObject
    {
        // Add properties and methods to your ViewModel.
        // These can be bound to your control in the XAML.
    }
}
