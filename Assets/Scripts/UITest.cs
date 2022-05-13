using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : UIBase
{
    // Start is called before the first frame update
    void Start()
    {
        BindUI();
        for (int i = 1; i <= 5; i++)
        {
            var btn = transform.Find("BG/Up/Fire{i}/BtnFire").GetComponent<Button>();
            BindFireEvent(btn, i);
        }
    }

    void BindFireEvent(Button btn, int idx)
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate ()
        {
            OnStartFire(idx);
        });
    }

    void OnStartFire(int idx)
    {
        var tf = transform.Find("BG/Up/Fire{i}/FirePos");
        var prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/Prefabs/Ball.prefab");
        var ball = GameObject.Instantiate(prefab, transform);
        ball.transform.localPosition = tf.localPosition;
        Debug.Log($"Fire {idx}");
    }
}
