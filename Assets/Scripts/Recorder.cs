using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recorder : MonoBehaviour
{
    Dictionary<int, GameObject> m_Balls;

    public int startIdx;

    private void Start()
    {
        m_Balls = new Dictionary<int, GameObject>();
    }

    UITest GetUI()
    {
        return gameObject.GetComponent<UITest>();
    }

    public void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!m_Balls.ContainsKey(i) || m_Balls[i] == null)
            {
                var ball = GetUI().OnStartFire(i + 1);
                m_Balls[i] = ball;
            }
        }
    }
}
