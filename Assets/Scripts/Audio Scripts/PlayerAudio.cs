using System.Collections;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip walkingSound;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode Jump = KeyCode.Space;


    private void Start()
    {
        audioSource.loop = false;
        audioSource.clip = walkingSound;
    }
    private void Update()
    {
        if (Input.GetKey(right) || Input.GetKey(left))
        {           
            audioSource.loop = true;
            audioSource.Play();
        }
       if (Input.GetKey(right))
        {

        }

    }
}
