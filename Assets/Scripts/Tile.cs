using System.Collections.Generic;
using JetBrains.Annotations;

public class Tile {
    
    public TileType Type { get; private set; }

    [CanBeNull] public Item ItemOnTile { get; private set; } = null;

    public Tile(TileType type = TileType.FLOOR) {
        Type = type;
    }

    public Tile(Item item) {
        ItemOnTile = item;
    }

    public void ConsumeItem() {
        ItemOnTile?.OnConsume();
    }
}