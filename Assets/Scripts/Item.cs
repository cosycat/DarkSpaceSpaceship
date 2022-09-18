using System;
using UnityEngine;

public class Item {
    private readonly int _x;
    private readonly int _y;

    // TODO specific sound

    public GameObject ItemGO { get; private set; }
    public GameObject ItemPrefab { get; }
    public ItemType Type { get; }
    public Room Room { get; }

    public Item(GameObject itemPrefab, ItemType type, int x, int y, Room room) {
        _x = x;
        _y = y;
        ItemPrefab = itemPrefab;
        // ItemGO = GameObject.Instantiate(itemPrefab);
        Type = type;
        Room = room;
        // ItemGO.transform.position = new Vector3(x, y);
    }

    public void CreateGO() {
        ItemGO = GameObject.Instantiate(ItemPrefab);
        ItemGO.transform.position = new Vector3(_x, _y);
    }

    public void DeleteGO() {
        if (ItemGO == null) return;
        GameObject.DestroyImmediate(ItemGO);
    }

    public void OnConsume() {
        switch (Type) {
            case ItemType.GOAL:
                // TODO What happens if we reach a goal?
                Debug.Log("Reached Goal!");
                break;
            case ItemType.TRAP:
                break;
            case ItemType.OBSTACLE:
                break;
            case ItemType.RECHARGE:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        DeleteGO();
    }

    public static Item CreateGoalItem(int x, int y, Room room, int goalNumber, bool invisible = false) {
        return new Item(invisible ? RoomManager.InvisiblePrefab : RoomManager.Instance.GoalPrefabs[goalNumber],
            ItemType.GOAL, x, y, room);
    }

    public static Item CreateTrapItem(int x, int y, Room room, int trapNumber, bool invisible = false) {
        return new Item(
            invisible ? RoomManager.InvisiblePrefab : RoomManager.Instance.TrapPrefabs[trapNumber],
            ItemType.TRAP, x, y, room);
    }

    public static Item CreateObstacleItem(int x, int y, Room room, int obstacleNumber, bool invisible = false) {
        return new Item(
            invisible ? RoomManager.InvisiblePrefab : RoomManager.Instance.ObstaclePrefabs[obstacleNumber],
            ItemType.OBSTACLE, x, y, room);
    }

    public static Item CreateRechargeItem(int x, int y, Room room, int rechargeNumber, bool invisible = false) {
        return new Item(
            invisible ? RoomManager.InvisiblePrefab : RoomManager.Instance.RechargePrefabs[rechargeNumber],
            ItemType.RECHARGE, x, y, room);
    }

    public static Item CreateDeathItem(int x, int y, Room room) {
        return new Item(RoomManager.Instance.DeathPrefab, ItemType.DEATH, x, y, room);
    }
}

public enum ItemType {
    GOAL,
    TRAP,
    OBSTACLE,
    DEATH,
    RECHARGE
}

