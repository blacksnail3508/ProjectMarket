
using LazyFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierTable : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] MoneyLibrary moneyLibrary;

    [SerializeField] WaitingSlot[] waitingSlots = new WaitingSlot[4];
    [SerializeField] Box box;
    [SerializeField] MoneySpawner moneySpawner;

    public float processTime = 2f;

    private Queue<Customer> waitingCustomers = new Queue<Customer>();
    private bool hasCashier = false;
    int moneyOnTable = 0;

    bool isProcessing = false;
    public void AddCustomer(Customer customer)
    {
        // Add customer to the waiting queue
        waitingCustomers.Enqueue(customer);
    }

    private void Update()
    {
        if (hasCashier)
        {
            //collect money
            if (moneyOnTable>0)
            {
                CollectMoney();
            }
            //process customer
            if (waitingCustomers.Count>0&&!isProcessing)
            {
                StartCoroutine(ProcessCustomers());
                isProcessing=true;
            }
        }
    }

    public WaitingSlot GetWaitingSlot()
    {
        return waitingSlots[waitingCustomers.Count];
    }
    public bool IsFullCustommer()
    {
        if (waitingCustomers.Count>4) return true;
        return false;
    }

    IEnumerator ProcessCustomers()
    {
        yield return new WaitForSeconds(processTime);

        if (waitingCustomers.Count>0)
        {
            // Get the first customer in the queue
            Customer customer = waitingCustomers.Dequeue();

            // Process the payment
            StartCoroutine(ProcessPayment(customer));
        }
    }

    IEnumerator ProcessPayment(Customer customer)
    {
        //cache number of fruit
        int fruitCount = customer.GetFruitInCart();

        box.PlaceFruit(fruitCount);
        customer.HideCart();

        // Simulate processing time
        yield return new WaitForSeconds(processTime);
        box.Hide();
        moneyOnTable+=fruitCount*gameConfig.FruitPrice;
        ShowMoney(moneyOnTable);
        // Notify the customer that payment is complete
        customer.GoHome();
        yield return new WaitForSeconds(processTime);
        // Move customers to the next slot if available
        if (waitingCustomers.Count>0)
        {
            Customer nextCustomer = waitingCustomers.Dequeue();
            nextCustomer.GoToCashierTable();
        }
        for (int i = 0; i<waitingCustomers.Count; i++)
        {

        }
        yield return new WaitForSeconds(processTime);
        isProcessing=false;
    }

    public void ToggleCashier(bool enable)
    {
        hasCashier=enable;
    }
    public void ShowMoney(int amount)
    {
        moneySpawner.ShowMoneyOnTable(amount);
    }
    float moneyCollecttimer = 0;
    private void CollectMoney()
    {
        moneyCollecttimer-=Time.deltaTime;
        if (moneyCollecttimer<=0)
        {
            //collect 1 money
            moneyOnTable--;
            ShowMoney(moneyOnTable);

            moneyLibrary.money++;
            Event<OnMoneyEarned>.Post(new OnMoneyEarned());
            //reset timer
            moneyCollecttimer=gameConfig.MoneyCollectDelay;
        }
    }
}
