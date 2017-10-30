using Algenta.Colectica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colectica.SampleAddins
{
    [Export(typeof(IAddinManifest))]
    public class SampleAddinManifest : IAddinManifest
    {
        public string Name { get => "Sample Addins"; set => throw new NotImplementedException(); }
        public string Version { get => "1.0"; set => throw new NotImplementedException(); }
        public DateTime Date { get => new DateTime(2017, 10, 30); set => throw new NotImplementedException(); }
        public string Publisher { get => "Colectica"; set => throw new NotImplementedException(); }
    }
}
