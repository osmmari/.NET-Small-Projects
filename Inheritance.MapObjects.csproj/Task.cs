using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{
    interface IOwner
    {
        int Owner { get; set; }
    }

    interface IArmy
    {
        Army Army { get; set; }
    }

    interface ITreasure
    {
        Treasure Treasure { get; set; }
    }

    public class Dwelling : IOwner
    {
        public int Owner { get; set; }

        public void Interact(Player player)
        {
            Owner = player.Id;
        }
    }
    
    public class Mine : IOwner, IArmy, ITreasure
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void Interact(Player player)
        {
            if (player.CanBeat(Army))
            {
                Owner = player.Id;
                player.Consume(Treasure);
            }
            else player.Die();
        }
    }

    public class Creeps : IArmy, ITreasure
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void Interact(Player player)
        {
            if (player.CanBeat(Army))
                player.Consume(Treasure);
            else
                player.Die();
        }
    }

    public class Wolfs : IArmy
    {
        public Army Army { get; set; }

        public void Interact(Player player)
        {
            if (!player.CanBeat(Army))
                player.Die();
        }
    }

    public class ResourcePile : ITreasure
    {
        public Treasure Treasure { get; set; }

        public void Interact(Player player)
        {
            player.Consume(Treasure);
        }
    }

    public static class Interaction
    {
        public static void Make(Player player, object mapObject)
        {
            if (mapObject is IArmy)
            {
                if (player.CanBeat((mapObject as IArmy).Army))
                {
                    if (mapObject is IOwner)
                        (mapObject as IOwner).Owner = player.Id;
                    if (mapObject is ITreasure)
                        player.Consume((mapObject as ITreasure).Treasure);
                }
                else
                    player.Die();
            }
            else
            {
                if (mapObject is IOwner) (mapObject as IOwner).Owner = player.Id;
                if (mapObject is ITreasure)
                {
                    player.Consume((mapObject as ITreasure).Treasure);
                }
            }
        }
    }
}
