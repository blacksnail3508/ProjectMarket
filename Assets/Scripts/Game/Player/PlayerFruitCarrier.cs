using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerFruitCarrier : MonoBehaviour
{
    [SerializeField] GameObject[] fruits;
    public void Active(int count)
    {
        foreach (var fruit in fruits)
        {
            fruit.SetActive(false);
        }

        for (int i = 0; i < count; i++)
        {
            fruits[i].SetActive(true);
        }
    }
    public void Deactive()
    {
        foreach (var fruit in fruits)
        {
            fruit.SetActive(false);
        }
    }
}
