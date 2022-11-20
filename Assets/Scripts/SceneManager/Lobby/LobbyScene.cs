using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : SceneLoader
{

    [SerializeField] private GameObject CleaningLady;
    [SerializeField] private GameObject fullCleaningLady;
    [SerializeField] private SceneData data;
    [SerializeField] private Item book;
    [SerializeField] private GameObject sceneBook;

    protected override void Start(){
        base.Start();
        Instance = this;

        if(data.cleaningLadyActive){
            Destroy(fullCleaningLady);
        }
        if(data.chefBook == true){
            sceneBook.SetActive(false);
        }
    }

    public override void SaveSceneState(){
        base.SaveSceneState();
        if(CleaningLady !=null){
            if(CleaningLady.activeSelf == true){
                data.cleaningLadyActive = true;
            }
        }
        if(InventoryManager.Instance.Items.Contains(book)){
            data.chefBook = true;
        }
    }
    
}
