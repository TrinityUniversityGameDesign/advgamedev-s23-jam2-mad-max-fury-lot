
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip clickSound;
    //public AudioClip gameMusic;
    //public AudioClip endMusic;

    private AudioSource aud;
    //private Globals global;

    // Start is called before the first frame update
    void Start()
    {
        //global = GameObject.FindObjectOfType<Globals>();
        //global.onStart.AddListener(SwitchToGameMusic);
        //global.onSundown.AddListener(SwitchToEndMusic);
        //global.onExplode.AddListener(SwitchToEndMusic);

        aud = GetComponent<AudioSource>();
        aud.loop = true;
        aud.clip = menuMusic;
        aud.Play();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayClickSound();
        }
    }

    private void PlayClickSound()
    {
        aud.PlayOneShot(clickSound);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Primary");
    }

    //void SwitchToGameMusic()
    //{
    //    aud.clip = gameMusic;
    //    aud.Play();
    //}

    //void SwitchToEndMusic()
    //{
    //    aud.clip = endMusic;
    //    aud.Play();
    //}


}