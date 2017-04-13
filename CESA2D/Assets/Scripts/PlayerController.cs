/// <author> Takayoshi Ogawa </author>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public Vector3 velocity;

    [SerializeField]
    private GamePad.Index _gamepadNumber;

    private RigidbodyCharacter _character;
    private GamepadState _gamepadState;

	// Use this for initialization
	void Start () {
        // タグを強制的に設定
        tag = "Player";
        // 移動速度の初期化
        velocity = Vector3.zero;
        // キャラクター制御のスクリプトを取得
        _character = GetComponent<RigidbodyCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
        // ゲームパッドを取得
        _gamepadState = GetGamePad(_gamepadNumber);

        // ゲームパッド入力の処理群
        if(_gamepadState != null)
        {
            // 左スティックで移動処理
            velocity.x = _gamepadState.LeftStickAxis.x;

            // Aボタンで跳躍処理
            if (_gamepadState.A)
            {
                _character.Jump(_character.jumpPower);
            }

            // 左肩ボタンで重力反転
            if(_gamepadState.LeftShoulder)
            {
                _character.InvertGravity();
            }
        }
        // キーボード入力の処理群
        else
        {
            // ADキーで移動処理
            if (Input.GetKey(KeyCode.A))
            {
                velocity = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                velocity = Vector3.right;
            }
            else
            {
                velocity = Vector3.zero;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // SPACEキーで跳躍処理
                _character.Jump(_character.jumpPower);
            }

            // Zキーで重力反転
            if(Input.GetKeyDown(KeyCode.Z))
            {
                _character.InvertGravity();
            }
        }

        // ここでまとめてキャラクターの移動処理を計算する
        _character.Move(velocity, _character.moveSpeed);
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
