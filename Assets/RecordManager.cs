using System;
using System.Collections.Generic;
using UnityEngine;

class RecordManager: Singleton<RecordManager>
{
    Dictionary<int, int> m_EnterBallDic = new Dictionary<int, int>();

    public void AddEnterHoleCount(int id)
    {
        if (m_EnterBallDic.ContainsKey(id))
        {
            m_EnterBallDic[id]++;
        }
        else
        {
            m_EnterBallDic[id] = 1;
        }
    }

    public int GetEnterHoleCount(int id)
    {
        if (m_EnterBallDic.ContainsKey(id))
        {
            return m_EnterBallDic[id];
        }
        return 0;
    }

    public UITest GetUITest()
    {
        var go = GameObject.Find("Canvas/UITest");
        if (go != null)
        {
            return go.GetComponent<UITest>();
        }
        return null;
    }
}
