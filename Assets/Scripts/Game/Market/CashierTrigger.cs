using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierTrigger : MonoBehaviour
{
    [SerializeField] CashierTable table;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            table.ToggleCashier(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            table.ToggleCashier(false);
        }
    }
}
