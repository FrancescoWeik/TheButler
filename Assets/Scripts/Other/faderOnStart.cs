using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faderOnStart : MonoBehaviour
{
    public void DestroyFader(){
        gameObject.SetActive(false);
    }
}
