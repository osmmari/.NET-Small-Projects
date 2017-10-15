using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Digger
{
    [TestFixture]
    public partial class GameTests
    {
        [SetUp]
        public void Init()
        {
            Game.Scores = 0;
            Game.IsOver = false;
            Game.MapWidth = 0;
            Game.MapHeight = 0;
            Game.Map = null;
            Game.KeyPressed = Keys.None;
        }

        [TearDown]
        public void Dispose()
        {
            Game.Scores = 0;
            Game.IsOver = false;
            Game.MapWidth = 0;
            Game.MapHeight = 0;
            Game.Map = null;
            Game.KeyPressed = Keys.None;
        }

        [Test]
        public void TestGame()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = null,
                KeyPressed = Keys.None,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[] { },
                KeyPressed = Keys.None,
            };

            DoTest(expectedGame, inputGame, "Initialize empty map if there is no map");
        }

        [Test]
        public void TestTerrain_1()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "######",
                    "######",
                    "######",
                },
                KeyPressed = Keys.None,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "######",
                    "######",
                    "######",
                },
                KeyPressed = Keys.None,
            };

            DoTest(expectedGame, inputGame, "Do nothing when there is only terrain");
        }

        [Test]
        public void TestTerrain_2()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    " #####",
                    " #  ##",
                    " #####",
                },
                KeyPressed = Keys.None,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    " #####",
                    " #  ##",
                    " #####",
                },
                KeyPressed = Keys.None,
            };

            DoTest(expectedGame, inputGame, "Do nothing when there is only terrain and nothing");
        }

        [Test]
        public void TestPlayer_1()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "@#####",
                    " #  ##",
                    " #####",
                },
                KeyPressed = Keys.None,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "@#####",
                    " #  ##",
                    " #####",
                },
                KeyPressed = Keys.None,
            };

            DoTest(expectedGame, inputGame, "Do not move player if key is not pressed");
        }

        [Test]
        public void TestPlayer_2()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  @  ",
                    "     ",
                },
                KeyPressed = Keys.None,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  @  ",
                    "     ",
                },
                KeyPressed = Keys.None,
            };

            DoTest(expectedGame, inputGame, "Do not move player if key is not pressed");
        }

        [Test]
        public void TestPlayer_3()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "@#####",
                    "##  ##",
                    "#   ##",
                },
                KeyPressed = Keys.Left,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "@#####",
                    "##  ##",
                    "#   ##",
                },
                KeyPressed = Keys.Left,
            };

            DoTest(expectedGame, inputGame, "Do not move player if it is not possible");
        }

        [Test]
        public void TestPlayer_4()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "@#####",
                    "##  ##",
                    "#   ##",
                },
                KeyPressed = Keys.Left,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "@#####",
                    "##  ##",
                    "#   ##",
                },
                KeyPressed = Keys.Left,
            };

            DoTest(expectedGame, inputGame, "Do not move player if it is not possible");
        }

        [Test]
        public void TestPlayer_5()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "@    ",
                    "     ",
                },
                KeyPressed = Keys.Left,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "@    ",
                    "     ",
                },
                KeyPressed = Keys.Left,
            };

            DoTest(expectedGame, inputGame, "Do not move player through left border");
        }

        [Test]
        public void TestPlayer_6()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "    @",
                    "     ",
                },
                KeyPressed = Keys.Right,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "    @",
                    "     ",
                },
                KeyPressed = Keys.Right,
            };

            DoTest(expectedGame, inputGame, "Do not move player through right border");
        }

        [Test]
        public void TestPlayer_7()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  @  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Up,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  @  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Up,
            };

            DoTest(expectedGame, inputGame, "Do not move player through top border");
        }

        [Test]
        public void TestPlayer_8()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "  @  ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "  @  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Do not move player through bottom border");
        }

        [Test]
        public void TestPlayer_9()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  @  ",
                    "  $  ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 10,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "  @  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Player should eat gold");
        }

        [Test]
        public void TestPlayer_10()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    " ### ",
                    " #@# ",
                    " ### ",
                    " ### ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    " ### ",
                    " # # ",
                    " #@# ",
                    " ### ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Player should eat terrain");
        }

        [Test]
        public void TestPlayer_11()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "#####",
                    "##&##",
                    "##@##",
                    "## ##",
                    "   $ ",
                },
                KeyPressed = Keys.None,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "#####",
                    "##&##",
                    "##@##",
                    "## ##",
                    "   $ ",
                },
                KeyPressed = Keys.None,
            };

            DoTest(expectedGame, inputGame, 2, "Player should hold sack");
        }

        [Test]
        public void TestPlayer_12()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "#####",
                    "##&##",
                    "  @##",
                    " ####",
                    "   $ ",
                },
                KeyPressed = Keys.None,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "#####",
                    "##&##",
                    "  @##",
                    " ####",
                    "   $ ",
                },
                KeyPressed = Keys.None,
            };

            DoTest(expectedGame, inputGame, 2, "Player should hold sack");
        }

        [Test]
        public void TestPlayer_13()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  @  ",
                    "     ",
                },
                KeyPressed = Keys.Left,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    " @   ",
                    "     ",
                },
                KeyPressed = Keys.Left,
            };

            DoTest(expectedGame, inputGame, "Player should move in left direction");
        }

        [Test]
        public void TestPlayer_14()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  @  ",
                    "     ",
                },
                KeyPressed = Keys.Right,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "   @ ",
                    "     ",
                },
                KeyPressed = Keys.Right,
            };

            DoTest(expectedGame, inputGame, "Player should move in right direction");
        }

        [Test]
        public void TestPlayer_15()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  @  ",
                    "     ",
                },
                KeyPressed = Keys.Up,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  @  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Up,
            };

            DoTest(expectedGame, inputGame, "Player should move in top direction");
        }

        [Test]
        public void TestPlayer_16()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  @  ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "  @  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Player should move in bottom direction");
        }

        [Test]
        public void TestSack_1()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  &  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  &  ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Sack should fall down");
        }

        [Test]
        public void TestSack_2()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "  &  ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "  &  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Sack should not fall down when there is end of map under him");
        }

        [Test]
        public void TestSack_3()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  &  ",
                    "  #  ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  &  ",
                    "  #  ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Sack should not fall down when there is terrain under him");
        }

        [Test]
        public void TestSack_4()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  &  ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "  &  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Sack should not turn into gold if he fly over one position");
        }

        [Test]
        public void TestSack_5()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "     ",
                    "  &  ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "     ",
                    "     ",
                    "  &  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, "Sack should not turn into gold if he fly over one position");
        }

        [Test]
        public void TestSack_6()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    " &   ",
                    "     ",
                    "###  ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    " &   ",
                    "###  ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 3, "Sack should not turn into gold if he fly only one position");
        }

        [Test]
        public void TestSack_7()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "  &  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "     ",
                    "     ",
                    "  $  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 3, "Sack should not turn into gold if he fly more than one position and arrive border of map");
        }

        [Test]
        public void TestSack_8()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    " &   ",
                    "     ",
                    "     ",
                    "###  ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "     ",
                    " $   ",
                    "###  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 3, "Sack should not turn into gold if he fly more than one position and arrive terrain");
        }

        [Test]
        public void TestSack_9()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    " &   ",
                    "     ",
                    " $   ",
                    "###  ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    " &   ",
                    " $   ",
                    "###  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 3, "Sack should not destroy gold under him if he fly only one position");
        }

        [Test]
        public void TestSack_10()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    " &   ",
                    "     ",
                    " $   ",
                    "###  ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    " &   ",
                    " $   ",
                    "###  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 2, "Sack should not destroy gold under him if he fly only one position");
        }

        [Test]
        public void TestSack_11()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  &  ",
                    "     ",
                    "  $  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  &  ",
                    "  $  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 5, "Sack should not destroy gold under him if he fly only one position");
        }

        [Test]
        public void TestSack_12()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  &  ",
                    "     ",
                    "  $  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "  &  ",
                    "  $  ",
                    "     ",
                    "     ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 4, "Sack should not destroy gold under him if he fly only one position");
        }

        [Test]
        public void TestGold_1()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    " $   ",
                    "     ",
                    "     ",
                    "###  ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    " $   ",
                    "     ",
                    "     ",
                    "###  ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 3, "Gold should keep position");
        }

        [Test]
        public void TestGold_2()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  $  ",
                    "     ",
                    "  $  ",
                    "     ",
                    "   $ ",
                },
                KeyPressed = Keys.Down,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  $  ",
                    "     ",
                    "  $  ",
                    "     ",
                    "   $ ",
                },
                KeyPressed = Keys.Down,
            };

            DoTest(expectedGame, inputGame, 2, "Gold should keep position");
        }

        [Test]
        public void UlearnTest23()
        {
            var inputGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "  &  ",
                    "     ",
                    "     ",
                    "     ",
                    "  $  ",
                },
                KeyPressed = Keys.None,
            };

            var expectedGame = new VisualGame()
            {
                Scores = 0,
                Map = new string[]
                {
                    "     ",
                    "     ",
                    "     ",
                    "  $  ",
                    "  $  ",
                },
                KeyPressed = Keys.None,
            };

            DoTest(expectedGame, inputGame, 5, "Sack should break up when fly for more than one cell and hit another Gold (TEST 23)");
        }

        private void DoTest(VisualGame expectedGame, VisualGame inputGame, int stepCount, string message)
        {
            GameTools.SetGame(inputGame);
            for (int i = 0; i < stepCount; i++)
                GameTools.DoStep();
            var actualGame = GameTools.GetGame();
            Assert.True(expectedGame.IsEqualTo(actualGame), message);
        }

        private void DoTest(VisualGame expectedGame, VisualGame inputGame, string message)
        {
            DoTest(expectedGame, inputGame, 1, message);
        }
    }

    public static class GameTools
    {
        public static void DoStep()
        {
            var newMap = new ICreature[Game.MapWidth, Game.MapHeight];
            for (int x = 0; x < Game.MapWidth; x++)
            {
                for (int y = 0; y < Game.MapHeight; y++)
                {
                    var creature = Game.Map[x, y];
                    if (creature == null) continue;
                    var command = creature.Act(x, y);

                    if (x + command.DeltaX < 0 ||
                        x + command.DeltaX >= Game.MapWidth ||
                        y + command.DeltaY < 0 ||
                        y + command.DeltaY >= Game.MapHeight)
                    {
                        throw new Exception($"The object {creature.GetType()} falls out of the game field");
                    }

                    var nextX = x + command.DeltaX;
                    var nextY = y + command.DeltaY;
                    var nextCreature = command.TransformTo == null ? creature : command.TransformTo;
                    if (newMap[nextX, nextY] == null) newMap[nextX, nextY] = nextCreature;
                    else
                    {
                        bool newDead = nextCreature.DeadInConflict(newMap[nextX, nextY]);
                        bool oldDead = newMap[nextX, nextY].DeadInConflict(nextCreature);
                        if (newDead && oldDead)
                            newMap[nextX, nextY] = null;
                        else if (!newDead && oldDead)
                            newMap[nextX, nextY] = nextCreature;
                        else if (!newDead && !oldDead)
                            throw new Exception(
                                string.Format(
                                    "Существа {0} и {1} претендуют на один и тот же участок карты",
                                    nextCreature.GetType().Name,
                                    newMap[nextX, nextY].GetType().Name
                                )
                            );
                    }
                }
            }
            Game.Map = newMap;
        }

        public static void SetGame(VisualGame visualGame)
        {
            ResetAllGameFields();

            Game.IsOver = visualGame.IsOver;
            Game.KeyPressed = visualGame.KeyPressed;
            Game.Scores = visualGame.Scores;

            if (visualGame.Map == null)
                return;

            Game.MapHeight = visualGame.Map.Length;
            Game.MapWidth = visualGame.Map.Length > 0 ? visualGame.Map[0].Length : 0;
            if (Game.MapWidth == 0 || Game.MapHeight == 0)
                return;

            Game.Map = new ICreature[Game.MapWidth, Game.MapHeight];
            for (int x = 0; x < Game.MapWidth; x++)
                for (int y = 0; y < Game.MapHeight; y++)
                    Game.Map[x, y] = GetCreatureBySymbol(visualGame.Map[y][x]);
        }

        public static VisualGame GetGame()
        {
            var visualGame = new VisualGame()
            {
                IsOver = Game.IsOver,
                KeyPressed = Game.KeyPressed,
                Scores = Game.Scores,
                Map = GetMap(),
            };
            return visualGame;
        }

        public static string[] GetMap()
        {
            if (Game.Map == null)
                return null;

            return
                Enumerable
                .Range(0, Game.MapHeight)
                .Select(j => string.Join(
                        "",
                        Enumerable
                        .Range(0, Game.MapWidth)
                        .Select(i => GetSymbolByCreature(Game.Map[i, j]))
                    )
                )
                .ToArray();
        }

        public static ICreature GetCreatureBySymbol(char symbol)
        {
            ICreature creature = null;
            if (symbol == '@') creature = new Player();
            //if (symbol == 'x') creature = new Monster();
            if (symbol == '#') creature = new Terrain();
            if (symbol == '&') creature = new Sack();
            if (symbol == '$') creature = new Gold();
            return creature;
        }

        public static char GetSymbolByCreature(ICreature creature)
        {
            if (creature is Player) return '@';
            //if (creature is Monster) return 'x';
            if (creature is Terrain) return '#';
            if (creature is Sack) return '&';
            if (creature is Gold) return '$';
            return ' ';
        }

        public static void ResetAllGameFields()
        {
            Game.Scores = 0;
            Game.IsOver = false;
            Game.MapWidth = 0;
            Game.MapHeight = 0;
            Game.Map = null;
            Game.KeyPressed = Keys.None;
        }
    }

    public class VisualGame
    {
        public bool IsOver = false;
        public int Scores = 0;
        public string[] Map = null;
        public Keys KeyPressed;

        public bool IsEqualTo(VisualGame visualGame)
        {
            if (
                IsOver != visualGame.IsOver ||
                Scores != visualGame.Scores ||
                KeyPressed != visualGame.KeyPressed
            )
            {
                return false;
            }

            if (Map == null && visualGame.Map == null)
                return true;

            if ((visualGame.Map == null && Map != null) || (visualGame.Map != null && Map == null))
                return false;

            if (Map.Length != visualGame.Map.Length)
                return false;

            for (int i = 0; i < Map.Length; i++)
                if (Map[i].CompareTo(visualGame.Map[i]) != 0)
                    return false;

            return true;
        }
    }
}