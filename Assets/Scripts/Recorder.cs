using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recorder : MonoBehaviour
{
    GameObject m_Ball;

    public int startIdx;

    UITest GetUI()
    {
        return gameObject.GetComponent<UITest>();
    }

    public void Update()
    {
        if (m_Ball == null)
        {
            m_Ball = GetUI().OnStartFire(startIdx);
        }
    }
}
