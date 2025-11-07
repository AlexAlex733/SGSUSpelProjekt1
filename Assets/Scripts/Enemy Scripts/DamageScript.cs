using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         PlayerHP playerHP = collision.gameObject.GetComponent<PlayerHP>();
            if (playerHP != null)
            {
                playerHP.playerHP -= damage;
                Debug.Log("Player took " + damage + " damage. Current HP: " + playerHP.playerHP);
                
            }

        }
    }
}
