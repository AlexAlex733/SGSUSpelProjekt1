using UnityEngine;

public class BackroundFollow : MonoBehaviour
{
    public Transform player; // Referens till vår player
    public float smoothSpeed = 5f; // Hastigheten som kameran följer spelaren

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z); // Hitta players postion men inte y
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); // Följ efter önskad hastighet
        
    }
}
