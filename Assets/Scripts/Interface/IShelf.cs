using System.Collections.Generic;

public interface IShelf
{
    public void StoreFruit(int count);
    public void GetAFruit();
    public bool IsFullCustommer();
    public bool IsEmpty();
    public WaitingSlot GetWaitingSlot();
}
