using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayIfEye : MonoBehaviour
{
    [SerializeField] private GameObject passwordWall;
    [SerializeField] private Item item;
    private bool alreadyActive = false;

    // Update is called once per frame
    void Update()
    {
        if(InventoryManager.Instance.mechEye && !alreadyActive){
            passwordWall.SetActive(true);
            alreadyActive = true;
        }
    }
}
