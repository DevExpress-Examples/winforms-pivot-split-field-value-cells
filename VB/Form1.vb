Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data

Namespace XtraPivotGrid_SplittingCells
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
            AddHandler pivotGridControl1.CustomFieldValueCells, _
                AddressOf pivotGrid_CustomFieldValueCells
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			PivotHelper.FillPivot(pivotGridControl1)
			pivotGridControl1.DataSource = PivotHelper.GetDataTable()
			pivotGridControl1.BestFit()
		End Sub
        Protected Sub pivotGrid_CustomFieldValueCells(ByVal sender As Object, _
                        ByVal e As PivotCustomFieldValueCellsEventArgs)
            If pivotGridControl1.DataSource Is Nothing Then
                Return
            End If
            If radioGroup1.SelectedIndex = 0 Then
                Return
            End If

            ' Creates a predicate that returns true for the Grand Total
            ' headers, and false for any other column/row header.
            ' Only cells that match this predicate are split.
            Dim condition As New Predicate(Of FieldValueCell)(AddressOf AnonymousMethod1)

            ' Creates a list of cell definitions that represent newly created cells.
            ' Two definitions are added to the list. The first one identifies
            ' the Price cell, which has two nested cells (the Retail Price and Wholesale Price
            ' data field headers). The second one identifies the Count cell with 
            ' one nested cell (the Quantity data field header).
            Dim cells As New List(Of FieldValueSplitData)(2)
            cells.Add(New FieldValueSplitData("Price", 2))
            cells.Add(New FieldValueSplitData("Count", 1))

            ' Performs splitting.
            e.Split(True, condition, cells)
        End Sub
		
        Private Function AnonymousMethod1(ByVal matchCell As FieldValueCell) As Boolean
            Return matchCell.ValueType = PivotGridValueType.GrandTotal AndAlso _
                matchCell.Field Is Nothing
        End Function
        Private Sub pivotGridControl1_FieldValueDisplayText(ByVal sender As Object, _
                                    ByVal e As PivotFieldDisplayTextEventArgs) _
                                    Handles pivotGridControl1.FieldValueDisplayText
            If Object.Equals(e.Field, pivotGridControl1.Fields(PivotHelper.Month)) Then
                e.DisplayText = _
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(Fix(e.Value)))
            End If
        End Sub
        Private Sub radioGroup1_SelectedIndexChanged(ByVal sender As Object, _
                                ByVal e As EventArgs) _
                                Handles radioGroup1.SelectedIndexChanged
            Me.pivotGridControl1.LayoutChanged()
            pivotGridControl1.BestFit()
        End Sub
	End Class
End Namespace