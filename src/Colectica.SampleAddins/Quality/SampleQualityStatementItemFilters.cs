using Algenta.Colectica.Model.Ddi;
using Algenta.Colectica.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Colectica.SampleAddins.Quality
{
    /// <summary>
    /// A QualityStatementItemFilter Addin allows you to hide which 
    /// items of a quality statement are displayed. When filters exist,
    /// a row of buttons is displayed at the top of the QualityStatement,
    /// and the user can choose which filter to apply.
    /// </summary>
    [Export(typeof(IQualityStatementItemFilter))]
    public class ShowAllQualityStatementItems : QualityStatementItemFilterBase
    {
        public ShowAllQualityStatementItems()
            : base("Show all items", 0)
        {

        }

        public override QualityStatementItemState GetItemState(QualityStatementItem item)
        {
            // Show all items.
            return new QualityStatementItemState() { Visibility = QualityStatementItemVisibility.Visible };
        }
    }

    [Export(typeof(IQualityStatementItemFilter))]
    public class ShowContactItems : QualityStatementItemFilterBase
    {
        Random random = new Random();

        public ShowContactItems()
            : base("Only show contact items", 10)
        {

        }

        public override QualityStatementItemState GetItemState(QualityStatementItem item)
        {
            var state = new QualityStatementItemState();

            // Only show items that contain the word "contact" in their label.
            string label = item.ComplianceConcept.Label.Current.ToLower();
            if (label.Contains("contact"))
            {
                state.Visibility = QualityStatementItemVisibility.Visible;
            }
            else
            {
                state.Visibility = QualityStatementItemVisibility.Hidden;
            }

            // Chaos sort. It's a different order every time.
            state.Weight = random.Next(1, 10000);

            return state;
        }
    }
}
