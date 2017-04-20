using UnityEngine;
using GamepadInput;


public class ControllerInput
{
    private GamepadState _inputState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _inputState = GamePad.GetState(0, false);
	}

    GamepadState GetGamePad(GamePad.Index index)
    {
        if (index != GamePad.Index.Any)
        {
            // Any以外のゲームパッド状態を返す
            return GamePad.GetState(index, false);
        }
        return null;
    }
}
