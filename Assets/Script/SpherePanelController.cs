using UnityEngine;
using UnityEngine.XR;

public class VRRaycastInteraction : MonoBehaviour
{
    [SerializeField] GameObject enginesphere, enginepanel;
    [SerializeField] GameObject enginesphere2, enginepanel2;
    [SerializeField] GameObject wingss, wingsp;
    [SerializeField] GameObject cockpits, cockpitp;
    [SerializeField] GameObject fronts, frontp;
    [SerializeField] GameObject backs, backp;

    [SerializeField] private GameObject leftControllerVisual;  // Assign Left Controller Visual
    [SerializeField] private GameObject rightControllerVisual; // Assign Right Controller Visual

    public LayerMask interactableLayer;
    public GameObject rightController; // Drag and drop the Right Controller GameObject here
    public GameObject leftController;  // Drag and drop the Left Controller GameObject here

    private InputDevice rightInputDevice;
    private InputDevice leftInputDevice;

    private float popupDuration = 20f; // Duration for which the popup remains active

    void Start()
    {
        // Get input devices for the left and right controllers
        rightInputDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        leftInputDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    void Update()
    {
        // Check for right controller input
        if (rightInputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool isRightTriggerPressed) && isRightTriggerPressed)
        {
            PerformRaycast(rightController.transform); // Pass the transform of the right controller
        }

        // Check for left controller input
        if (leftInputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool isLeftTriggerPressed) && isLeftTriggerPressed)
        {
            PerformRaycast(leftController.transform); // Pass the transform of the left controller
        }
    }

    void PerformRaycast(Transform controllerTransform)
    {
        // Get the position and direction of the ray from the controller
        Ray ray = new Ray(controllerTransform.position, controllerTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
        {
            GameObject hitObject = hit.collider.gameObject;

            // Check for a Canvas or Panel child
            Transform canvasTransform = hitObject.transform.Find("Canvas");
            if (canvasTransform != null)
            {
                // Activate the panel and disable the sphere
                hitObject.SetActive(false);
                canvasTransform.gameObject.SetActive(true);

                // Temporarily hide the controllers
                leftControllerVisual.SetActive(false);
                rightControllerVisual.SetActive(false);

                // Schedule the panel to disappear and re-enable controllers
                StartCoroutine(HidePopupAndReactivateControllers(canvasTransform.gameObject));
            }
        }
    }

    private System.Collections.IEnumerator HidePopupAndReactivateControllers(GameObject popup)
    {
        // Wait for the duration of the popup
        yield return new WaitForSeconds(popupDuration);

        // Hide the popup
        popup.SetActive(false);

        // Reactivate the controllers
        leftControllerVisual.SetActive(true);
        rightControllerVisual.SetActive(true);
    }

    // Individual popup functions
    public void onhowerengine()
    {
        enginesphere.SetActive(false);
        enginepanel.SetActive(true);

        // Temporarily hide the controllers
        leftControllerVisual.SetActive(false);
        rightControllerVisual.SetActive(false);

        // Schedule to hide the popup and reactivate controllers
        StartCoroutine(HidePopupAndReactivateControllers(enginepanel));
    }

    public void onhowerengine2()
    {
        enginesphere2.SetActive(false);
        enginepanel2.SetActive(true);

        // Temporarily hide the controllers
        leftControllerVisual.SetActive(false);
        rightControllerVisual.SetActive(false);

        StartCoroutine(HidePopupAndReactivateControllers(enginepanel2));
    }

    public void wings()
    {
        wingss.SetActive(false);
        wingsp.SetActive(true);

        // Temporarily hide the controllers
        leftControllerVisual.SetActive(false);
        rightControllerVisual.SetActive(false);

        StartCoroutine(HidePopupAndReactivateControllers(wingsp));
    }

    public void cockpit()
    {
        cockpits.SetActive(false);
        cockpitp.SetActive(true);

        // Temporarily hide the controllers
        leftControllerVisual.SetActive(false);
        rightControllerVisual.SetActive(false);

        StartCoroutine(HidePopupAndReactivateControllers(cockpitp));
    }

    public void front_tire()
    {
        fronts.SetActive(false);
        frontp.SetActive(true);

        // Temporarily hide the controllers
        leftControllerVisual.SetActive(false);
        rightControllerVisual.SetActive(false);

        StartCoroutine(HidePopupAndReactivateControllers(frontp));
    }

    public void back_wings()
    {
        backs.SetActive(false);
        backp.SetActive(true);

        // Temporarily hide the controllers
        leftControllerVisual.SetActive(false);
        rightControllerVisual.SetActive(false);

        StartCoroutine(HidePopupAndReactivateControllers(backp));
    }
}
