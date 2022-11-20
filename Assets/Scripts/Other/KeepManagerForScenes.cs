using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepManagerForScenes : MonoBehaviour
{
    public static KeepManagerForScenes Instance;

    //data to reset when starting the game
    /*[SerializeField] private SceneData sceneData;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerData chefData;
    [SerializeField] private PlayerData cleaningData;
    [SerializeField] private RuntimeAnimatorController butlerController;*/

    void Start()
    {
        if(Instance!=null){
            Destroy(this.gameObject);
            return;
        }

        /*sceneData.ResetAll();
        playerData.ResetAll(butlerController);
        chefData.ResetAll();
        cleaningData.ResetAll();*/
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
