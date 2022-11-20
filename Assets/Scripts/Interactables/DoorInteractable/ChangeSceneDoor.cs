using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSceneDoor : MonoBehaviour, IPointerDownHandler
{
    public string triggerName;
    public string sceneToLoad;
    [SerializeField] SceneLoader sceneManag;

    public virtual void OnPointerDown(PointerEventData eventData){
        sceneManag.SaveSceneState();
        GameManager.Instance.ChangeScene(triggerName, sceneToLoad);
    }
}