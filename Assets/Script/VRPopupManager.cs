using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPopupManager : MonoBehaviour
{
    public GameObject popupPanel; // The panel to display when the ray touches the object

    private void OnEnable()
    {
        // Register for the XR Interaction events when the script is enabled
        var interactor = GetComponent<XRBaseInteractor>();
        if (interactor != null)
        {
            interactor.selectEntered.AddListener(OnRayEnter);
            interactor.selectExited.AddListener(OnRayExit);
        }
    }

    private void OnDisable()
    {
        // Unregister the events to prevent memory leaks
        var interactor = GetComponent<XRBaseInteractor>();
        if (interactor != null)
        {
            interactor.selectEntered.RemoveListener(OnRayEnter);
            interactor.selectExited.RemoveListener(OnRayExit);
        }
    }

    private void OnRayEnter(SelectEnterEventArgs args)
    {
        // Called when the ray touches the object
        Debug.Log($"{gameObject.name} touched by ray!");

        // Hide the sphere (this object)
        gameObject.SetActive(false);

        // Show the corresponding popup panel
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
        }
    }

    private void OnRayExit(SelectExitEventArgs args)
    {
        // Optionally hide the popup when the ray exits the object
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }
}
