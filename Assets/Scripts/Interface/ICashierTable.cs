public interface ICashierTable
{
    public void TakeFruitToBox();

    public void ShowMoney(int amount);
    public WaitingSlot GetWaitingSlot(Customer customer);
    public bool IsFullCustommer();
}
