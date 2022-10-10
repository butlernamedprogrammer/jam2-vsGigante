using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    [SerializeField]
    GameObject attackCtrl;
    [SerializeField]
    Hitbox hitbox;
    Animator anim;
    private float currentHealth;

    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        TryGetComponent<Animator>(out anim);
        isActive = false;
        anim = GetComponent<Animator>();
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

    public void CheckHitbox()
    {
        if (hitbox.CheckHurt())
        {
            currentHealth -= 1f;
        }
    }
    
}
