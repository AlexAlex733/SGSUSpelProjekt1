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
        }
    }

    
    
       
    

    public void Ondie ()
    {
        SceneManager.LoadScene("Deathscene");
        Debug.Log("Player has died.");
    }
    
}
