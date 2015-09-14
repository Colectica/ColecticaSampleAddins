using Algenta.Colectica.ViewModel.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colectica.SampleAddins.Miscellaneous
{
    [Export(typeof(INodeDisplayLabelProvider))]
    public class SampleNodeDisplayLabelProvider : INodeDisplayLabelProvider
    {
        public string GetDisplayLabelForItem(Algenta.Colectica.Model.Repository.RepositoryItemMetadata item)
        {
            return item.Label.Best;
        }
    }
}
