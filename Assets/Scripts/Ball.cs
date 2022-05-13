using System;
using UnityEngine;

class Ball: MonoBehaviour
{

    public void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.gameObject.name;
        if (name == "Bottom")
        {
            GameObject.Destroy(gameObject);
            return;
        }
        Debug.Log($"OnCollisionEnter2D {collision.gameObject.name}");
    }
}
