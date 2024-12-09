
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace PW
{

public class DeleteProductOnSlot : MonoBehaviour, IPointerClickHandler
{

    bool shownDeleteButton = true;
    Button deleteButton;
    [SerializeField]
    public int SlotIndex;

    private void Start()
    {
        deleteButton = GetComponentInChildren<Button>();
        
        deleteButton.onClick.AddListener(delegate
        {
            DeletePlayerSlotImage();
        });

        ToggleDeleteMode();
    }


    void ToggleDeleteMode()
    {
        shownDeleteButton = !shownDeleteButton;
        ChangeUI();
    }

    void ChangeUI()
    {
        deleteButton.gameObject.SetActive(shownDeleteButton);
    }

    public void DeletePlayerSlotImage()
    {
        ToggleDeleteMode();
        GetComponent<Image>().sprite = null;
        BasicGameEvents.RaiseOnProductDeletedFromSlot(SlotIndex);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ToggleDeleteMode();
        }
    }
}
}
