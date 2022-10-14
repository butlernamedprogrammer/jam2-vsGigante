using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    private float pauseTimeScale;
    public bool isOnPause;
    float normalTimeScale;
    public GameObject pauseScreen;
    public PlayerMovement player;
    void Start()
    {
        normalTimeScale = Time.timeScale;
        pauseTimeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckPause(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
            isOnPause = !isOnPause;
            Time.timeScale = isOnPause ? normalTimeScale:pauseTimeScale;
        pauseScreen.SetActive(!isOnPause);
        if (isOnPause)
        {
            player.enabled = false;
        }
        else
        {
            player.enabled = true;
        }
    }
}