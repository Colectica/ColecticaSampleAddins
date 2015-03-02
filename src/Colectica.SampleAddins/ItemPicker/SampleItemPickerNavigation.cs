using Algenta.Colectica.Model;
using Algenta.Colectica.Model.Ddi;
using Algenta.Colectica.Navigator.NodeTypes;
using Algenta.Colectica.ViewModel;
using Algenta.Colectica.ViewModel.Navigator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Colectica.SampleAddins.ItemPicker
{
    /// <summary>
    /// A IItemPickerNavigation addin allows you to control the left side
    /// of the ItemPicker.
    /// </summary>
    [Export(typeof(IItemPickerNavigation))]
    public class SampleItemPickerNavigation : IItemPickerNavigation
    {
        /// <summary>
        /// Gets text to be displayed in a banner at the top of the ItemPicker.
        /// </summary>
        public string Title
        {
            get { return "Sample Navigator"; }
        }

        /// <summary>
        /// Determines whether this addin will provide navigation information,
        /// based on the given the context.
        /// </summary>
        /// <param name="context">Describes the situation in which the ItemPicker is being 
        /// displayed to the user.</param>
        /// <returns></returns>
        public bool CanHandleItemSelection(ItemPickerContext context)
        {
            // Only use this navigation in TaskMode and when selecting Universe items.
            if (context.IsTaskMode &&
                context.TypeToSelect == DdiItemType.Universe)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the navigation nodes to be displayed on the left side of the ItemPicker.
        /// </summary>
        /// <param name="context">Describes the situation in which the ItemPicker is being 
        /// displayed to the user.</param>
        /// <returns></returns>
        public Collection<Node> GetNavigationNodes(ItemPickerContext context)
        {
            var results =  new Collection<Node>();
            
            // Only include the Checkouts node in the navigation.
            // Alternatively, we could search for certain items to include in the navigation,
            // and only include those.
            var checkoutsNode = new CheckoutsFolderNode(null);
            results.Add(checkoutsNode);

            return results;
        }

        /// <summary>
        /// Gets the search results to be displayed on the right side of the ItemPicker.
        /// </summary>
        /// <param name="context">Describes the situation in which the ItemPicker is being
        /// displayed to the user.</param>
        /// <param name="selectedNode">The node selected on the left side of the ItemPicker.</param>
        /// <param name="searchText">The search text entered by the user.</param>
        /// <returns></returns>
        public Collection<Node> GetSearchResults(ItemPickerContext context, Node selectedNode, string searchText)
        {
            var client = selectedNode.GetClient();
            var navigator = new NavigatorHelper(client);

            var provider = selectedNode as IVersionableProvider;
            Collection<Node> results = null;
            if (provider != null)
            {
                // If an item is selected in the navigator, find items of the target type within that selected item.
                results = navigator.FindItems(provider.Metadata.CompositeId, context.TypeToSelect, selectedNode, false);
            }
            else
            {
                // No item is selected in the navigator, so search the entire repository.
                results = navigator.FindItems(context.TypeToSelect, selectedNode, false);
            }

            return results;
        }

        /// <summary>
        /// Called when an item is selected from the ItemPicker.
        /// </summary>
        /// <param name="referencingItem">The item that should reference the selected item.</param>
        /// <param name="item">The item that was selected from the ItemPicker.</param>
        public void HandleSelectedItem(IVersionable referencingItem, object item)
        {
            // It is not necessary to implement this method unless the selection requires
            // special handling. Otherwise, the reference will be added like normal.
        }

        /// <summary>
        /// Gets the history for the provided node.
        /// </summary>
        /// <param name="node">The node for which to retrieve history.</param>
        /// <returns>A list of nodes representing each version of the item represented by the node.</returns>
        public Collection<Node> GetHistory(Node node)
        {
            // Don't support history.
            return new Collection<Node>();
        }

        /// <summary>
        /// Gets a value indicating whether the ItemPicker's navigator area should be hidden when
        /// this addin is active.
        /// </summary>
        public bool HideNavigator
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the ItemPicker's details area should be hidden when
        /// this addin is active.
        /// </summary>
        public bool HideDetails
        {
            get { return false; }
        }
    }
}
