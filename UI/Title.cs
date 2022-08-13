using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("Title");
        animator.SetTrigger("Title2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
