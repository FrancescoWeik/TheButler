using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NonActiveClick : clickItemToTrigger, IPointerDownHandler
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public override void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(audioClip);
            }
            base.OnPointerDown(eventData);
        }
    }
}
