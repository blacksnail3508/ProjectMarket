public interface IStaff
{
    public void PurchaseTree();
    public void PurchaseShelf();
    public void GatherFruitFromTree(ITree tree);
    public void PutFruitOnShelf(IShelf shelf);
    public void PackTheBoxOnTable(ICashierTable table);
    public void CollectMoneyOnTable(ICashierTable table);

}
