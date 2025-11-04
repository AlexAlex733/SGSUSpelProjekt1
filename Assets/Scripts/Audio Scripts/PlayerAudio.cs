using System.Collections;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip walkingSound;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode Jump = KeyCode.Space;
    [SerializeField] bool isMoving;
    [SerializeField] bool canPlaySound;


    private void Start()
    {
        isMoving = false;
        audioSource.clip = walkingSound;
        audioSource.loop = true;
        audioSource.PlayOneShot(walkingSound);
        audioSource.Pause();
        
    }
    private void Update()
    {
        if (Input.GetKey(right) || Input.GetKey(left))
        {           
            isMoving = true;
        }
       else if (!Input.GetKeyUp(right) && !Input.GetKeyUp(left))
        {
            isMoving= false;
        }
       if (isMoving || canPlaySound)
        {
          canPlaySound = false;
          StartCoroutine(WalkingSoundCooldown());
         
        }
       else if (!isMoving)
        {
            audioSource.Pause();
        }

        IEnumerator WalkingSoundCooldown()
        {
            yield return new WaitForSeconds(0.7f);
            audioSource.PlayOneShot(walkingSound);
            canPlaySound = true;

        }
    }
}
