using Algenta.Colectica.Navigator.NodeTypes;
using Algenta.Colectica.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Colectica.SampleAddins.ItemPicker
{

    /// <summary>
    /// A ItemPickerResultsFilter Addin allows you to hide hwich
    /// results are displayed in the item picker.
    /// </summary>
    [Export(typeof(IItemPickerResultsFilter))]
       
    public class SampleItemPickerResultsFilter : IItemPickerResultsFilter
    {
        /// <summary>
        /// Gets a value indicating whether the given result should be included in the results display.
        /// Each valid search result is passed into this method.
        /// </summary>
        /// <param name="node">The node representing the search result.</param>
        /// <returns>Return <c>true</c> to keep the search result; return <c>false</c> to 
        /// hide the search result.</returns>
        public bool ShouldItemBeListed(RepositoryItemNode node)
        {
            // Don't show any search results tha start with the letter "B".
            if (node.Header.StartsWith("B"))
            {
                return false;
            }

            return true;
        }
    }
}
