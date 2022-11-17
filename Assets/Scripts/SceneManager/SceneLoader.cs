using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    string sceneName;

    protected virtual void Start(){
        Instance = this;
        sceneName = SceneManager.GetActiveScene().name;
    }

    public virtual void SaveSceneState(){
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        List<Player> playersList = new List<Player>();
        //List<GameObject> playersList = new List<GameObject>(players);
        Debug.Log(players);
        for(var i=0; i<players.Length;i++){
            if(players[i].GetComponent<Player>()){
                playersList.Add(players[i].GetComponent<Player>());
            }
            //Debug.Log(players.Length);
            //Debug.Log(players[i]);
        }
        GameManager.Instance.SavePlayerInScene(sceneName, playersList);
    }
}
