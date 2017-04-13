/// <author> Takayoshi Ogawa </author>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public Vector3 velocity;

    private RigidbodyCharacter _character;

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
        // ゲームパッド入力の処理群
        {
        }
        // キーボード入力の処理群
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
        }

        // ここでまとめてキャラクターの移動処理を計算する
        _character.Move(velocity, _character.moveSpeed);
    }
}
