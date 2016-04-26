using Colectica.Portal.Extensibility;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Algenta.Colectica.Model;
using Algenta.Colectica.Model.Ddi;
using Colectica.Common.ItemViewModels;

namespace Colectica.Portal.SampleAddins.ViewInformation
{
    [Export(typeof(IPortalViewInformation))]
    public class SampleAddinViewInformation : IPortalViewInformation
    {
        public Guid ItemType
        {
            get
            {
                return DdiItemType.OrganizationScheme;
            }
        }

        public string ViewLocation
        {
            get
            {
                return "/Views/SampleView.cshtml";
            }
        }

        public VersionableItemViewModelBase GetViewModelForItem(IVersionable item)
        {
            return new VersionableItemViewModelBase<OrganizationScheme>(item as OrganizationScheme);
        }
    }
}
