using System.Collections.Generic;
using JetBrains.Annotations;

public class Tile {
    [CanBeNull] private Item _itemOnTile = null;

    public TileType Type { get; private set; }

    [CanBeNull]
    public Item ItemOnTile {
        get => _itemOnTile;
        set {
            _itemOnTile?.DeleteGO();
            _itemOnTile = value;
        }
    }

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