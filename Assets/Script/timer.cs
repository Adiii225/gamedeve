using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For UI elements

public class timer : MonoBehaviour
{
    [SerializeField] private float delayTime = 140f; // Time before scene transition
    [SerializeField] private string nextSceneName = "Airport"; // Name of the next scene
    [SerializeField] private Text countdownText; // Text UI element to display the countdown

    private float remainingTime;

    void Start()
    {
        // Initialize the remaining time
        remainingTime = delayTime;

        // Start the countdown
        StartCoroutine(CountdownTimer());
    }

    private System.Collections.IEnumerator CountdownTimer()
    {
        // Update the countdown each second
        while (remainingTime > 0)
        {
            // Update the countdown text
            if (countdownText != null)
            {
                countdownText.text = "Time Remaining: " + Mathf.CeilToInt(remainingTime) + " seconds";
            }

            // Wait for one second
            yield return new WaitForSeconds(1f);

            // Decrease the remaining time
            remainingTime--;
        }

        // When the timer ends, change the scene
        ChangeScene();
    }

    private void ChangeScene()
    {
        // Load the next scene
        Debug.Log("Time's up! Changing scene to " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
