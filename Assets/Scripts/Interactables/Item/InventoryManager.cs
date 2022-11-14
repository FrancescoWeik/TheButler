using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public bool mechEye = false; //set to true by butler so that I can see the pw on the walls.

    public Transform ItemContent; //where items are filled
    public GameObject InventoryItem;//the prefab of the item 

    private void Awake(){
        Instance = this;
    }

    private void Start(){
        ListItems();
    }
    
    public void Add(Item item){
        Items.Add(item);

        //Add To Inventory....
        /*GameObject obj = Instantiate(InventoryItem,ItemContent);
        var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
        var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;*/
        ListItems();

    }

    public void Remove(Item item){
        Items.Remove(item);
    }

    //List all items inside the inventory
    public void ListItems(){
        //Destroy the item before showing them...
        foreach(Transform item in ItemContent){
            Destroy(item.gameObject);
        }
        foreach(var item in Items){
            Debug.Log(item);
            GameObject obj = Instantiate(InventoryItem,ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }
}
