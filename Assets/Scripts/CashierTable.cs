using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierTable : MonoBehaviour, ICashierTable
{
    [SerializeField] WaitingSlot[] waitingSlots = new WaitingSlot[4];

    public WaitingSlot GetWaitingSlot()
    {
        for (int i = 0; i<waitingSlots.Length; i++)
        {
            if (waitingSlots[i].IsAvailable())
            {
                return waitingSlots[i];
            }
        }
        return null;
    }
    public bool IsFullCustommer()
    {
        foreach (var slot in waitingSlots)
        {
            if (slot.IsAvailable()) return false;
        }
        return true;
    }

    public void TakeFruitToBox()
    {
        throw new System.NotImplementedException();
    }

    public void TakeMoneyToTable()
    {
        throw new System.NotImplementedException();
    }
}
