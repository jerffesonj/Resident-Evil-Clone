using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasScript : MonoBehaviour
{
    public TMP_Text description;
    public GameObject inventoryGameObject;
    public bool isPaused;

    public void Pause(bool pause)
    {
        isPaused = pause;
        print(isPaused);
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void OpenInventory()
    {
        if (inventoryGameObject.activeSelf)
        {
            inventoryGameObject.SetActive(false);
        }
        else
        {
            inventoryGameObject.SetActive(true);
        }
    }
}
