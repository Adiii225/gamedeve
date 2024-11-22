using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToAirportScene()
    {
        SceneManager.LoadScene("Airport");
    }
}
