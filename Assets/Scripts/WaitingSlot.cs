using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingSlot : MonoBehaviour
{
    Transform transformCache;
    private void Awake()
    {
        transformCache = GetComponent<Transform>();
    }
    [SerializeField] bool isAvailable = true;
    public bool IsAvailable()
    {
        return isAvailable;
    }

    public void Clear()
    {
        isAvailable = true;
    }
    public void Asign()
    {
        isAvailable = false;
    }
    public Vector3 GetPosition()
    {
        return transformCache.position;
    }
}
