using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

class BallPathManager: Singleton<BallPathManager>
{
    List<BallPath> list = new List<BallPath>();

    public void AddPath(BallPath ballPath)
    {
        list.Add(ballPath);
    }

    public void Save()
    {
        string str = LitJson.JsonMapper.ToJson(list);
        string path = Application.dataPath + "/Exprot~/ballpath.json";
        File.WriteAllText(path, str);
        Debug.Log($"Save File Success! {list.Count}");
    }
}

