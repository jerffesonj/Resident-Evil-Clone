using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Interactive Object", order = 0)]
public class InteractiveObject : ScriptableObject
{
    [SerializeField] Sprite objectImage;
    [SerializeField] string objectName;
    public Vector2Int currentPosInInventory = new Vector2Int(-1,-1);

    public Sprite ObjectImage { get => objectImage; }

    public void ResetPosition()
    {
        currentPosInInventory = new Vector2Int(-1, -1);
    }
    public void SetPosition(Vector2Int pos)
    {
        currentPosInInventory = pos;
    }
}
