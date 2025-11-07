using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public int playerHP;
    public int playerMaxHP;
   

    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;
  
    void Start()
    {
        playerHP = playerMaxHP;
    }
    void Update()
    {

        // Hanterar hjärtan baserat på spelarens HP - Alexander
        if (playerHP >= 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (playerHP == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);

        }
        else if (playerHP == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (playerHP <= 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            Ondie();
        }
    }

    
    
       
    

    public void Ondie () // när spelarens HP är 0 så skicas dem till Deathscene - Rasmus
    {

        SceneManager.LoadScene("Deathscene");

        
     

    }
    
}
