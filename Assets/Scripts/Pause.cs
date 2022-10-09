using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    private float pauseTimeScale;
    public bool isOnPause;
    float normalTimeScale;
    public GameObject pauseScreen;
    void Start()
    {
        normalTimeScale = Time.timeScale;
        pauseTimeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = isOnPause? normalTimeScale : pauseTimeScale;
            isOnPause = !isOnPause;
            pauseScreen.SetActive(isOnPause);
        }
    }  
}