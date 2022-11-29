using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSceneDoor : MonoBehaviour, IPointerDownHandler
{
    public string triggerName;
    public string sceneToLoad;
    [SerializeField] protected SceneLoader sceneManag;
    public bool fromDoor;
   // [SerializeField] protected AudioSource audioSource;
   // [SerializeField] protected AudioClip audioClip;

    public virtual void OnPointerDown(PointerEventData eventData){
        sceneManag.SaveSceneState();
        GameManager.Instance.PlaySoundScene(fromDoor);
        GameManager.Instance.ChangeScene(triggerName, sceneToLoad);
    }
}