using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectionScript : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;

    public void SetAllButtonsInteractable()
    {
        //Debug.Log(buttons.Length);
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void OnButtonClicked(Button clickedButton)
    {
        //Debug.Log(clickedButton.name);
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if (buttonIndex == -1)
            return;

        SetAllButtonsInteractable();

        clickedButton.interactable = false;
    }
}
