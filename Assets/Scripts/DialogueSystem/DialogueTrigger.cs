using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    public void TriggerDialogue(Dialogue receivedDialogue){
        DialogueManager.Instance.StartDialogue(receivedDialogue);
    }
}
