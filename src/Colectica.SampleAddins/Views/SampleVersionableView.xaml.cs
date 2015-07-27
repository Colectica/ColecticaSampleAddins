using Algenta.Colectica.Model;
using Algenta.Colectica.Model.Ddi;
using Algenta.Colectica.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SampleVersionableView.xaml
    /// </summary>
    [Export(typeof(IVersionableView))]
    public partial class SampleVersionableView : UserControl, IVersionableView
    {
        public SampleVersionableView()
        {
            InitializeComponent();
        }

        public Collection<Guid> ApplicableItemTypes
        {
            get
            {
                return new Collection<Guid>(new[]
                {
                    DdiItemType.StudyUnit
                });
            }
        }

        public void Initialize(IVersionable item)
        {
            var study = item as StudyUnit;
            this.DataContext = new SampleVersionableViewModel(study);
        }

        public void OnActivated()
        {
            
        }

        public string Title
        {
            get { return "My Sample View"; }
        }

        public int Weight
        {
            get { return 10; }
        }


        public void Initialize(Algenta.Colectica.Navigator.NodeTypes.Node node, IVersionable item)
        {
            throw new NotImplementedException();
        }

        public bool IsInCustomFieldsTab
        {
            get { return false; }
        }
    }

    public class SampleVersionableViewModel : NotificationObject
    {
        public StudyUnit Study { get; set; }

        public SampleVersionableViewModel(StudyUnit study)
        {
            this.Study = study;
        }
    }
}
