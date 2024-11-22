using UnityEngine;
using UnityEngine.XR;

public class VRRaycastInteraction : MonoBehaviour
{
    public LayerMask interactableLayer; // Assign the layer for your spheres
    public GameObject rightController; // Drag and drop the Right Controller GameObject here
    public GameObject leftController;  // Drag and drop the Left Controller GameObject here

    private InputDevice rightInputDevice;
    private InputDevice leftInputDevice;

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
            }
        }
    }
}
