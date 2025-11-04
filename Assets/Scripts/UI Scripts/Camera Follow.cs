using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referens till vår player
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Standard offset för 2D games
    public float smoothSpeed = 5f; // Hastigheten som kameran följer spelaren

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset; // Hitta players postion men addera offset
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); // Följ efter önskad hastighet
    }
}

