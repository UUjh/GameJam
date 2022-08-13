using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bug : MonoBehaviour
{
    float speed = 2f;

    CharacterController charCtrl;
    Animator animator;

    BugMaker bugMaker;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        InvokeRepeating("ChangeDirection", 0.5f, 0.5f);    
    }

    void ChangeDirection()
    {
        float angle = 0.0f;
        int random = UnityEngine.Random.Range(0, 3);

        switch(random)
        {
            case 0:
                angle = 45;
                break;
            case 1:
                angle = 0;
                break;
            case 2:
                angle = -45;
                break;
        }

        transform.Rotate(0.0f, 0.0f, angle);
    }
    void Update()
    {

        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        
        CancelInvoke();
        
        Debug.Log("¹ú·¹ ÀâÀ½");
        

        bugMaker = GameObject.Find(name: "BugMaker").GetComponent<BugMaker>();
        bugMaker.OnBugDead();
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Debug.Log("¹ú·¹ ¸ø ÀâÀ½");
        Destroy(gameObject);
    }
}

