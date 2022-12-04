using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{

    public Transform thisCamPosition;
    public Transform camTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camTransform.position = thisCamPosition.position;
            camTransform.rotation = thisCamPosition.rotation;
        }
    }
}
