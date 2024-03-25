public interface ICustomer
{
    public void GetMarketFurniture(FruitShelf shelf , CashierTable cashierTable);
    public void GoToFruitShelf();
    public void AddFruitToCart();
    public void GoToCashierTable();
    public void PutMoneyOnTable(CashierTable table , float amount);
    public void BringFruitBox();
    public void GoHome();
    public void ReturnPool();
    public void RandomTarget();
}
public enum CustomerState
{
    MovementPhase = 0,
    PickingFruitPhase = 1,
    PaymentPhase = 2,
    GoHomePase = 3,
}
