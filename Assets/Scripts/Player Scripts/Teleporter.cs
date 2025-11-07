
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
       
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter_2")) // om spelaren kolliderar med en objekt med taggen "Teleporter_2" så skicas dem till Level2
        {
            SceneManager.LoadScene("Level2");

        }

        else if (collision.CompareTag("Teleporter_3")) // om spelaren kolliderar med en objekt med taggen "Teleporter_3" så skicas dem till Level3
        {
            SceneManager.LoadScene("Surface Level");


        
        }
        else if (collision.CompareTag("Teleporter_End"))
            {
            SceneManager.LoadScene("Ending");

        }
    }
}