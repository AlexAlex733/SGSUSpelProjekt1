using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource buttonClick;
    [SerializeField] AudioClip clickSound;

    private void Start()
    {
        buttonClick.clip = clickSound;
    }
    public void PlayGame()
    {
        buttonClick.Play();
        StartCoroutine(clickWait());
       
    }

    IEnumerator clickWait()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        SceneManager.LoadSceneAsync("LowerLevel");
    }

}
