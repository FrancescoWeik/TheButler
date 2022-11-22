using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    void OnEnable(){
        Cursor.visible = true;
        //GameManager.Instance.audioSource.PlayOneShot(openSound);
        Time.timeScale = 0f;
        GameManager.Instance.DisableCharacter();
    }

    public void UnPause(){
        GameManager.Instance.EnableSameCharacter();
        //Cursor.visible = false;
        gameObject.SetActive(false);
        //GameManager.Instance.audioSource.PlayOneShot(openSound);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit game");
        Application.Quit();
        //Quit
    }

    public void RestartRoom(){
        //reset room
    }
}