using DG.Tweening;
using UnityEngine;

public class Customer : MonoBehaviour, ICustomer
{
    [Header("Config")]
    [SerializeField] GameConfig gameConfig;
    [Header("References")]
    [SerializeField] CustomerAnimator animator;
    [SerializeField] Billboard customerTarget;
    [Header("fake fruit carrier")]
    [SerializeField] GameObject[] carts = new GameObject[4];

    WaitingSlot waitingSlotCache;
    CustomerState state = CustomerState.FindShelfPhase;
    FruitShelf shelfCache;
    CashierTable cashierTableCache;
    int cart = 0;
    int targetFruit = 3;

    private void Update()
    {
        if (state == CustomerState.FindShelfPhase)
        {

        }

        if (state == CustomerState.PickingFruitPhase)
        {
            AddFruitToCart();
        }
    }
    public void GetMarketFurniture(FruitShelf shelf , CashierTable cashierTable)
    {
        shelfCache=shelf;
        cashierTableCache=cashierTable;
    }
    public void GoToFruitShelf()
    {
        waitingSlotCache=shelfCache.GetWaitingSlot();

        //calculate direction and move time
        var targetPos = waitingSlotCache.GetPosition();
        var direction = targetPos-transform.position;
        var distance = direction.magnitude;
        var velocity = gameConfig.CharacterMovementSpeed;
        var time = distance/velocity;

        animator.SetDirection(direction);
        animator.PlayMove();
        transform.DOMove(targetPos , time).SetEase(Ease.Linear).OnComplete(() =>
        {
            //change animation
            animator.PlayIdle();

            //facing to shelf
            direction = shelfCache.transform.position-transform.position;
            animator.SetDirection(direction);

            //change state
            state = CustomerState.PickingFruitPhase;
        });

        waitingSlotCache.Asign();
    }

    public void AddFruitToCart()
    {
        //check if shelf have any fruit
        if (shelfCache.IsEmpty()) return;

        //if pick up any fruit
        animator.PlayCarry();
        shelfCache.GetAFruit();
        cart++;

        //carry fruit on hand
        ShowCart();

        //change text
        ShowTarget();

        //check if meet condition
        if (cart==targetFruit)
        {
            //change to next phase
            state=CustomerState.PaymentPhase;
            if (!cashierTableCache.IsFullCustommer())
            {
                //release position for new customer
                waitingSlotCache.Clear();
                GoToCashierTable();
            }
        }
    }

    public void BringFruitBox()
    {
        throw new System.NotImplementedException();
    }
    public void GoHome()
    {
        throw new System.NotImplementedException();
    }

    public void GoToCashierTable()
    {
        waitingSlotCache=cashierTableCache.GetWaitingSlot();

        //calculate direction and move time
        var targetPos = waitingSlotCache.GetPosition();
        var direction = targetPos-transform.position;
        var distance = direction.magnitude;
        var velocity = gameConfig.CharacterMovementSpeed;
        var time = distance/velocity;

        animator.SetDirection(direction);
        animator.PlayMove();
        transform.DOMove(targetPos , time).SetEase(Ease.Linear).OnComplete(() =>
        {
            //change animation
            animator.PlayIdle();

            //facing to shelf
            direction=cashierTableCache.transform.position-transform.position;
            animator.SetDirection(direction);

            //change state
            state=CustomerState.PickingFruitPhase;
        });

        waitingSlotCache.Asign();
    }
    public void PutMoneyOnTable(CashierTable table , float amount)
    {
        throw new System.NotImplementedException();
    }
    public void ReturnPool()
    {
        cart=0;
        this.gameObject.SetActive(false);
    }

    public void RandomTarget()
    {
        targetFruit=Random.Range(1 , 5);
        ShowTarget();
    }
    private void ShowCart()
    {
        foreach (var item in carts)
        {
            item.gameObject.SetActive(false);
        }
        for (int i = 0; i<cart; i++)
        {
            carts[i].gameObject.SetActive(true);
        }
    }

    //show fruit collected on hand
    public void HideCart()
    {
        foreach (var item in carts)
        {
            item.gameObject.SetActive(false);
        }
    }
    //show how many fruit need to buy
    private void ShowTarget()
    {
        customerTarget.SetText($"{cart}/{targetFruit}");
    }
}
