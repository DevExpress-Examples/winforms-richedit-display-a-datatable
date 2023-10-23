Imports System.Data

Namespace RichEditDisplayDataTable

    Public Class ProductsTable
        Inherits DataTable

        Public Sub New()
            MyBase.New()
            TableName = "ProductsTable"
            Columns.Add("ProductID", GetType(Integer))
            Columns.Add("ProductName", GetType(String))
            Columns.Add("UnitsInStock", GetType(Integer))
            Columns.Add("UnitPrice", GetType(Decimal))
            Constraints.Add("IDPK", Columns("ProductID"), True)
        End Sub

        Public Shared Function CreateData() As ProductsTable
            Dim table As ProductsTable = New ProductsTable()
            table.Rows.Add(New Object() {1, "Chai", 39, 18})
            table.Rows.Add(New Object() {2, "Chang", 17, 19})
            table.Rows.Add(New Object() {3, "Guarana Fantastica", 20, 4.5})
            table.Rows.Add(New Object() {4, "Sasquatch Ale", 111, 14})
            table.Rows.Add(New Object() {5, "Steeleye Stout", 20, 18})
            Return table
        End Function
    End Class
End Namespace
