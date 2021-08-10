using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Command.Commands
{
    public class CreatePdfFileActionCommand<T> : ITableButtonActionCommand
    {
        private readonly PdfFile<T> _pdfFile;
        public CreatePdfFileActionCommand(PdfFile<T> pdfFile)
        {
            _pdfFile = pdfFile;
        }


        public IActionResult Execute()
        {
            var memoryStream = _pdfFile.Create();
            return new FileContentResult(memoryStream.ToArray(), _pdfFile.FileType) { FileDownloadName = _pdfFile.FileName };
        }
    }
}
