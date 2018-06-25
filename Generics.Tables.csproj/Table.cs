using System;
using System.Collections.Generic;

namespace Generics.Tables
{
	public class Table<TRow, TColumn, TValue> where TValue : new()
	{
		private HashSet<TRow> rows;
		private HashSet<TColumn> columns;

		public HashSet<TRow> Rows { get { return rows; } set { rows = value; } }
		public HashSet<TColumn> Columns { get { return columns; } set { columns = value; } }

		private Dictionary<Tuple<TRow, TColumn>, TValue> table;

		public NewCell Open { get { return new NewCell (this); } set { } }
		public ExistedCell Existed { get { return new ExistedCell (this); } set {} }

		public TValue GetValue(TRow row, TColumn column)
		{
			var index = new Tuple<TRow, TColumn> (row, column);
			return table.ContainsKey (index) ? table [index] : new TValue ();
		}

        public void SetValue(TRow row, TColumn column, TValue value)
        {
            var index = new Tuple<TRow, TColumn>(row, column);
            table[index] = value;
        }

		public void AddRow(TRow row)
		{
			if (!rows.Contains (row))
				rows.Add (row);
		}

		public void AddColumn(TColumn column)
		{
			if (!columns.Contains (column))
				columns.Add (column);
		}

		public Table()
		{
			rows = new HashSet<TRow> ();
			columns = new HashSet<TColumn> ();
			table = new Dictionary<Tuple<TRow, TColumn>, TValue> ();
		}

		public abstract class Cell
		{
			protected Table<TRow, TColumn, TValue> table;

			public Cell(Table<TRow, TColumn, TValue> _table)
			{
				table = _table;
			}
		}

		public class NewCell : Cell
		{
			public NewCell(Table<TRow, TColumn, TValue> _table) : base(_table) {}

			public TValue this[TRow row, TColumn column]
			{
				get 
				{
                    return table.GetValue(row, column);
				}
				set
                {
                    table.AddRow(row);
                    table.AddColumn(column);
                    table.SetValue(row, column, value);
                }
			}
		}

		public class ExistedCell : Cell
		{
			public ExistedCell(Table<TRow, TColumn, TValue> _table) : base(_table) {}

			public TValue this[TRow row, TColumn column]
			{
                get
                {
                    if (table.Rows.Contains(row) && table.Columns.Contains(column))
                        return table.GetValue(row, column);
                    else
                    {
                        throw new ArgumentException("There's no such cell.");
                    }
                }
                set
                {
                    if (table.Rows.Contains(row) && table.Columns.Contains(column))
                        table.SetValue(row, column, value);
                    else throw new ArgumentException("There's no such cell.");
                }
            }
		}
	}
}