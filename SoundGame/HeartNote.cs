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



        Vector3 vec = new Vector3(-(noteSpeed * Time.deltaTime),0 ); //������Ʈ�� ��� ����Ǵ� �κ��̹Ƿ� 0.1�� �̵������ִ� �Լ��̴�.

        transform.Translate(vec);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
