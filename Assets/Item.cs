using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour {
    
    // TODO specific sound
    public Sprite Sprite { get; }
    public ItemType Type { get; }
    
}

public enum ItemType {
    GOAL,
    TRAP,
    OBSTACLE
}

