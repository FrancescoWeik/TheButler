using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Animator animator;

    public Text nameText;
    public Text dialogueText;

    [SerializeField] private float waitTime = 5f;
    private float startTime = 0f;
    private bool lastDialogue;

    private Queue<string> sentences;

    /*public void Awake(){
        Instance = this;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        if(Instance!=null){
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        sentences = new Queue<string>();
    }

    public void Update(){
        if(lastDialogue){
            startTime += Time.deltaTime;
            if(startTime>waitTime){
                startTime = 0f;
                EndDialogue();
            }
            //startTime
        }
    }

    public void StartDialogue(Dialogue dialogue){
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        lastDialogue = false;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 1){
            lastDialogue = true;
            startTime = 0f;
        }
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue(){
        startTime = 0f;
        animator.SetBool("isOpen", false);
        Debug.Log("end of conversation");
    }
}
