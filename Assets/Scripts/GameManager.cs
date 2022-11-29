using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public List<playerPositionsScenes> playersPositions;
    public static GameManager Instance;
    public GameObject currentPlayer;
    public int currentPlayerId;
    public List<GameObject> characters; //Prefabs of the characters that can be used.
    [SerializeField] GameObject chooseCharactersMenu;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public GameObject controllingCharacter;

    //used for knowing where to spawn the character;
    public Transform spawnPosition;
    public string triggerName;

    public AudioSource audioSource;
    public AudioClip doorSound;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ENTERING GAME MANAGER START");
        playersPositions = new List<playerPositionsScenes>();
        if(Instance!=null){
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        //Instantiate(CameraAll,spawnPosition.position, Quaternion.identity);
        spawnPosition = GameObject.Find("leftSpawnPosition").transform;
        //PrefabUtility.InstantiatePrefab(characters[currentPlayerId] as GameObject) as GameObject;
        controllingCharacter = Instantiate(characters[currentPlayerId], spawnPosition.position, Quaternion.identity) as GameObject;
        controllingCharacter.name = characters[currentPlayerId].name;
        virtualCamera.Follow = controllingCharacter.transform;
    }

    void OnLevelWasLoaded(){
        PrintAllCharacters();
        if(triggerName == "rightTrigger"){
            spawnPosition = GameObject.Find("leftSpawnPosition").transform;
            SpawnCharacter(spawnPosition);
        }else if(triggerName == "leftTrigger"){
            spawnPosition = GameObject.Find("rightSpawnPosition").transform;
            SpawnCharacter(spawnPosition);
        }else if(triggerName == "otherTrigger"){
            spawnPosition = GameObject.Find("otherSpawn").transform;
            SpawnCharacter(spawnPosition);
        }
        currentPlayer = controllingCharacter;
        Debug.Log(currentPlayer);
        virtualCamera.Follow = controllingCharacter.transform;
        CreateAllCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCharacter(){
        controllingCharacter.GetComponent<PlayerInput>().enabled = false;
        controllingCharacter.GetComponent<Player>().SetVelocityX(0f);
        controllingCharacter.GetComponent<Player>().Controlling = false;
        controllingCharacter.GetComponent<Player>().setControllingData(false);
    }

    public void EnableNewCharacter(GameObject newPlayer){
        controllingCharacter.GetComponent<Player>().HideCircle();
        //currentPlayer.GetComponent<Player>().enabled=false;
        controllingCharacter.GetComponent<Player>().Controlling = false;
        controllingCharacter.GetComponent<Player>().setControllingData(false);
        
        controllingCharacter = newPlayer;
        controllingCharacter.GetComponent<PlayerInput>().enabled = true;
        //currentPlayer.GetComponent<Player>().enabled = true;
        controllingCharacter.GetComponent<Player>().Controlling = true;
        controllingCharacter.GetComponent<Player>().setControllingData(true);
        currentPlayerId =  controllingCharacter.GetComponent<Player>().id;
        virtualCamera.Follow = controllingCharacter.transform;

        controllingCharacter = newPlayer;
        //Tell camera to follow the new player
    }

    public void EnableSameCharacter(){
        controllingCharacter.GetComponent<PlayerInput>().enabled = true;
        controllingCharacter.GetComponent<Player>().Controlling = true;
        controllingCharacter.GetComponent<Player>().setControllingData(true);
    }

    public void OpenCharactersMenu(Collider2D[] players){
        /*for(int i=0; i<players.Length; i++){
            Debug.Log(players[i].gameObject);
        }*/
        DisableCharacter();
        List<GameObject> playableCharacters = new List<GameObject>();
        List<int> playableCharactersId = new List<int>();
        for(int i=0; i<players.Length; i++){
            playableCharacters.Add(players[i].gameObject);
            playableCharactersId.Add(players[i].gameObject.GetComponent<Player>().id);
            Debug.Log(players[i]);
        }
        chooseCharactersMenu.GetComponent<chooseCharacters>().characters = playableCharactersId;
        chooseCharactersMenu.SetActive(true);
    }

    public void ChangeScene(string name, string sceneToLoad){
        triggerName = name;
        SceneManager.LoadScene(sceneToLoad);
    }

    public bool SceneContainsCurrent(){
        if(GameObject.Find(characters[currentPlayerId].name)){
            return true;
        }else{
            return false;
        }
    }

    public void InsertButlerInstead(){
       GameObject element = GameObject.Find(characters[currentPlayerId].name);
       Transform butlerPos = element.transform;
       GameObject butler = Instantiate(characters[0], butlerPos.position, Quaternion.identity) as GameObject;
       Destroy(element);
    }

    public void SavePlayerInScene(string sceneName, List<Player> players){
        for(var i=0;i<players.Count;i++){
            if(players[i]==controllingCharacter){
                players.RemoveAt(i);
            }
        }
        //Scena
        //PlayerId
        //Posizione
        for(var i=0;i<players.Count;i++){
            if(CheckAlreadyInside(players[i], sceneName)){
                //Do Nothing
            }else{
                playerPositionsScenes playerToAdd = ScriptableObject.CreateInstance<playerPositionsScenes>();
                playerToAdd.playerID = players[i].id;
                playerToAdd.position = players[i].transform.position;
                playerToAdd.sceneName = sceneName;
                playerToAdd.name = players[i].name;
                playersPositions.Add(playerToAdd);
            };

        }
    }

    public bool CheckAlreadyInside(Player player, string sceneName){
        for(var i=0;i<playersPositions.Count;i++){
            if(playersPositions[i].playerID == player.id){
                Debug.Log("Already inside so change position...");
                playersPositions[i].position = player.transform.position;
                playersPositions[i].sceneName = sceneName;
                return true;
            }
        }
        return false;
    }

    public void PrintAllCharacters(){
        for(var i=0; i<playersPositions.Count; i++){
            Debug.Log(playersPositions[i].playerID);
            Debug.Log(playersPositions[i].position);
            Debug.Log(playersPositions[i].sceneName);
        }
    }

    public void CreateAllCharacters(){
        for(var i=0; i<playersPositions.Count; i++){
            if(playersPositions[i].playerID != controllingCharacter.GetComponent<Player>().id && SceneManager.GetActiveScene().name==playersPositions[i].sceneName){
                Debug.Log("STESSA SCENA Quello salvato: " + playersPositions[i].playerID + "L'altro: " + controllingCharacter.GetComponent<Player>().id);
                Debug.Log("STESSA SCENA Quello salvato: " + playersPositions[i].name + "L'altro: " + controllingCharacter.GetComponent<Player>().name);
                GameObject characterToDelete = GameObject.Find(playersPositions[i].name);
                if(characterToDelete!=null){Destroy(characterToDelete);}
                GameObject characterToCreate = Instantiate(characters[playersPositions[i].playerID], playersPositions[i].position, Quaternion.identity) as GameObject;
                characterToCreate.name = playersPositions[i].name;
                characterToCreate.GetComponent<PlayerInput>().enabled = false;
                characterToCreate.GetComponent<Player>().Controlling = false;
                characterToCreate.GetComponent<Player>().setControllingData(false);
                characterToCreate.GetComponent<Player>().SetVelocityX(0f);
            }else if(playersPositions[i].playerID != controllingCharacter.GetComponent<Player>().id && SceneManager.GetActiveScene().name!=playersPositions[i].sceneName){
                Debug.Log("Quello salvato: " + playersPositions[i].playerID + "L'altro: " + controllingCharacter.GetComponent<Player>().id);
                Debug.Log("Quello salvato: " + playersPositions[i].name + "L'altro: " + controllingCharacter.GetComponent<Player>().name);
                GameObject characterToDelete = GameObject.Find(playersPositions[i].name);
                if(characterToDelete!=null){
                    Destroy(characterToDelete);
                }
            }
        }
    }

    public void SpawnCharacter(Transform position){
        Debug.Log("HOW MANY TIMES AM I CALLED");
        Debug.Log(GameManager.Instance);
        //Check if character that I want to create is already in the scene, if not then do nothing, if he is then delete him and use the current player.
        //controllingCharacter = PrefabUtility.InstantiatePrefab(characters[currentPlayerId] as GameObject) as GameObject;
        if(SceneContainsCurrent()){
            //inserisci butler al posto dell'oggetto trovato.
            InsertButlerInstead();
        }
        controllingCharacter = Instantiate(characters[currentPlayerId], position.position, Quaternion.identity) as GameObject;
        Debug.Log(controllingCharacter);
        controllingCharacter.name = characters[currentPlayerId].name;
        controllingCharacter.GetComponent<Player>().setControllingData(true);
        Debug.Log( controllingCharacter.name);
    }

    public void PlaySoundScene(bool fromDoor){
        if(fromDoor){
            audioSource.PlayOneShot(doorSound);
        }
    }
    
}
