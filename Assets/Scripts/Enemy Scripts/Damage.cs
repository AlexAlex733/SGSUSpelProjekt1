using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
       PlayerHP player = collision.gameObject.GetComponent<PlayerHP>();
        if (player != null)
        {
            player.TakeDamage();
            Debug.Log("Player took " + damage + " damage. Remaining HP: " + player.playerHP);
        }

    }
}
