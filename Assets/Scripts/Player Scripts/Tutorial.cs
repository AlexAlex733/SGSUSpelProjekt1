
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps; // Array to store pop-up GameObjects
    private int popUpIndex;

     void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                print("på" + i);
                popUps[i].SetActive(true); // activera popups
            }
            else
            {
                print("av" + i);
                popUps[i].SetActive(false); // stänger av popups
            }
        }   
        if (popUpIndex == 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) // om duy trycker på A eller D så går vi vidare till nästa popup
            {
                popUpIndex++;
            }
        } 
        else if (popUpIndex == 1) // om vi trycker på space så går vi vidare till nästa popup
        {
            if (Input.GetKey(KeyCode.Space))
            {
                popUpIndex++;
            }
                
        }
        
    }  
}
