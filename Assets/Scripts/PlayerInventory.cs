using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int lineCount;
    [SerializeField] int columnCount;

    [SerializeField] List<Image> itemsImages;

    private InteractiveObject[,] matrix;

    private InteractiveObject objectTeste;

    [SerializeField] InteractablePlace interactablePlace;

    [SerializeField] CanvasScript canvas;

    void Start()
    {
        matrix = new InteractiveObject[lineCount, columnCount];
        AttInventory();
    }
    void AttInventory()
    {
        int index = 0;
        for (int i = 0; i < lineCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if (matrix[i, j] != null)
                {
                    itemsImages[index].sprite = matrix[i, j].ObjectImage;
                }
                index += 1;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddObject();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    public void SetInteractablePlacement(InteractablePlace interactivePlace)
    {
        interactablePlace = interactivePlace;
    }
    

    bool IsInventoryEmpty()
    {
        for (int i = 0; i < lineCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if (matrix[i, j] == null)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void AddObject()
    {
        for (int i = 0; i < lineCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if (matrix[i, j] == null)
                {
                    matrix[i, j] = objectTeste;
                    matrix[i, j].SetPosition(new Vector2Int(i, j));
                    AttInventory();
                    return;
                }
            }
        }
    }
    public void RemoveObject(Vector2Int pos)
    {
        if (matrix[pos.x, pos.y] != null)
        {
            matrix[pos.x, pos.y].ResetPosition();
            matrix[pos.x, pos.y] = null;
        }
    }

    

    void InteractWithObject()
    {
        if (interactablePlace != null)
        {
            if (interactablePlace.currentIndex <= interactablePlace.interactiveText.Count)
            {
                interactablePlace.Interact(canvas.description);
            }
            else
            {
                interactablePlace.ResetInteractiveObject();
                canvas.Pause(false);
            }
        }
        else
        {
            canvas.Pause(false);
        }
    }
}
