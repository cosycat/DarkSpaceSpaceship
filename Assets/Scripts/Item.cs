using System;
using UnityEngine;

public class Item {
    private readonly int _x;
    private readonly int _y;

    // TODO specific sound

    public GameObject ItemGO { get; private set; }
    public GameObject ItemPrefab { get; private set; }
    public ItemType Type { get; }
    
    public int ItemNumber { get; private set; }
    public Room Room { get; }

    public Item(GameObject itemPrefab, ItemType type, int x, int y, Room room, int itemNumber = 0) {
        _x = x;
        _y = y;
        ItemPrefab = itemPrefab;
        // ItemGO = GameObject.Instantiate(itemPrefab);
        Type = type;
        Room = room;
        ItemNumber = itemNumber;
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
                RoomManager.Instance.CurrentHeldItem = this;
                AudioManager.Instance.Play("ItemFound");
                break;
            case ItemType.TRAP:
                break;
            case ItemType.OBSTACLE:
                break;
            case ItemType.RECHARGE:
                break;
            case ItemType.DEATH:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        DeleteGO();
    }

    public static Item CreateGoalItem(int x, int y, Room room, int goalNumber, bool invisible = false) {
        return new Item(invisible ? RoomManager.InvisiblePrefab : RoomManager.Instance.GoalPrefabs[goalNumber],
            ItemType.GOAL, x, y, room, goalNumber);
    }

    public static Item CreateTrapItem(int x, int y, Room room, int trapNumber, bool invisible = false) {
        return new Item(
            invisible ? RoomManager.InvisiblePrefab : RoomManager.Instance.TrapPrefabs[trapNumber],
            ItemType.TRAP, x, y, room, trapNumber);
    }

    public static Item CreateObstacleItem(int x, int y, Room room, int obstacleNumber, bool invisible = false) {
        return new Item(
            invisible ? RoomManager.InvisiblePrefab : RoomManager.Instance.ObstaclePrefabs[obstacleNumber],
            ItemType.OBSTACLE, x, y, room, invisible ? 0 : obstacleNumber);
    }

    public static Item CreateRechargeItem(int x, int y, Room room, int rechargeNumber, bool invisible = false) {
        return new Item(
            invisible ? RoomManager.InvisiblePrefab : RoomManager.Instance.RechargePrefabs[rechargeNumber],
            ItemType.RECHARGE, x, y, room, rechargeNumber);
    }

    public static Item CreateDeathItem(int x, int y, Room room) {
        return new Item(RoomManager.Instance.DeathPrefab, ItemType.DEATH, x, y, room);
    }

    public void SetCryochamberToUsed() {
        ItemNumber++;
        ItemPrefab = RoomManager.Instance.ObstaclePrefabs[ItemNumber];
    }
}

public enum ItemType {
    GOAL,
    TRAP,
    OBSTACLE,
    DEATH,
    RECHARGE
}

