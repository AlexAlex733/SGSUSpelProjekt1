using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform RespawnPoint;
    public Transform SpawnPoint;
   

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            transform.position = RespawnPoint.position;
            Debug.Log("Player has taken damage and respawned.");





        }
    }
    public void OnDie ()
    {
        transform.position = SpawnPoint.position;
        Debug.Log("Player has died and respawned at the starting point.");
    }
}