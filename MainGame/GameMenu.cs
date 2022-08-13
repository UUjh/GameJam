using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    public Animator animator;
    public Animator menuarrow;
    public Button menu;
    public int ClickCheck;
    public int ClickCheck2;
    void Start()
    {
        ClickCheck = 0;
        ClickCheck2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuClick()
    {
        if(ClickCheck == 0)
        {
            menu.gameObject.SetActive(true);
            animator.SetTrigger("MenuOpen");
            ClickCheck = 1;
        }
        else
        {
            
            animator.SetTrigger("MenuBack");
            menu.gameObject.SetActive(false);
            ClickCheck = 0;
        }
    }
    public void MenuArrow()
    {
        if(ClickCheck2 == 0)
        {
            menuarrow.SetTrigger("MenuArrow");
            ClickCheck2 = 1;
        }
        else
        {
            menuarrow.SetTrigger("MenuArrowBack");
            ClickCheck2 = 0;
        }
    }

}
