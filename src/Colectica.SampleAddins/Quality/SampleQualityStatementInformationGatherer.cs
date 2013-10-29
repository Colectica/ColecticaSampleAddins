using Algenta.Colectica.Model.Ddi;
using Algenta.Colectica.Model.Ddi.Utility;
using Algenta.Colectica.Navigator.NodeTypes;
using Algenta.Colectica.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Colectica.SampleAddins.Quality
{
    /// <summary>
    /// Gathers information for an item in a QualityStatement.
    /// </summary>
    /// <remarks>
    /// QualityStatement items that have a gatherer capable of collecting
    /// information will show a button when viewed in Designer. When this
    /// button is pressed, the GatherInformationForItem() method will be 
    /// executed.
    /// </remarks>
    [Export(typeof(IQualityStatementInformationGatherer))]
    public class SampleQualityStatementInformationGatherer : 
        QualityStatementInformationGathererBase
    {
        public SampleQualityStatementInformationGatherer()
        {
            // The name appears in the button that is created for the 
            // QualityStatement item.
            this.Name = "Sample Information Gatherer";

            // Indicates whether the gatherer prompts the user for information.
            // This is not currently used by Colectica Designer, but it may be
            // useful for your own purposes.
            this.IsInteractive = false;
        }

        /// <summary>
        /// Returns a value indicating whether this information gatherer can
        /// collect information for the given item.
        /// </summary>
        /// <param name="node">A node with information about the quality 
        /// statement item</param>
        /// <returns></returns>
        public override bool CanGatherInformationForItem(
            QualityStatementNode node)
        {
            // You can use a UserID, the Label, or any other piece of 
            // information to determien whether you want to collect 
            // information for this item.
            // In this case, we are collecting for the Statistical Population
            // item from the ESMS standard.
            if (node.Item.ComplianceConcept.GetUserIdValue("ESMS-NAME") == 
                "STAT_POP")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gathers information and applies it to the given quality statement
        /// item.
        /// </summary>
        /// <param name="node">A node with information about the quality
        /// statement item. Child nodes can also be retrieved from this.</param>
        /// <param name="contextNode"></param>
        /// <param name="qualityStatement"></param>
        public override void GatherInformationForItem(
            QualityStatementNode node, 
            Node contextNode, 
            QualityStatement qualityStatement)
        {
            string infoFromMyDataSource = "Sample Information";

            node.Item.ComplianceDescription.Current = infoFromMyDataSource;
            
            // If your users should not edit the collected information, you can
            // indicate that information for this item has been gathered.
            // In this case, the item will be displayed as read-only in 
            // Designer.
            qualityStatement.GatheredQualityConceptIds.Add(
                node.Item.ComplianceConcept.CompositeId);
        }

        public override bool IsInformationStillValid(QualityStatementItem item)
        {
            // This method is not currently used by Colectica Designer, but it
            // may be useful for your own purposes.
            throw new NotImplementedException();
        }
    }
}
