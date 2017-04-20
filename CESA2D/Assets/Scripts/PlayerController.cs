/// <author> Takayoshi Ogawa </author>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private GamePad.Index _gamepadNumber;
    
    private GamepadState _gamepadState;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update() {
        // ゲームパッドを取得
        _gamepadState = GetGamePad(_gamepadNumber);

        // ゲームパッド入力の処理群
        if(_gamepadState != null)
        {
            // Aボタンで処理
            if (_gamepadState.A)
            {
                Debug.Log("A");
                
            }
            // Bボタンで処理
            else if (_gamepadState.B)
            {
                Debug.Log("B");
            }
            // Xボタンで処理
            else if (_gamepadState.X)
            {
                Debug.Log("X");
            }
            // Yボタンで処理
            else if (_gamepadState.Y)
            {
                Debug.Log("Y");
            }
        }
    }

    GamepadState GetGamePad(GamePad.Index index)
    {
        if(index != GamePad.Index.Any)
        {
            return GamePad.GetState(index);
        }
        return null;
    }
}
