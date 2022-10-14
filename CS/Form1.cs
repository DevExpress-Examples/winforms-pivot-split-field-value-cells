using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;

namespace XtraPivotGrid_SplittingCells {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            pivotGridControl1.CustomFieldValueCells += 
                new PivotCustomFieldValueCellsEventHandler(pivotGrid_CustomFieldValueCells);
        }
        void Form1_Load(object sender, EventArgs e) {
            PivotHelper.FillPivot(pivotGridControl1);
            pivotGridControl1.DataSource = PivotHelper.GetDataTable();
            pivotGridControl1.BestFit();
        }
        protected void pivotGrid_CustomFieldValueCells(object sender,
                             PivotCustomFieldValueCellsEventArgs e) {
            PivotGridControl pivot = sender as PivotGridControl;
            if (pivot.DataSource == null) return;
            if (radioGroup1.SelectedIndex == 0) return;

            // Creates a predicate that returns true for the Grand Total headers, 
            // and false for any other column/row header.
            // Only cells that match this predicate are split.
            Predicate<FieldValueCell> condition =
                new Predicate<FieldValueCell>(delegate(FieldValueCell matchCell) {
                return matchCell.ValueType == PivotGridValueType.GrandTotal &&
                    matchCell.Field == null;
            });

            // Creates a list of cell definitions that represent newly created cells.
            // Two definitions are added to the list. The first one identifies the Price cell, 
            // which has two nested cells (the Retail Price and Wholesale Price
            // data field headers). The second one identifies the Count cell with 
            // one nested cell (the Quantity data field header).
            List<FieldValueSplitData> cells = new List<FieldValueSplitData>(2);
            cells.Add(new FieldValueSplitData("Price", 2));
            cells.Add(new FieldValueSplitData("Count", 1));

            // Performs splitting.
            e.Split(true, condition, cells);
        }
        void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e) {
            PivotGridControl pivot = sender as PivotGridControl;
            if (e.Field == pivot.Fields[PivotHelper.Month])
            {
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)e.Value);
            }
        }
        void radioGroup1_SelectedIndexChanged(object sender, EventArgs e) {
            this.pivotGridControl1.LayoutChanged();
        }        
    }
}
