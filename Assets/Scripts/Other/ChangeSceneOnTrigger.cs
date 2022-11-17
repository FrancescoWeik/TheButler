using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string layerToHit;
    [SerializeField] SceneLoader sceneManag;
    public string triggerName;
    private int playerLayer;

    public void Start(){
        playerLayer = LayerMask.NameToLayer(layerToHit);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == playerLayer){
            sceneManag.SaveSceneState();
            GameManager.Instance.ChangeScene(triggerName, sceneToLoad);
            //SceneManager.LoadScene(sceneToLoad);
            //load new scene...
        }
    }
}
