using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BossDoor : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject inputPw;
    [SerializeField] private string rightPw;
    public string userPW;

    public void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            //Show PW UI...
            GameManager.Instance.DisableCharacter();
            inputPw.SetActive(true);
        }
    }
}
