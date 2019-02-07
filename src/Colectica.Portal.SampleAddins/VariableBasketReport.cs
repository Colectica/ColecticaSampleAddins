using Algenta.Colectica.Model;
using Algenta.Colectica.Model.Ddi;
using Algenta.Colectica.Model.Repository;
using Algenta.Colectica.Model.Utility;
using Algenta.Colectica.ViewModel.Reports;
using Colectica.Reporting;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colectica.Portal.SampleAddins
{
    [Export(typeof(IItemListReport))]
    public class VariableBasketReport : IItemListReport
    {
        public string Title => "Variable Summary";
        public string FileTypeDescription => "PDF";
        public string DefaultExtension => "pdf";
        public string MimeType => "application/pdf";
        public string Path => "variable-summary";

        public bool CanCreateReport(DublinCore citation, List<RepositoryItemMetadata> items) => items.Any(x => x.ItemType == DdiItemType.Variable);

        public byte[] CreateReport(DublinCore citation, List<RepositoryItemMetadata> items, RepositoryClientBase client)
        {
            // Get identification for all the DDI variables in the item list.
            var variableIDs = items
                .Where(x => x.ItemType == DdiItemType.Variable)
                .Select(x => x.CompositeId)
                .ToIdentifierCollection();

            // Fetch all the variables.
            var allVariables = client.GetItems(variableIDs)
                .OfType<Variable>();

            // Use the Colectica.Reporting MigraDoc helper to create a PDF that
            // simply lists all variables with their names, labels, and types.
            var document = new Document();
            document.Info.Title = "Sample Variable Summary";

            // Add a title.
            var section = document.AddSection();
            var paragraph = section.AddParagraph(citation.Title.Best);
            paragraph.Format.Font.Bold = true;

            // Create the report helper.
            ReportContext context = new ReportContext();
            var builder = new ItemBuilderBase(document, context);

            // Make a list with one item for each variable.
            builder.DefineList();
            foreach (var variable in allVariables)
            {
                string lineText = $"{variable.ItemName.Best} - {variable.Label.Best} - {variable.RepresentationType}";
                builder.AddListItem(lineText);
            }

            // Render the PDF and return it.
            var pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            using (var stream = new MemoryStream())
            {
                pdfRenderer.Save(stream, true);
                var fileContents = stream.ToArray();
                return fileContents;
            }

        }
    }
}
