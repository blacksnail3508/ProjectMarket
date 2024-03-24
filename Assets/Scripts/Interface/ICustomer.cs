using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomer
{
    public void EnterMarket();
    public void GoToFruitShelf(Transform shelf);
    public void AddFruitToCart(IFruit fruit);
    public void GoToCashierTable(CashierTable table);
    public void PutMoneyOnTable(CashierTable table, float amount);
    public void BringFruitBox();
    public void GoHome();
}
