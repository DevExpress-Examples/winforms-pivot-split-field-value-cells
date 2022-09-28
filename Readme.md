<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128582575/21.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2763)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Pivot Grid for WinForms - Split Field Value Cells

The following example demonstrates how to split field value cells. In this example, the Grand Total column header is split into two cells: _Price_ and _Count_. In this example, the Grand Total column header is split into two cells: Price and Count. To do this, the CustomFieldValueCells event is handled, and the event parameter's Split method is used. Cells that should be split are identified by a predicate that returns true for those cells. The quantity, size and captions of newly created cells are specified by an array of cell definitions (the FieldValueSplitData objects).

![Pivot Grid](images/pivotgrid.png)

## Files to Review

<!-- default file list -->
* [Data.cs](./CS/Data.cs) (VB: [Data.vb](./VB/Data.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->

## More Examples

[Pivot Grid for WinForms - Hide Row Totals](https://github.com/DevExpress-Examples/winforms-pivotgrid-hide-totals-customcellvalue)
