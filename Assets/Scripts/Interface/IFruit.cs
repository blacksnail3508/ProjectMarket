using UnityEngine;

public interface IFruit
{
    public void MoveToPosition(Vector3 position);
    public void SetParent(Transform newParent);
    public void SetToSlot(GameObject slot);

}
