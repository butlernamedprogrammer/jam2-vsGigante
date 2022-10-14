using UnityEngine.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField]
    int maxHealth;
    [SerializeField]
    float healthLossBeforeChange;
    [SerializeField]
    GameObject attackCtrl;
    [SerializeField]
    Hitbox hitbox;
    [SerializeField]
    RuntimeAnimatorController firstAnim;
    [SerializeField]
    RuntimeAnimatorController secondAnim;
    [SerializeField]
    AudioSFX sfx;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]

    bool change;
    [SerializeField]
    GameObject victoryScreen;

    public bool dead;
    private int currentHealth;
    private Animator anim;

    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        isActive = false;
        change = false;
        dead = false;
        anim.runtimeAnimatorController = (RuntimeAnimatorController)firstAnim;
    }

    // Update is called once per frame
    public void Update()
    {
        if (maxHealth - currentHealth == healthLossBeforeChange && change == false)
        {
            change = true;
            anim.SetBool("Dead", true);
        }
        if (currentHealth <= 0)
        {
            dead = true;
            anim.SetBool("Dead", true);
        }
    }

    public void FixedUpdate()
    {
    }


    public void Activate()
    {
        isActive = true;
        attackCtrl.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            currentHealth -= 1;
        }
    }

    public void ChangeAnimator()
    {
        anim.runtimeAnimatorController = (RuntimeAnimatorController)secondAnim;
    }

    public void PlayAudio()
    {
        sfx.PlayCurrentClipOneShot();
    }

    public void SwitchPlayerMovement()
    {
        player.enabled = !player.enabled;
    }

    public void ActivateVictoryScreen()
    {
        victoryScreen.SetActive(!victoryScreen.activeSelf);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
