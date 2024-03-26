using System.Collections.Generic;
using UnityEngine;

public class FruitSlotSpawner : MonoBehaviour
{
    public FruitSlot prefab; // The GameObject prefab to instantiate
    public int rows = 3; // Number of rows
    public int columns = 3; // Number of columns
    public float spacing = 0.5f; // Spacing between GameObjects
    List<FruitSlot> slots = new List<FruitSlot>();

    public List<FruitSlot> CreateGrid()
    {
        int index = 0;
        for (int row = 0; row<rows; row++)
        {
            for (int col = 0; col<columns; col++)
            {
                // Calculate local position for the GameObject relative to the parent
                Vector3 localPosition = new Vector3((col-columns/2f)*spacing+0.25f , 0.6f , (row-rows/2f)*spacing+0.25f);

                // Instantiate the GameObject at the calculated local position
                FruitSlot slot = Instantiate(prefab , transform);
                slot.name=$"Slot {index}";
                slot.gameObject.SetActive(true);
                slot.transform.localPosition=localPosition;
                slots.Add(slot);
                index++;
            }
        }

        return slots;
    }
}
