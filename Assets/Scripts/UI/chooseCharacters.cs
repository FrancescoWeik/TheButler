using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseCharacters : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> characters; //valid characters that the user can pick from, it is set by the game manager

    //Important to keep the order in this two lists.
    [SerializeField] private List<GameObject> allCharacters; //all the characters, so I can "disable" those that are not inside of characters
    [SerializeField] private List<Button> allButtons; //all the buttons, so I can disable those that are not inside of characters

    void OnEnable()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;

        //check wich buttons to disable
        for(var i=0; i<characters.Count; i++){
            if(allCharacters.Contains(characters[i])){
                Debug.Log("contains the character... " + characters[i]);
                var index = allCharacters.IndexOf(characters[i]);
                allButtons[index].interactable = true;
            }
        }

    }

    public void Unpause(){
        gameManager.EnableSameCharacter();
        Cursor.visible = false;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ChooseCharacter(GameObject character){
        if(characters.Contains(character)){
            gameManager.EnableNewCharacter(character);
            Cursor.visible = false;
            DisableAllButtons();
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }else{
            //show that you can't use that certain character...
        }
    }

    private void DisableAllButtons(){
        for(var i=0;i<allButtons.Count; i++){
            allButtons[i].interactable = false;
        }
    }
}
