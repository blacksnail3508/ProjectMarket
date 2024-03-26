using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitShelf : MonoBehaviour,IShelf
{
    List<FruitSlot> fruitSlot = new List<FruitSlot>();
    int fruitAvailable = 0;
    [SerializeField] FruitSlotSpawner spawner;

    [SerializeField] WaitingSlot[] waitingSlots = new WaitingSlot[4];

    private void Start()
    {
        fruitSlot = spawner.CreateGrid();
    }
    public void GetAFruit()
    {
        fruitAvailable--;
        ShowFruit();
    }

    public void StoreFruit(int number)
    {
        fruitAvailable += number;
        ShowFruit();
    }

    public void SortFruit()
    {

    }
    private void ShowFruit()
    {
        foreach (var slot in fruitSlot)
        {
            slot.Deactive();
        }
        for (int i = 0; i<fruitAvailable; i++)
        {
            fruitSlot[i].Active();
        }
    }

    public bool IsFullCustommer()
    {
        foreach(var slot in waitingSlots)
        {
            if (slot.IsAvailable()) return false;
        }
        return true;
    }

    public WaitingSlot GetWaitingSlot()
    {
        for(int i = 0;i < waitingSlots.Length;i++)
        {
            if (waitingSlots[i].IsAvailable())
            {
                return waitingSlots[i];
            }
        }
        return null;
    }

    public bool IsEmpty()
    {
        return fruitAvailable <= 0;
    }
}
