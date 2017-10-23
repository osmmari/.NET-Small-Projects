using System.Windows.Forms;

namespace Digger
{
	public static class Game
	{
		public static ICreature[,] Map;
		public static int MapWidth => Map.GetLength(0);
		public static int MapHeight => Map.GetLength(1);
		public static int Scores;
		public static bool IsOver;

		public static Keys KeyPressed;

		private const string mapWithPlayerTerrain = @"
TTT T
TTP T
T T T
TT TT";

		private const string mapWithPlayerTerrainSackGold = @"
PTTGTT TS
TST  TSTT
TTTTTTSTT
T TSTS TT
T TTTG ST
TSTSTT TT";

		private const string mapWithPlayerTerrainSackGoldMonster = @"
PTTGTT TST
TST  TSTTM
TTT TTSTTT
T TSTS TTT
T TTTGMSTS
T TMT M TS
TSTSTTMTTT
S TTST  TG
 TGST MTTT
 T  TMTTTT";

        private const string test = @"
 M 
 PM
M  
   
   
   ";


        public static void CreateMap()
		{
			Map = CreatureMapCreator.CreateMap(mapWithPlayerTerrainSackGoldMonster);
		}
	}
}