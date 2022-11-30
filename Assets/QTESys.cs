using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class QTESys : MonoBehaviour
{
    private float fillAmount = 0;
    public float TIME;
    private float _timeleft;
    private float _time;
    public Text KeyNameText;
    private string KeyName;
    private bool correctness = false;

    public Flowchart flowchart;
    public Text timeText;

    void Start()
    {
        _timeleft = TIME;
        KeyName = KeyNameText.text.ToString();
    }

    void Update ()
    {
        if (_timeleft > 0)
        {
            _time += Time.deltaTime;
            fillAmount += Time.deltaTime / TIME;
            _timeleft = (Mathf.Round((TIME - _time) * 100f)) / 100f;

            timeText.text = _timeleft.ToString();
            if (Input.GetKeyDown(KeyName))
            {
                correctness = true;
                _timeleft = -1;
            }
            else if (Input.anyKeyDown)
            {
                correctness = false;
                _timeleft = -1;
            }

            GetComponent<Image>().fillAmount = fillAmount;
        }
        else if (correctness)
        {
            timeText.text = "PASS";
            flowchart.SetBooleanVariable("QTEvar", correctness);
            flowchart.ExecuteBlock("pass");
        }
        else
        {
            timeText.text = "FAIL";
            flowchart.SetBooleanVariable("QTEvar", correctness);
            flowchart.ExecuteBlock("lose");
        }
    }
}
