using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform RespawnPoint;
    public Transform SpawnPoint;
   

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // kollar om vi kolliderar med ett object som har taggen "Enemy"
        {

            transform.position = RespawnPoint.position; // sätter spelarens position till RespawnPoint positionen
            Debug.Log("Player has taken damage and respawned.");





        }
    }
    public void OnDie ()
    {
        transform.position = SpawnPoint.position; // sätter spelarens position till SpawnPoint positionen
        Debug.Log("Player has died and respawned at the starting point.");
    }
}