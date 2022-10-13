using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    AudioSource audioSrc;
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    int currentClip;
    public bool playOneshot;
    // Start is called before the first frame update
    void Start()
    {
        playOneshot = false;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {  

    }
    
    public void ChangeCurrentClip(int nextClip)
    {
        currentClip = nextClip;
    }
    public void PlayCurrentClipOneShot()
    {
        audioSrc.PlayOneShot(clips[currentClip]);
    }
}
