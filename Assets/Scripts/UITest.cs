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
            string name = $"BG/Up/Fire{i}/BtnFire";
            Debug.Log(name);
            var btn = transform.Find(name).GetComponent<Button>();
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
        var tf = transform.Find($"BG/Up/Fire{idx}/FirePos");
        var prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/Prefabs/Ball.prefab");
        var ball = GameObject.Instantiate(prefab, transform);
        var offset = Vector3.zero;
        float offx = 0.001f;
        float offy = 0.001f;
        offset.x = UnityEngine.Random.Range(-offx, offx);
        offset.y = UnityEngine.Random.Range(-offy, offy);
        ball.transform.position = tf.position + offset;
        Debug.Log($"Fire {idx}");
    }
}
