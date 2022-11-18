using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyGuardDoor : clickItemToTrigger
{
    public string triggerName;
    public string sceneToLoad;
    [SerializeField] SceneLoader sceneManag;

    public override void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            if(GameManager.Instance.currentPlayerId==2){
                //è la cleaning lady
                sceneManag.SaveSceneState();
                GameManager.Instance.ChangeScene(triggerName, sceneToLoad);
            }else{
                base.OnPointerDown(eventData);
            }
        }
    }
}
