using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IStaff
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] CharacterAnimator characterAnimator;
    [SerializeField] Joystick joystick;

    [SerializeField] int carryingFruit = 0;

    [SerializeField] PlayerFruitCarrier carrier;

    private void Update()
    {
        characterAnimator.SetDirection(new Vector3(joystick.Horizontal , 0 , joystick.Vertical).normalized);
    }

    public void PurchaseTree()
    {
        throw new System.NotImplementedException();
    }

    public void PurchaseShelf()
    {
        throw new System.NotImplementedException();
    }

    public void GatherFruitFromTree(ITree tree)
    {
        if (carryingFruit >= 3) return;

        if(tree.IsEmpty()) return;

        tree.HarvestFruit();
        carryingFruit++;

        carrier.Active(carryingFruit);

        characterAnimator.SetEmty(carryingFruit==0);
    }

    public void PutFruitOnShelf(IShelf shelf)
    {
        shelf.StoreFruit(carryingFruit);
        characterAnimator.SetEmty(carryingFruit==0);

        carryingFruit=0;
        carrier.Deactive();
    }

    public void PackTheBoxOnTable(ICashierTable table)
    {
        throw new System.NotImplementedException();
    }

    public void CollectMoneyOnTable(ICashierTable table)
    {

    }
}
