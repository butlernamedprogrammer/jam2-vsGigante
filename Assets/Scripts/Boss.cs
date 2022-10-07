using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    [SerializeField]
    Vector2 screenEdges;
    [SerializeField]
    float timeBetweenAttacks;
    [SerializeField]
    GameObject attackCtrl;
    [SerializeField]
    GameObject smashAttack;
    [SerializeField]
    GameObject swingAttack;
    [SerializeField]
    GameObject rainGenerator;
    Animator anim;

    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Animator>(out anim);
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
    }

    
}
