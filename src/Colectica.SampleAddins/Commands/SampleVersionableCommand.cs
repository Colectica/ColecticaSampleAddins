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
    /// A sample command that adds a ribbon button to the context menu for 
    /// an item in Colectica Designer.
    /// </summary>
    /// <remarks>
    /// The Export attribute tells Colectica that this class contains an Addin
    /// of the type specified as the parameter, in this case an 
    /// IVersionableCommand.
    /// 
    /// The class should also implement the IVersionableCommand interface. 
    /// In this case Colectica SDK provides the VersionableCommandBase class,   
    /// which implements the interface for us. We can derive from that class 
    /// and set its properties, set its properties in the constructor, and 
    /// override the Execute method to implement the desired functionality.
    /// </remarks>
    [Export(typeof(IVersionableCommand))]
    public class SampleVersionableCommand : VersionableCommandBase
    {
        public SampleVersionableCommand()
        {
            // Name determines the text that is displayed on the button or the 
            // context menu.
            this.Name = "My Versionable Item Command";
            
            // Weight determines the order of the item, compared to other 
            // commands.
            this.Weight = 1000;
            
            // Category determines in which group of ribbon items this command 
            // will appear.
            this.Category = "Samples";
            
            // Image determines what picture will be displayed on the button.
            this.Image = "checkout-32.png";

            // IsLongRunning determines whether this command will be run on a 
            // background thread.
            //
            // It should be set to true if your command will perform CPU-
            // intensive work, access network resources, or perform other 
            // operations that would lock up the user interface.
            //
            // If set to true, it is important not to show user interface 
            // elements of your own in the Execute method, as this will cause a 
            // cross-thread exception. Instead, use the PreExecute or 
            // PostExecute methods, as these are always executed on the user 
            // interface thread.
            this.IsLongRunning = false;
        }

        public override void Execute(VersionableCommandContext context)
        {
            MessageBox.Show("Executing a custom command for " + 
                context.Item.ToString());
        }
    }
}
