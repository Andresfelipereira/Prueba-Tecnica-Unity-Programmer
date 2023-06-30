using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public TextMeshProUGUI controllerMessage;

    private void Start()
    {
        controllerMessage.gameObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        SetActiveControllerMessage(true);
        controllerMessage.text = message;
    }

    public void SetActiveControllerMessage(bool setActive)
    {
        controllerMessage.gameObject.SetActive(setActive);
    }

}
