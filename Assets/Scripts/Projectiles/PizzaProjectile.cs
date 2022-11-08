using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    public int layerToHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        layerToHit = LayerMask.NameToLayer("Button");
    }

    // Update is called once per frame
    void Update()
    {
        if(hasHit == false){
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        Debug.Log(collision);
        if(collision.gameObject.layer == layerToHit){
            Debug.Log("hit button");
            collision.gameObject.SendMessage("MessageButtonHit");
            //send message
        }
        //destroy pizza
        Destroy(gameObject);
    }
}
