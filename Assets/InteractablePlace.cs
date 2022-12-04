using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class InteractablePlace : MonoBehaviour
{
    public CanvasScript canvas;
    public InteractiveObject thisObj;
    public List<string> interactiveText;
    InteractiveTrigger thisInteractiveTrigger;
    public int currentIndex;
    public void Interact(TMP_Text text)
    {
        if(!isShowingText)
            StartCoroutine(Text(text));
    }

    bool isShowingText;
    IEnumerator Text(TMP_Text text)
    {
        canvas.Pause(true);

        print("aqui entrou" + isShowingText);
        print(currentIndex);
        //ver essa linha
        if (currentIndex >= interactiveText.Count)
        {
            ResetInteractiveObject();
            yield break;
        }

        isShowingText = true;
        text.gameObject.SetActive(true);

        string phrase = interactiveText[currentIndex];

        var textString = new StringBuilder();
        for (int i = 0; i < phrase.Length; i++)
        {
            textString.Insert(i, phrase[i].ToString());
            text.text = textString.ToString();
            yield return new WaitForSecondsRealtime(0.01f);
        }
        currentIndex += 1;
        isShowingText = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractiveTrigger>())
        {
            thisInteractiveTrigger = other.GetComponent<InteractiveTrigger>();
            thisInteractiveTrigger.SetPlayerInteractable(this);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<InteractiveTrigger>())
        {
            thisInteractiveTrigger = other.GetComponent<InteractiveTrigger>();
            thisInteractiveTrigger.SetPlayerInteractable(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractiveTrigger>())
        {
            thisInteractiveTrigger = other.GetComponent<InteractiveTrigger>();

            ResetInteractiveObject();
        }
    }

    public void ResetInteractiveObject()
    {
        canvas.Pause(false);
        currentIndex = 0;
        thisInteractiveTrigger.SetPlayerInteractable(null);
        canvas.description.gameObject.SetActive(false);
        thisInteractiveTrigger = null;
    }
}
