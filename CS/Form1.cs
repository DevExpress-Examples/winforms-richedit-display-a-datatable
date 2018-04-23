using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraRichEdit.Utils;
using DevExpress.XtraRichEdit.API.Native;

namespace RichEditDisplayDataTable {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnDisplayProducts_Click(object sender, EventArgs e) {
            AppendDataTable(richEditControl1.Document, ProductsTable.CreateData());
        }

        private void AppendDataTable(Document document, DataTable dataTable) {
            int dataTableRows = dataTable.Rows.Count;
            int dataTableColumns = dataTable.Columns.Count;
            List<string> columnsToDisplay = new List<string>();

            for (int i = 0; i < dataTableColumns; i++) {
                string name = dataTable.Columns[i].ColumnName;
                
                // Skip PrimaryKey columns
                if (!name.ToUpper().EndsWith("ID"))
                    columnsToDisplay.Add(name);
            }

            document.BeginUpdate();

            Table table = document.Tables.Add(document.Range.End, dataTableRows + 1, columnsToDisplay.Count, AutoFitBehaviorType.AutoFitToWindow);

            table.TableLayout = TableLayoutType.Fixed;

            table.Borders.InsideHorizontalBorder.LineColor = Color.DarkBlue;
            table.Borders.InsideVerticalBorder.LineColor = Color.DarkBlue;
            table.Borders.InsideHorizontalBorder.LineThickness = 0.5f;
            table.Borders.InsideHorizontalBorder.LineStyle = TableBorderLineStyle.Single;
            table.Borders.InsideVerticalBorder.LineThickness = 0.5f;
            table.Borders.InsideVerticalBorder.LineStyle = TableBorderLineStyle.Single;

            table.LeftPadding = Units.InchesToDocumentsF(0.01f);

            table.FirstRow.Height = Units.InchesToDocumentsF(0.5f);
            table.FirstRow.HeightType = HeightType.Exact;

            ParagraphProperties pp = document.BeginUpdateParagraphs(table.FirstRow.Range);
            pp.Alignment = ParagraphAlignment.Center;
            document.EndUpdateParagraphs(pp);

            CharacterProperties cp = document.BeginUpdateCharacters(table.FirstRow.Range);
            cp.FontName = "Courier New";
            cp.ForeColor = Color.White;
            document.EndUpdateCharacters(cp);

            for (int i = 0; i < table.FirstRow.Cells.Count; i++) {
                table.FirstRow.Cells[i].BackgroundColor = Color.DarkBlue;
                table.FirstRow.Cells[i].VerticalAlignment = TableCellVerticalAlignment.Center;
            }

            // Fill table header with column names
            for (int i = 0; i < columnsToDisplay.Count; i++) {
                document.InsertText(table[0, i].Range.Start, columnsToDisplay[i]);
            }

            // Fill table body with data
            table.ForEachCell(delegate(TableCell cell, int rowIndex, int cellIndex) {
                if (rowIndex > 0) {
                    document.InsertText(cell.Range.Start, dataTable.Rows[rowIndex - 1][columnsToDisplay[cellIndex]].ToString());
                }
            });

            document.EndUpdate();
        }
    }
}