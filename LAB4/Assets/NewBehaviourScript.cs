using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetFloat("Blend", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
