using LazyFramework;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] MoneyLibrary moneyData;
    [SerializeField] TMP_Text moneyText;
    private void UpdateText()
    {
        moneyText.text=$"{moneyData.money}$";
    }
    private void OnMoneyEarned(OnMoneyEarned e)
    {
        UpdateText();
    }
    private void Awake()
    {
        Subscribe();
    }
    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Event<OnMoneyEarned>.Subscribe(OnMoneyEarned);
    }
    private void Unsubscribe()
    {
        Event<OnMoneyEarned>.Unsubscribe(OnMoneyEarned);
    }
}
