using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoTree : MonoBehaviour, ITree
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] Tomato fruit1;
    [SerializeField] Tomato fruit2;
    [SerializeField] Tomato fruit3;

    [SerializeField] int fruitAvailable = 0;

    float timer;
    private void Start()
    {
        timer = gameConfig.FruitSpawnTime;
    }
    private void Update()
    {
        SpawnFruit();
    }

    public void HarvestFruit()
    {
        if (fruit1.gameObject.activeSelf)
        {
            fruitAvailable--;
            fruit1.gameObject.SetActive(false);
            return;
        }
        if (fruit2.gameObject.activeSelf)
        {
            fruitAvailable--;
            fruit2.gameObject.SetActive(false);
            return;
        }
        if (fruit3.gameObject.activeSelf)
        {
            fruitAvailable--;
            fruit3.gameObject.SetActive(false);
            return;
        }
    }

    public bool IsEmpty()
    {
        return fruitAvailable == 0;
    }

    public void SpawnFruit()
    {

        if(fruitAvailable < 3)
        {
            timer-=Time.deltaTime;
            if(timer <=0)
            {
                if(fruit1.gameObject.activeSelf == false)
                {
                    fruit1.SpawnAndGrowUp();
                    timer=gameConfig.FruitSpawnTime;
                    fruitAvailable++;
                    return;
                }
                if (fruit2.gameObject.activeSelf == false)
                {
                    fruit2.SpawnAndGrowUp();
                    timer=gameConfig.FruitSpawnTime;
                    fruitAvailable++;
                    return;
                }
                if (fruit3.gameObject.activeSelf == false)
                {
                    fruit3.SpawnAndGrowUp();
                    timer=gameConfig.FruitSpawnTime;
                    fruitAvailable++;
                    return;
                }
            }
        }
    }
}
