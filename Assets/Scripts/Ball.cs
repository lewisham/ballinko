using System;
using System.Collections.Generic;
using UnityEngine;

class Ball: MonoBehaviour
{
    float m_Elapsed;
    public float TimeOut = 15.0f;
    BallPath m_BallPath;
    public int from;
    public int frame;

    public void Start()
    {
        m_BallPath = new BallPath();
        m_BallPath.from = from;
        m_BallPath.events = new List<CollisionEvent>();
        m_BallPath.posistion = new List<int>();
    }

    private void Update()
    {
        m_Elapsed += Time.deltaTime;
        if (m_Elapsed > TimeOut)
        {
            GameObject.Destroy(gameObject);
            return;
        }
        var pos = transform.localPosition;
        m_BallPath.posistion.Add(Mathf.FloorToInt(pos.x));
        m_BallPath.posistion.Add(Mathf.FloorToInt(pos.y));
        frame++;
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
            m_BallPath.to = idx;
            BallPathManager.Instance.AddPath(m_BallPath);
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
        int id = 0;
        int.TryParse(name, out id);
        if (id != 0)
        {
            var evt = new CollisionEvent();
            evt.frame = frame;
            evt.id = id;
            m_BallPath.events.Add(evt);
        }
        //Debug.Log($"OnCollisionEnter2D {collision.gameObject.name}");
    }
}
