using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    int maxHealth;
    [SerializeField]
    GameObject attackCtrl;
    [SerializeField]
    Hitbox hitbox;
    [SerializeField]
    Animator firstAnim;
    [SerializeField]
    Animator secondAnim;
    private int currentHealth;

    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        isActive = false;
    }

    // Update is called once per frame
    public void Update()
    {
        
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

}
