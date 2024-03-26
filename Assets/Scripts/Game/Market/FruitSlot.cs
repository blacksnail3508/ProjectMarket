using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSlot : MonoBehaviour
{
    [SerializeField] GameObject containingFruit;
    public void Active()
    {
        containingFruit.SetActive(true);
    }
    public void Deactive()
    {
        containingFruit.SetActive(false);
    }
}
