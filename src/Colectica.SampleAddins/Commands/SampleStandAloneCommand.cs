using Algenta.Colectica.Model;
using Algenta.Colectica.Model.Ddi;
using Algenta.Colectica.ViewModel;
using Algenta.Colectica.ViewModel.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;

namespace Colectica.SampleAddins.Commands
{
    /// <summary>
    /// A sample command that adds a button to the main ribbon.
    /// </summary>
    /// <remarks>
    /// The Export attribute tells Colectica that this class contains an Addin
    /// of the type specified as the parameter, in this case an 
    /// IStandAloneCommand.
    /// 
    /// The class should also implement the IStandAloneCommand interface. 
    /// In this case Colectica SDK provides the StandAloneCommandBase class,   
    /// which implements the interface for us. We can derive from that class 
    /// and set its properties, set its properties in the constructor, and 
    /// override the Execute method to implement the desired functionality.
    /// </remarks>
    [Export(typeof(IStandAloneCommand))]
    public class SampleStandAloneCommand : StandAloneCommandBase
    {
        // To get access to the Api object, simply create a property of type
        // IApplicationApi and add an Import attribute to it.
        [Import]
        public IApplicationApi Api { get; set; }

        public SampleStandAloneCommand()
        {
            // Name determines the text that is displayed on the button.
            this.Name = "My StandAlone Command";

            // Weight determines the order of the item, compared to other 
            // commands.
            this.Weight = 1000;

            // Category determines in which tab of the ribbon this button will
            // appear.
            this.Category = "Samples";

            // SubCategory determines in which group of ribbon items this
            // command will appear.
            this.SubCategory = "DDI";

            // Image determines what picture will be displayed on the button.
            this.Image = "ddilogo.png";
        }

        public override void Execute()
        {
            // Ask the user to select a file.
            var dlg = new OpenFileDialog();
            bool? result = dlg.ShowDialog();

            // If the user pressed Cancel, don't continue.
            if (!result.HasValue || !result.Value)
            {
                this.Result.IsSuccessful = false;
                this.Result.MessageTitle = "User Cancelled";
                this.Result.MessageText = "The user cancelled the operation.";
                this.Result.MessageDetails = "Even more details can go here.";
                return;
            }
            
            // Now we'll create a new StudyUnit with the same name of that 
            // file. Of course, if the file contained some interesting
            // information, we could process the file and set that information
            // as part of our new object.
            var myStudy = new StudyUnit();
            myStudy.DublinCoreMetadata.Title.Current = 
                Path.GetFileNameWithoutExtension(dlg.FileName);

            // Add any new items to a collection, and use the Api object
            // to tell Designer about them.
            var newItems = new Collection<IVersionable>();
            newItems.Add(myStudy);
            this.Api.Import(newItems);

            // Add the new item to the ModifiedItems of the Result property,
            // to let Colectica know that you created something new.
            this.Result.ModifiedItems.Add(myStudy);
        }
    }
}
