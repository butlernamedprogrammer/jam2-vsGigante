using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Vector2 minScreenPos;
    [SerializeField]
    Vector2 maxScreenPos;
    Animator anim;
    BossAttack currentAttack;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (anim?.GetCurrentAnimatorStateInfo(0).length < anim?.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            currentAttack = new BossAttack(player.transform.position, minScreenPos, maxScreenPos);
        }
    }
    private class BossAttack
    {
        public enum AttackType { Smash, Swing, Rain };
        AttackType at { get; set; }
        Vector2 pos { get; set; }
        Vector2 minScreenPos;
        Vector2 maxScreenPos;
        public BossAttack(Vector2 _pos, Vector2 _minScreenPos, Vector2 _maxScreenPos)
        {
            minScreenPos = _minScreenPos;
            maxScreenPos = _maxScreenPos;
            at = (AttackType)Enum.GetValues(typeof(AttackType)).GetValue(UnityEngine.Random.Range(0, 3));
            pos = _pos;
        }

        public void RandomPos()
        {
            switch (at)
            {
                case AttackType.Smash:
                    pos = new Vector2(maxScreenPos.y + 1, pos.x + UnityEngine.Random.Range(-1, 2));
                    break;
                case AttackType.Swing:
                    pos = new Vector2(maxScreenPos.x + 1, UnityEngine.Random.Range(-1, 2));
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


    }
}
