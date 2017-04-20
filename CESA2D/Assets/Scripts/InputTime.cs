using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTime : MonoBehaviour
{
    public float _maxTime = 1.0f;

    private Image _timeBar;
    private float _time;
    
	// Use this for initialization
	void Start () {
        _timeBar = transform.GetChild(0).GetComponent<Image>();
        _maxTime *= 60.0f;
        _time /= _maxTime;
	}
	
	// Update is called once per frame
	void Update () {
        _time++;

        _timeBar.fillAmount = _time/_maxTime;
        if (_time >= _maxTime)
        {
            _maxTime = 0;
            _timeBar.color = Color.green;
        }
		
	}
}
