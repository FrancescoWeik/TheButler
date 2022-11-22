using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static PauseMenuHandler Instance;
    public GameObject OptionsMenu;
    // Start is called before the first frame update
     void Start()
    {
        if(Instance!=null){
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void ActivateMenu(){
        pauseMenu.SetActive(true);
    }

    
    public void Options(){
        Debug.Log("Options");
        //show option and controls...
        pauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void BackFromOptions(){
        OptionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}