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
        if (collision.gameObject.CompareTag("Player")) // kollar om vi kolliderar med ett object som har taggen "Player"
        {
         PlayerHP playerHP = collision.gameObject.GetComponent<PlayerHP>(); // kollar om spelaren har PlayerHP scriptet
            if (playerHP != null)
            {
                playerHP.playerHP -= damage; // om det är sant så tar spelaren skada
                Debug.Log("Player took " + damage + " damage. Current HP: " + playerHP.playerHP);
                
            }

        }
    }
}
