using Algenta.Colectica.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;

namespace Colectica.SampleAddins.Commands
{
    /// <summary>
    /// Provides one or more IVersionableCommands to Colectica Designer.
    /// </summary>
    [Export(typeof(IVersionableCommandProvider))]
    public class SampleVersionableCommandProvider : IVersionableCommandProvider
    {
        public Collection<IVersionableCommand> GetCommands(Guid itemType)
        {
            var result = new Collection<IVersionableCommand>();

            // Here, we will create four commands to be displayed in the 
            // ribbon. Each command has a unique parameter, in this case
            // just a simple string.
            string[] parameters = new[]
            {
                "Param 1",
                "Param 2",
                "Param 3",
                "Param 4"
            };

            int weight = 10000;
            foreach (string param in parameters)
            {
                var command = new SampleCommandWithParameter(param, weight);
                weight++;
                result.Add(command);
            }

            return result;
        }
    }

    // For commands that will be instantiated and returned by a 
    // VersionableCommandProvider, do *not* use the Export attribute on the
    // class. Instead, the provider's class is Exported, and the individual
    // commands are discovered through that.
    public class SampleCommandWithParameter : VersionableCommandBase
    {
        public SampleCommandWithParameter(string param, int weight)
        {
            this.Parameter = param;
            this.Name = "Command with " + param;

            this.Weight = weight;
        }

        public override void Execute(VersionableCommandContext context)
        {
            MessageBox.Show("Executing command with parameter: " + 
                this.Parameter);
        }
    }

}
