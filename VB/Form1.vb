Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports DevExpress.XtraRichEdit.Utils
Imports DevExpress.XtraRichEdit.API.Native

Namespace RichEditDisplayDataTable
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

        Dim dt As DataTable
        Dim columnsToDisplay As New List(Of String)()

		Private Sub btnDisplayProducts_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDisplayProducts.Click
            dt = ProductsTable.CreateData()
            AppendDataTable(richEditControl1.Document, dt)
		End Sub

		Private Sub AppendDataTable(ByVal document As Document, ByVal dataTable As DataTable)
			Dim dataTableRows As Integer = dataTable.Rows.Count
			Dim dataTableColumns As Integer = dataTable.Columns.Count

			For i As Integer = 0 To dataTableColumns - 1
				Dim name As String = dataTable.Columns(i).ColumnName

				' Skip PrimaryKey columns
				If (Not name.ToUpper().EndsWith("ID")) Then
					columnsToDisplay.Add(name)
				End If
			Next i

			document.BeginUpdate()

			Dim table As Table = document.Tables.Add(document.Range.End, dataTableRows + 1, columnsToDisplay.Count, AutoFitBehaviorType.AutoFitToWindow)

			table.TableLayout = TableLayoutType.Fixed

			table.Borders.InsideHorizontalBorder.LineColor = Color.DarkBlue
			table.Borders.InsideVerticalBorder.LineColor = Color.DarkBlue
			table.Borders.InsideHorizontalBorder.LineThickness = 0.5f
			table.Borders.InsideHorizontalBorder.LineStyle = TableBorderLineStyle.Single
			table.Borders.InsideVerticalBorder.LineThickness = 0.5f
			table.Borders.InsideVerticalBorder.LineStyle = TableBorderLineStyle.Single

			table.LeftPadding = Units.InchesToDocumentsF(0.01f)

			table.FirstRow.Height = Units.InchesToDocumentsF(0.5f)
			table.FirstRow.HeightType = HeightType.Exact

			Dim pp As ParagraphProperties = document.BeginUpdateParagraphs(table.FirstRow.Range)
			pp.Alignment = ParagraphAlignment.Center
			document.EndUpdateParagraphs(pp)

			Dim cp As CharacterProperties = document.BeginUpdateCharacters(table.FirstRow.Range)
			cp.FontName = "Courier New"
			cp.ForeColor = Color.White
			document.EndUpdateCharacters(cp)

			For i As Integer = 0 To table.FirstRow.Cells.Count - 1
				table.FirstRow.Cells(i).BackgroundColor = Color.DarkBlue
				table.FirstRow.Cells(i).VerticalAlignment = TableCellVerticalAlignment.Center
			Next i

			' Fill table header with column names
			For i As Integer = 0 To columnsToDisplay.Count - 1
				document.InsertText(table(0, i).Range.Start, columnsToDisplay(i))
			Next i

            table.ForEachCell(AddressOf TableCellProcessor)

            document.EndUpdate()
            columnsToDisplay.Clear()
        End Sub

        Private Sub TableCellProcessor(ByVal cell As TableCell, ByVal rowIndex As Integer, ByVal cellIndex As Integer)
            If rowIndex > 0 Then
                richEditControl1.Document.InsertText(cell.Range.Start, dt.Rows(rowIndex - 1)(columnsToDisplay(cellIndex)).ToString())
            End If
        End Sub
    End Class
End Namespace