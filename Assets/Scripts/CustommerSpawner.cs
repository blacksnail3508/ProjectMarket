using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustommerSpawner : MonoBehaviour
{
    [SerializeField] Customer prefab;
    [SerializeField] Transform customerRoot;
    List<Customer> pool = new List<Customer>();

    public Customer SpawnCustomer()
    {
        foreach(var customer in pool)
        {
            if (!customer.gameObject.activeSelf)
            {
                return customer;
            }
        }

        var newCustomer = Instantiate(prefab, this.transform.position, Quaternion.identity,customerRoot);
        pool.Add(newCustomer);

        return newCustomer;
    }
}
