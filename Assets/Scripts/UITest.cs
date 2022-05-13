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
        ball.transform.position = tf.position;
        Rigidbody2D rigidbody2D = ball.GetComponent<Rigidbody2D>();
        float sx = UnityEngine.Random.Range(-2, 2);
        float sy = UnityEngine.Random.Range(10, 20);
        rigidbody2D.velocity = new Vector2(sx, -sy);
    }
}
