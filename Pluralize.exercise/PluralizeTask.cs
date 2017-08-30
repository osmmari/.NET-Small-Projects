namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
            string result;
            if ((((count - 1) % 10 == 0) && ((count + 89) % 100 != 0)) || count == 1) result = "рубль";
            else if ((((count - 2) % 10 == 0) && ((count + 88) % 100 != 0)) || count == 2) result = "рубля";
            else if ((((count - 3) % 10 == 0) && ((count + 87) % 100 != 0)) || count == 3) result = "рубля";
            else if ((((count - 4) % 10 == 0) && ((count + 86) % 100 != 0)) || count == 4) result = "рубля";
            else result = "рублей";
            return result;
		}
	}
}