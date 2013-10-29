using Algenta.Colectica.AppModel;
using Algenta.Colectica.Navigator.NodeTypes;
using Algenta.Colectica.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;

namespace Colectica.SampleAddins.Commands
{
    /// <summary>
    /// A NodeCommand executes on a navigator node *other* than a 
    /// versionable item (e.g., a RepositoryNode).
    /// </summary>
    [Export(typeof(INodeCommand))]
    public class SampleNodeCommand : INodeCommand
    {
        /// <summary>
        /// CanEverExecute determines whether a button or menu item for the 
        /// command is displayed.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool CanEverExecute(Node node)
        {
            // In this case, show the command for remote repositories.
            if (node.ItemType == GuiItemType.NetworkRepository)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// CanExecute determines whether the button or menu item is enabled.
        /// It is only relevent if CanEverExecute() returns true.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool CanExecute(Node node)
        {
            return true;
        }

        /// <summary>
        /// The Execute() method is executed when the user click the button
        /// or context menu item.
        /// </summary>
        /// <param name="node"></param>
        public void Execute(Node node)
        {
            MessageBox.Show("Sample command for " + node.Header);
        }

        public string Category
        {
            get { return "Samples"; }
        }

        public string Image
        {
            get { return string.Empty; }
        }

        public string Name
        {
            get { return "Sample Node Command"; }
        }

        public string SubCategory
        {
            get { return "Sample"; }
        }

        public int Weight
        {
            get { return 1000; }
        }
    }
}
