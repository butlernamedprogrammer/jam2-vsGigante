using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [Header("Screen Margins")]
    [SerializeField]
    Vector2 minScreenPos;
    [SerializeField]
    Vector2 maxScreenPos;
    [SerializeField]
    float timeBetweenAttacks;
    [SerializeField]
    GameObject smashAttack;
    [SerializeField]
    GameObject swingAttack;
    private Animator anim;
    BossAttack currentAttack;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        minScreenPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxScreenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void ToAnimator()
    {
        anim.SetInteger("CurrentAttack", currentAttack.GetAttackType());
    }
    public void GenerateAttack()
    {
        currentAttack = new BossAttack(player.transform.position, minScreenPos, maxScreenPos, smashAttack.transform.position.y, swingAttack.transform.position.x);
        switch (currentAttack.GetAttackType())
        {
            case 0:
                smashAttack.transform.position = currentAttack.GetPos();
                break;
            case 1:
                swingAttack.transform.position = currentAttack.GetPos();
                break;
            case 2:

                break;
        }
        ToAnimator();
    }
    private class BossAttack
    {
        public enum AttackType { Smash, Swing, Rain };
        AttackType at { get; set; }
        Vector2 pos { get; set; }
        Vector2 minScreenPos;
        Vector2 maxScreenPos;
        float smashFixedY;
        float swingFixedX;
        public BossAttack(Vector2 _pos, Vector2 _minScreenPos, Vector2 _maxScreenPos, float _smashFixedY, float _swingFixedX)
        {
            minScreenPos = _minScreenPos;
            maxScreenPos = _maxScreenPos;
            int aux = UnityEngine.Random.Range(0, 3);
            at = (AttackType)Enum.GetValues(typeof(AttackType)).GetValue(UnityEngine.Random.Range(0, 3));
            pos = _pos;
            smashFixedY = _smashFixedY;
            swingFixedX = _swingFixedX;
            RandomPos();
        }

        public void RandomPos()
        {
            switch (at)
            {
                case AttackType.Smash:
                    pos = new Vector2(pos.x + UnityEngine.Random.Range(-1, 2), smashFixedY);
                    if (pos.x < minScreenPos.x)
                    {
                        pos = new Vector2(minScreenPos.x, smashFixedY);
                    }
                    if (pos.x > maxScreenPos.x)
                    {
                        pos = new Vector2(maxScreenPos.x, smashFixedY);
                    }
                    break;
                case AttackType.Swing:
                    pos = new Vector2(swingFixedX, pos.y + UnityEngine.Random.Range(-0.25f, 0.25f));
                    if (pos.y < minScreenPos.y + 0.25f)
                    {
                        pos = new Vector2(swingFixedX, minScreenPos.y + 0.25f);
                    }
                    if (pos.y > maxScreenPos.y)
                    {
                        pos = new Vector2(swingFixedX, maxScreenPos.y);
                    }
                    break;
                case AttackType.Rain:
                    pos = Vector2.zero;
                    break;
            }
        }
        public int GetAttackType()
        {
            return Convert.ToInt32(at);
        }
        public Vector2 GetPos()
        {
            return pos;
        }
    }
}
