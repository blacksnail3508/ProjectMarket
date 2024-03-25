using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierTrigger : MonoBehaviour
{
    [SerializeField] CashierTable table;
    Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void Update()
    {
        if(player != null)
        {
            table.TakeFruitToBox();

        }

        table.TakeMoneyToTable();
    }
}
