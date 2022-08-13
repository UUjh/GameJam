using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressImage : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetTrigger("ProgressHide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
