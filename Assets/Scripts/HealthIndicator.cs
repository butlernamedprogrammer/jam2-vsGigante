using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public SpriteRenderer[] hearts;
    [SerializeField]
    public PlayerMovement player;

    private void Start()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        float playerHealth = player.GetHealth();

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
