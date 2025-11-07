using UnityEngine;

public class BackroundFollow : MonoBehaviour
{
    public Transform player; // Referens till vår player - Rasmus
    public float smoothSpeed = 5f; // Hastigheten som kameran följer spelaren - Rasmus

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z); // Hitta players postion men inte y - Rasmus
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); // Följ efter önskad hastighet - Rasmus
        
    }
}
