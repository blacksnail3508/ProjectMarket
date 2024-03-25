using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] FruitShelf shelf;
    [SerializeField] CashierTable table;
    [SerializeField] CustommerSpawner spawner;
    float timer = 0;

    private void Update()
    {
        if (!shelf.IsFullCustommer())
        {
            if (timer <=0)
            {
                var newCustomer = spawner.SpawnCustomer();
                newCustomer.GetMarketFurniture(shelf, table);

                newCustomer.gameObject.SetActive(true);
                newCustomer.HideCart();
                newCustomer.RandomTarget();
                newCustomer.GoToFruitShelf();
                timer = gameConfig.CustomerSpawnDelay;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
