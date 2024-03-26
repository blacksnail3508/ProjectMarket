using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] Money moneyPrefab;
    [SerializeField] float spacing;
    List<Money> listMoney = new List<Money>();

    int spawnedMoney = 0;
    void SpawnNewMoney()
    {
        var newMoney = Instantiate(moneyPrefab, this.transform);
        newMoney.transform.localPosition = new Vector3 (spawnedMoney%5,(spawnedMoney/25)/3f,(spawnedMoney%25)/5)*0.2f;
        listMoney.Add(newMoney);
        spawnedMoney++;
    }
    public void ShowMoneyOnTable(int total)
    {
        foreach (Money money in listMoney)
        {
            money.gameObject.SetActive(false);
        }

        if (spawnedMoney < total)
        {
            var delta = total - spawnedMoney;
            for(int i = 0; i < delta; i++)
            {
                SpawnNewMoney();
            }
        }

        for(int i = 0;i < total;i++)
        {
            listMoney[i].gameObject.SetActive(true);
        }
    }
}
