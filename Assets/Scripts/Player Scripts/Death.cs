using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform RespawnPoint;
    public Transform SpawnPoint;
    public int playerHP;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
          
           transform.position = RespawnPoint.position;
            Debug.Log("Player has taken damage and respawned.");


        }

       




    }

