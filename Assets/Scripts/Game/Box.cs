using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject[] fruits = new GameObject[4];
    internal void PlaceFruit(int number)
    {
        this.gameObject.SetActive(true);

        foreach (var fruit in fruits)
        {
            fruit.gameObject.SetActive(false);
        }

        for(int i = 0; i < number; i++)
        {
            fruits[i].gameObject.SetActive(true);
        }
    }
    public void Hide()
    {
        foreach (var fruit in fruits)
        {
            fruit.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
