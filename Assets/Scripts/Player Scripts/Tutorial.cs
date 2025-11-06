using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
                popUps[i].SetActive(true); // Activate the current pop-up
            }
            else
            {
                print("av" + i);
                popUps[i].SetActive(false); // Deactivate other pop-ups
            }
        }   
        if (popUpIndex == 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                popUpIndex++;
            }
        } 
        else if (popUpIndex == 1)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                popUpIndex++;
            }
                
        }
        
    }  
}
