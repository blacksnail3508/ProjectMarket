using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour, IFruit
{
    Transform transformCache;

    private void Awake()
    {
        transformCache = GetComponent<Transform>();
    }
    public void MoveToPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetParent(Transform newParent)
    {
        transform.parent = newParent;
    }

    public void SetToSlot(GameObject slot)
    {
        SetParent(slot.transform);
        transform.localScale=Vector3.zero;
    }
    public void SpawnAndGrowUp()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transformCache.DOScale(Vector3.one , 0.05f);
    }
}
