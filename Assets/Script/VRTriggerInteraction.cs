using UnityEngine;

public class VRTriggerInteraction : MonoBehaviour
{
    public string partName; // Assign the part name in the Inspector
    private VRPopupManager popupManager;

    void Start()
    {
        popupManager = FindObjectOfType<VRPopupManager>();
        if (popupManager == null)
        {
            Debug.LogError("VRPopupManager not found in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand")) // Customize based on Oculus interaction setup
        {
            popupManager.ShowPopup(partName);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) // Detect Oculus controller trigger
        {
            popupManager.HandleDoubleClick();
        }
    }
}
