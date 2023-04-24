using System.Threading.Tasks;
using Altinn.App.Core.Features;
using Altinn.App.Core.Models;

namespace Altinn.App.AppLogic.Print
{
    public class PdfHandler : IPdfFormatter
    {
        public Task<LayoutSettings> FormatPdf(LayoutSettings layoutSettings, object data)
        {
           //return Task.FromResult(layoutSettings);
            return Task.FromResult(layoutSettings);
           // throw new System.NotImplementedException();
        }
    }
}