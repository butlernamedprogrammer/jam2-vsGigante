using UnityEngine;

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
    Animator firstAnim;
    [SerializeField]
    Animator secondAnim;
    [SerializeField]
    bool change;
    public bool die;
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
        die = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (maxHealth - currentHealth == healthLossBeforeChange)
        {
            change = true;
        }
        if (currentHealth <= 0)
        {
            die = true;
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
        anim = secondAnim;
    }


}
