using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Teleporter"))
        {
            SceneManager.LoadScene("Level2"); // Teleports the player to a scene named Level2
            Debug.Log("Player has teleported.");
        }
    }
}
