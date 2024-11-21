using UnityEngine;
using UnityEngine.UI;

public class VRPopupManager : MonoBehaviour
{
    public GameObject wingPanel, enginePanel, enginePanel2, cockpitPanel, frontTirePanel, backWingsPanel; // Assign panels in Inspector
    private GameObject activePanel = null; // Track which panel is currently active
    private float lastClickTime = 0f;
    private const float doubleClickThreshold = 0.3f;

    // Show the popup based on the part name
    public void ShowPopup(string partName)
    {
        HideActivePopup(); // Hide any currently active popup first

        switch (partName)
        {
            case "Wing":
                activePanel = wingPanel;
                break;
            case "Engine":
                activePanel = enginePanel;
                break;
            case "Engine2": // Or "Engine2", if that's the naming convention
                activePanel = enginePanel2;
                break;
            case "Cockpit":
                activePanel = cockpitPanel;
                break;
            case "Front_Tire":
                activePanel = frontTirePanel;
                break;
            case "Back_Wings":
                activePanel = backWingsPanel;
                break;
        }

        if (activePanel != null)
        {
            activePanel.SetActive(true); // Show the appropriate popup
        }
    }

    // Hide currently active popup on double-click
    public void HandleDoubleClick()
    {
        if (Time.time - lastClickTime < doubleClickThreshold)
        {
            HideActivePopup();
        }
        lastClickTime = Time.time;
    }

    private void HideActivePopup()
    {
        if (activePanel != null)
        {
            activePanel.SetActive(false);
            activePanel = null;
        }
    }
}
