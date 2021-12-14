using Inventario.GUI.Models.Producto;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Helpers
{
    public class FabricaArchivosPDF
    {

        public bool CrearListadoProductosEnPDF(string pdfpath, string titulo, IEnumerable<ModeloProducto> listaDatos) 
        {
            try
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath, FileMode.Create));
                doc.Open();
                doc.Add(new Paragraph(new Phrase(titulo)));
                doc.Add(new Paragraph(new Phrase("")));
                doc.AddAuthor("Yimmy Diaz");
                doc.AddCreationDate();
                doc.AddLanguage("ES");

                PdfPTable tabla = new PdfPTable(8);
                float anchoColumna = (PageSize.A4.Width - (doc.LeftMargin + doc.RightMargin)) / 8;

                foreach (var registro in listaDatos)
                {
                    PdfPCell celda = new PdfPCell(new Paragraph(new Phrase(registro.Id)));
                    tabla.AddCell(celda);
                    celda = new PdfPCell(new Paragraph(new Phrase(registro.Nombre)));
                    tabla.AddCell(celda);
                    celda = new PdfPCell(new Paragraph(new Phrase(registro.Fecha.ToString("dd/MM/yyyy HH:mm:ss"))));
                    tabla.AddCell(celda);
                    celda = new PdfPCell(new Paragraph(new Phrase(registro.SerialProducto)));
                    tabla.AddCell(celda);
                    celda = new PdfPCell(new Paragraph(new Phrase(registro.NombreCategoria)));
                    tabla.AddCell(celda);
                    celda = new PdfPCell(new Paragraph(new Phrase(registro.NombreEspacio)));
                    tabla.AddCell(celda);
                    celda = new PdfPCell(new Paragraph(new Phrase(registro.NombreMarca)));
                    tabla.AddCell(celda);
                    celda = new PdfPCell(new Paragraph(new Phrase(registro.NombreTipoProducto)));
                    tabla.AddCell(celda);
                }
                doc.Add(tabla);
                doc.Close();
                writer.Close();
                return true; 
            }
            catch 
            {
                return false;
            }
        }
    }
}