using System;

namespace TableParser
{
	public class Token
	{
		/// <summary>
		/// В задачах разбора текстов обычно удобно выделять подзадачу разбиения текста на логические фрагменты.
		/// Такие фрагменты называют токенами или лексемами. 
		/// А сам процесс разбиения текста на токены — лексическим анализом текста.
		/// </summary>
		/// <param name="value">Проинтерпретированное значение токена</param>
		/// <param name="startIndex">Позиция начала токена в исходной строке</param>
		/// <param name="length">Длина токена в исходной строке. Может не совпадать с длиной <paramref name="value"/></param>
		public Token(string value, int startIndex, int length)
		{
			StartIndex = startIndex;
			Length = length;
			Value = value;
		}

		public readonly int StartIndex;
		public readonly int Length;
		public readonly string Value;

		public int GetIndexNextToToken()
		{
			return StartIndex + Length;
		}

		public override string ToString()
		{
			return String.Format("{0} ({1}, {2})", Value, StartIndex, Length);
		}
	}
}