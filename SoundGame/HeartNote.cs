using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartNote : MonoBehaviour
{
    // Start is called before the first frame update
    public float noteSpeed = 400f;

    void Start()
    {
        noteSpeed = 1500f;
    }

    // Update is called once per frame
    void Update()
    {



        Vector3 vec = new Vector3(-(noteSpeed * Time.deltaTime),0 ); //업데이트는 계속 실행되는 부분이므로 0.1씩 이동시켜주는 함수이다.

        transform.Translate(vec);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
