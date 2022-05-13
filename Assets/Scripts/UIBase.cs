using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIBase : MonoBehaviour
{
    Dictionary<string, GameObject> childMap;

    public void BindUI()
    {
        if (childMap != null)
        {
            Debug.Log("已经绑定过UI，不能再次绑定");
            return;
        }
        if (childMap == null)
        {
            childMap = new Dictionary<string, GameObject>();
        }
        BindGameObject(transform);
    }

    // 把子节点映射到childMap
    private void BindGameObject(Transform tf)
    {
        if (tf.GetComponent<Button>() != null)
        {
            BindButtonEvent(tf.GetComponent<Button>());
        }
        childMap[tf.gameObject.name] = tf.gameObject;
        Transform child = null;
        for (int i = 0; i < tf.childCount; i++)
        {
            child = tf.GetChild(i);
            BindGameObject(child);
        }
    }

    // 绑定按钮事件
    private void BindButtonEvent(Button btn)
    {
        string btnName = btn.gameObject.name;
        btn.onClick.AddListener(delegate ()
        {
            Invoke("OnClick_" + btnName, 0);
        });
    }

    // 查找对象
    public GameObject FindObject(string name)
    {
        if (childMap.ContainsKey(name))
        {
            return childMap[name];
        }
        return null;
    }

    // 查找组件
    public T FindComponent<T>(string name) where T : Component
    {
        GameObject go = FindObject(name);
        if (go == null) return null;
        T ret = go.GetComponent<T>();
        return ret;
    }

    protected void OnDestroy()
    {
        childMap = null;
    }
}

