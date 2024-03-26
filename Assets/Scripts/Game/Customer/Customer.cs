using DG.Tweening;
using System;
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
    [SerializeField] GameObject box;

    WaitingSlot waitingSlotCache;
    CustomerState state = CustomerState.MovementPhase;
    FruitShelf shelfCache;
    CashierTable cashierTableCache;
    int cart = 0;
    int targetFruit = 3;
    Vector3 initPosition;
    private void Awake()
    {
        initPosition=transform.position;
    }
    private void Update()
    {
        if (state==CustomerState.MovementPhase)
        {

        }

        if (state==CustomerState.PickingFruitPhase)
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
        waitingSlotCache.Asign();

        Action onArrived = () =>
        {
            //change animation
            animator.PlayIdle();

            //facing to shelf
            var direction = shelfCache.transform.position-transform.position;
            animator.SetDirection(direction);

            //change state
            state=CustomerState.PickingFruitPhase;
        };
        MoveTo(waitingSlotCache.GetPosition() , onArrived);
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
        if (cart>=targetFruit)
        {
            //change to next phase
            state=CustomerState.MovementPhase;
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
        box.gameObject.SetActive(true);
        animator.PlayCarry();
    }
    public void GoHome()
    {
        waitingSlotCache.Clear();
        BringFruitBox();

        Action onArrived = () =>
        {
            ReturnPool();
        };
        MoveTo(initPosition , onArrived);
    }

    public void GoToCashierTable()
    {
        if (waitingSlotCache!=null) waitingSlotCache.Clear();
        waitingSlotCache=cashierTableCache.GetWaitingSlot();

        cashierTableCache.AddCustomer(this);
        waitingSlotCache.Asign();

        Action onArrived = () =>
        {
            //change animation
            animator.PlayIdle();

            //facing to shelf
            var direction = cashierTableCache.transform.position-transform.position;
            animator.SetDirection(direction);

            //change state
            state=CustomerState.PaymentPhase;
            customerTarget.Hide();
        };

        MoveTo(waitingSlotCache.GetPosition() , onArrived);
    }
    private void MoveTo(Vector3 targetPos , Action onArrived)
    {
        //calculate direction and move time
        var direction = targetPos-transform.position;
        var distance = direction.magnitude;
        var velocity = gameConfig.CharacterMovementSpeed;
        var time = distance/velocity;

        animator.SetDirection(direction);
        animator.PlayMove();
        transform.DOMove(targetPos , time).SetEase(Ease.Linear).OnComplete(() =>
        {
            onArrived?.Invoke();
        });
    }
    public int GetFruitInCart()
    {
        return cart;
    }
    public void ReturnPool()
    {
        box.gameObject.SetActive(false);
        transform.position=initPosition;
        cart=0;
        this.gameObject.SetActive(false);
        animator.PlayIdle();
        customerTarget.Show();
    }

    public void RandomTarget()
    {
        targetFruit=UnityEngine.Random.Range(1 , 5);
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
