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
    GameObject attackCtrl;   
    Animator anim;

    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
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

    
}
