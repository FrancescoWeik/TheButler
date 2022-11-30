using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mouseCurspr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mos_pos = Mouse.current.position.ReadValue();
        mos_pos.z = Camera.main.nearClipPlane;
        Vector3 mos_world_pos = Camera.main.ScreenToWorldPoint(mos_pos);
        Vector2 mousePosition = new Vector2(mos_world_pos.x,mos_world_pos.y);
        transform.position = mousePosition;
    }
}
