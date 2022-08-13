using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PiecesScripts : MonoBehaviour
{
    public Vector3 rightPosition;
    public bool inRightPosition;
    public bool selected;

    private void Awake()
    {
        
    }


    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(3f, 8f), Random.Range(-4f, 2.5f));
        
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, rightPosition) < 0.5f)
        {
            if (!selected)
            {
                if (inRightPosition == false)
                {
                    transform.position = rightPosition;
                    inRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
            
        }
    }

}
