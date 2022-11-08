using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PizzaRotate : MonoBehaviour
{
    //used to rotate the object so that I know how to launch the pizza
    public void Update(){
        Vector2 pizzaPosition = transform.position;
        Vector3 mos_pos = Mouse.current.position.ReadValue();
        mos_pos.z = Camera.main.nearClipPlane;
        Vector3 mos_world_pos = Camera.main.ScreenToWorldPoint(mos_pos);
        Vector2 mousePosition = new Vector2(mos_world_pos.x,mos_world_pos.y);
        Vector2 direction = mousePosition - pizzaPosition;
        transform.right = direction;
    }
}
