using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public GameObject popUpObject; // Assign the pop-up object in the Unity Editor

    // Function to toggle the pop-up object's visibility
    public void TogglePopUp()
    {
        // Toggle the active state of the pop-up object
        if (popUpObject != null)
        {
            popUpObject.SetActive(!popUpObject.activeSelf);
        }
    }


}
