public interface ICashierTable
{
    public void TakeFruitToBox();

    public void TakeMoneyToTable();
    public WaitingSlot GetWaitingSlot();
    public bool IsFullCustommer();
}
