using Algenta.Colectica.Model;
using Algenta.Colectica.Model.Ddi;
using Algenta.Colectica.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Colectica.SampleAddins.Commands
{
    /// <summary>
    /// A sample command that executes when a StudyUnit is created.
    /// </summary>
    /// <remarks>
    /// The Export attribute tells Colectica that this class contains an Addin
    /// of the type specified as the parameter, in this case an 
    /// IVersionableInitializerCommand. These commands are executed when a new
    /// item is created.
    /// 
    /// The class should also implement IVersionableInitializerCommand.
    /// </remarks>
    [Export(typeof(IVersionableInitializerCommand))]
    public class SampleVersionableInitializer : IVersionableInitializerCommand
    {
        /// <summary>
        /// Override to determine whether this initializer should execute
        /// for the given item.
        /// </summary>
        /// <param name="itemType">The type of the item being created.</param>
        /// <returns></returns>
        public bool CanEverExecute(Guid itemType)
        {
            // This sample will initialize all StudyUnit items as they are 
            // created.
            return itemType == DdiItemType.StudyUnit;
        }

        /// <summary>
        /// Executes when an item is created.
        /// </summary>
        /// <param name="item">The item being created.</param>
        public void Execute(IVersionable item)
        {
            // Cast the item as a StudyUnit, and make sure it is what we expect.
            var studyUnit = item as StudyUnit;
            if (studyUnit == null)
            {
                return;
            }

            // Initialize the abstract.
            studyUnit.StudyAbstract.Current = "Hello, world.";

            // Initialize the copyright property of the Dublin Core metadata.
            studyUnit.DublinCoreMetadata.Rights.Current = 
                "Created as a Sample.";
        }

        // The following properties are not currently important for the 
        // initializer commands.
        public string Category
        {
            get { return string.Empty; }
        }

        public string Image
        {
            get { return string.Empty; }
        }

        public string Name
        {
            get { return "Sample StudyUnit Initializer"; }
        }

        public string SubCategory
        {
            get { return string.Empty; }
        }

        public int Weight
        {
            get { return 1000; }
        }
    }
}
