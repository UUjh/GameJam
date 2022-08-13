using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honer : MonoBehaviour
{
    public Animator animator;
    public GameObject GameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("HonerOpen");
    }
}
