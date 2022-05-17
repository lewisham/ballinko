using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : UIBase
{
    Recorder m_Recorder;
    public int startIdx = 4;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
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

    public GameObject OnStartFire(int idx)
    {
        var tf = transform.Find($"BG/Up/Fire{idx}/FirePos");
        var prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/Prefabs/Ball.prefab");
        var ball = GameObject.Instantiate(prefab, transform);
        float offsetX = UnityEngine.Random.Range(-100, 100) / 1000;
        float offsetY = UnityEngine.Random.Range(-100, 100) / 1000;
        ball.transform.position = tf.position + new Vector3(offsetX, offsetY);
        Rigidbody2D rigidbody2D = ball.GetComponent<Rigidbody2D>();
        float sx = UnityEngine.Random.Range(-0.1f, 0.1f);
        float sy = UnityEngine.Random.Range(0.2f, 0.5f);
        rigidbody2D.velocity = new Vector2(sx, -sy);
        ball.layer = LayerMask.NameToLayer($"Ball{idx}");
        return ball;
    }

    void OnClick_BtnStartRecord()
    {
        if (m_Recorder == null)
        {
            m_Recorder = gameObject.AddComponent<Recorder>();
            m_Recorder.startIdx = startIdx;
        }
        else
        {
            GameObject.Destroy(m_Recorder);
        }
    }

    public void UpdateEnterBallCount(int id)
    {
        var ui = transform.Find($"BG/Bottom/heat{id}/Text");
        if (ui != null)
        {
            ui.GetComponent<Text>().text = RecordManager.Instance.GetEnterHoleCount(id).ToString();
        }
    }
}
