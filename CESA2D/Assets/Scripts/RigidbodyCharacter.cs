/// <author> Takayoshi Ogawa </author>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyCharacter : MonoBehaviour {

    public bool downGravity = true;
    public bool isGrounded = false;
    public float moveSpeed = 1F;
    public float jumpPower = 1F;

    [HideInInspector]
    public Vector3 gravity;
    [HideInInspector]
    public Vector3 velocity;

    private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        // オブジェクトの重力方向を設定
        gravity = -Physics.gravity;
        if(downGravity)
        {
            gravity *= -1F;
        }
        // 移動速度を初期化
        velocity = Vector3.zero;
        // 物理演算を取得
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
        // 接地していなければ重力方向へ落下
		if(!isGrounded)
        {
            _rigidbody.AddForce(gravity);
        }
	}

    private void FixedUpdate() {
        // Rigidbodyの移動処理を利用する
        _rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    public void Move(Vector3 v, float speed) {
        // 移動方向を計算して向きを設定
        velocity = v * speed;
        transform.LookAt(transform.position + velocity);
    }

    public void Jump(float power) {
        // 接地していたら上方向に跳躍
        if(isGrounded)
        {
            isGrounded = false;
            _rigidbody.AddForce(-gravity.normalized * power * 100F);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        // 自身の下方向に線を飛ばして接触したら接地
        if(Physics.Linecast(transform.position, gravity.normalized))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        // 接触していない場合は接地していない
        isGrounded = false;
    }
}
