using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insertPw : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] private string rightPw;

    void OnEnable()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void Unpause(){
        GameManager.Instance.EnableSameCharacter();
        //Cursor.visible = false;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CheckPwCorrectness(){
        string value = input.text;//int.Parse(input.text);
        Debug.Log(value);
        if(value == rightPw){
            Debug.Log("WOAH! OPEN DOOR");
        }else{
            Debug.Log("DOOR CLOSED");
        }
        //Call game manager change scene;
        GameManager.Instance.EnableSameCharacter();
        Cursor.visible = false;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
