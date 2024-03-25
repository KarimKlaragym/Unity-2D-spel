using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (player != null)
        {
            inventory = player.GetComponent<Inventory>();
            if (inventory != null)
            {
                Debug.Log("Inventory component found.");
            }
            else
            {
                Debug.LogError("Inventory component not found on the Player GameObject.");
            }
        }
        else
        {
            Debug.LogError("Player GameObject not found. Ensure it has the 'Player' tag assigned.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            if (inventory == null)
            {
                Debug.LogError("Inventory component not assigned.");
                return;
            }

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    return;
                }
            }

            Debug.LogWarning("Inventory is full, item not picked up.");
        }
    }
}
