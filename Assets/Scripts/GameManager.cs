using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject currentPlayer;
    GameObject[] possibleCharacters;
    [SerializeField] GameObject chooseCharactersMenu;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    //Menu chooseCharacters...

    private void Awake(){
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCharacter(){
        currentPlayer.GetComponent<PlayerInput>().enabled = false;
        currentPlayer.GetComponent<Player>().SetVelocityX(0f);
        currentPlayer.GetComponent<Player>().Controlling = false;
    }

    public void EnableNewCharacter(GameObject newPlayer){
        currentPlayer.GetComponent<Player>().HideCircle();
        //currentPlayer.GetComponent<Player>().enabled=false;
        currentPlayer.GetComponent<Player>().Controlling = false;
        
        currentPlayer = newPlayer;
        currentPlayer.GetComponent<PlayerInput>().enabled = true;
        //currentPlayer.GetComponent<Player>().enabled = true;
        currentPlayer.GetComponent<Player>().Controlling = true;
        virtualCamera.Follow = currentPlayer.transform;
        //Tell camera to follow the new player
    }

    public void EnableSameCharacter(){
        currentPlayer.GetComponent<PlayerInput>().enabled = true;
        currentPlayer.GetComponent<Player>().Controlling = true;
    }

    public void OpenCharactersMenu(Collider2D[] players){
        /*for(int i=0; i<players.Length; i++){
            Debug.Log(players[i].gameObject);
        }*/
        DisableCharacter();
        List<GameObject> playableCharacters = new List<GameObject>();
        for(int i=0; i<players.Length; i++){
            playableCharacters.Add(players[i].gameObject);
            Debug.Log(players[i]);
        }
        chooseCharactersMenu.GetComponent<chooseCharacters>().characters = playableCharacters;
        chooseCharactersMenu.SetActive(true);
    }
}
