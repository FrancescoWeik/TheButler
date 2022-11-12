using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DoorPwInteractable : Interactable
{
    [SerializeField] GameObject input;
    [SerializeField] private string rightPw;
    [SerializeField] private GameManager gameManager;
    public string userPW;

    public override void ActivateItem(){
        base.ActivateItem();

        //mostra a user ui con codice da inserire.
        gameManager.DisableCharacter();
        input.SetActive(true);
    }
}
