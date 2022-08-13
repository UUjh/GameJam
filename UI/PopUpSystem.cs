using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopUpSystem : MonoBehaviour
{
    public GameObject popup;
    Animator anim;
    public static PopUpSystem instance { get; private set; }

    public TextMeshProUGUI textTitle, textContent;
    Action onClickOkay, onClickCancel;
    private void Awake()
    {
        instance = this;
        anim = popup.GetComponent<Animator>();
    }

    public void OpenPopUp(string title,string content,Action onClickOkay,Action onClickCancel)
    {
        {
            textTitle.text = title;
            textContent.text = content;
            this.onClickOkay = onClickOkay;
            this.onClickCancel = onClickCancel;
            popup.SetActive(true);
        }
    }
    private void Update()
    {
       
      if(anim.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                popup.SetActive(false);
            }
        }
        
    }
    public void OnClickOkay()
    {
        if(onClickOkay != null)
        {
            onClickOkay();
        }
        ClosePopUp();
    }

    public void OnCLickCancel()
    {
        if(onClickCancel != null)
        {
            onClickCancel();
        }
        ClosePopUp();
    }
     

    void ClosePopUp()
    {
        anim.SetTrigger("close");
        
    }


}
