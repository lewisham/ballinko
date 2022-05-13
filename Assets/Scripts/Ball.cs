using System;
using UnityEngine;

class Ball: MonoBehaviour
{
    float m_Elapsed;
    public float TimeOut = 15.0f;
    public void Start()
    {
        
    }

    private void Update()
    {
        m_Elapsed += Time.deltaTime;
        if (m_Elapsed > TimeOut)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name;
        //Debug.Log($"OnTriggerEnter2D {collision.gameObject.name}");
        name = name.Replace("heat", "");
        int idx = 0;
        int.TryParse(name, out idx);
        if (idx > 0)
        {
            RecordManager.Instance.AddEnterHoleCount(idx);
            RecordManager.Instance.GetUITest().UpdateEnterBallCount(idx);
        }
        GameObject.Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.gameObject.name;
        if (name == "Bottom")
        {
            GameObject.Destroy(gameObject);
            return;
        }
        //Debug.Log($"OnCollisionEnter2D {collision.gameObject.name}");
    }
}
