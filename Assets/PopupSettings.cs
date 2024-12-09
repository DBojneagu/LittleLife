using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSettings : MonoBehaviour
{
    public GameObject popupPanel;


    void Start()
    {
        // Deactivate the popup panel on start
        popupPanel.SetActive(false);
    }

    public void TogglePopup()
    {
        popupPanel.SetActive(!popupPanel.activeSelf);

    }
}


