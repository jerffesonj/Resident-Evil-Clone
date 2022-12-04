using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTrigger : MonoBehaviour
{
    PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GetComponentInParent<PlayerInventory>();
    }
    public void SetPlayerInteractable(InteractablePlace interactable)
    {
        playerInventory.SetInteractablePlacement(interactable);
    }
}
