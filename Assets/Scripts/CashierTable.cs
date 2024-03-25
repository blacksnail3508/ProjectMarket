using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierTable : MonoBehaviour, ICashierTable
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] WaitingSlot[] waitingSlots = new WaitingSlot[4];
    [SerializeField] Box box;

    Queue<Customer> customers = new Queue<Customer>();
    Customer payingCustomer;
    public void AddCustomerToQueue(Customer customer)
    {
        if(!customers.Contains(customer) )
        {
            customers.Enqueue(customer);
        }
    }
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
        payingCustomer = customers.Dequeue();
        int fruitNumber = payingCustomer.GetFruitInCart();
        payingCustomer.HideCart();
        box.PlaceFruit(fruitNumber);
        Invoke("CustomerPay" , 1.5f);
    }
    private void CustomerPay()
    {
        payingCustomer.PutMoneyOnTable(this, payingCustomer.GetFruitInCart()*gameConfig.FruitPrice);
        payingCustomer.GoHome();

        foreach (var customer in customers)
        {
            customer.GoToCashierTable();
        }
    }

    public void TakeMoneyToTable()
    {
        throw new System.NotImplementedException();
    }
}
