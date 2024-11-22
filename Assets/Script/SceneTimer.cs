
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class SceneTimer : MonoBehaviour
{
    [SerializeField] private float delayTime = 140f; // Time (in seconds) before changing the scene
    [SerializeField] private string nextSceneName = "End"; // Name of the next scene

    void Start()
    {
        // Start the timer to change the scene
        Invoke(nameof(ChangeScene), delayTime);
    }

    private void ChangeScene()
    {
        // Load the next scene
        Debug.Log("Time's up! Changing scene to " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
