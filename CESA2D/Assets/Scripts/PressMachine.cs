//------------------------------
//@! IRFAN FAHMI RAMADHAN
//@! PressMachine.cs
//@! 2017/4/18
//------------------------------
using UnityEngine;

public class PressMachine : MonoBehaviour
{
    [SerializeField] private float _speed = 5;          //初期速度
    [SerializeField] private float _waitTime = 1;       //待つ時間
    [SerializeField] private float _backSpeed = 3;      //プレス機の戻る速度

    private float _movement;                            //速度
    private float _time = 0;                            //時間
    private Vector2 _startPos;                          //初期座標
    
    public bool actived = false;                        //起動してるかないか
    public bool hitPlayer = false;                      //プレイヤーに当たるかないか

    // Use this for initialization
    void Start ()
    {
        //座標を初期化する
        _startPos = transform.position;
        //BoxCollide2Dを有効する
        GetComponent<BoxCollider2D>().isTrigger = true;
        _movement = _speed;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_movement == 0)
        {
            //時間を加算する
            _time++;
        }
        //待つ時間までたったらもどす
        if (_time >= _waitTime * 60)
        {
            _movement = _speed;
            actived = false;
            _time = 0;
        }

        //Activeしたらプレス機を動かすそうじゃないと元のところに戻す
        if (actived)
            transform.position = Vector2.MoveTowards(transform.position, transform.position - Vector3.right * 5, _movement * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, _startPos, _backSpeed * Time.deltaTime);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //お互いのプレス機が挟んだらプレス機をもとのことろに戻す
        if(collision.gameObject.tag == "PressMachine")
        {
            if (actived)
            {
                //一時動きを止める
                _movement = 0; 
            }
            
        }
        //プレイヤーに当たったフラグ
        if(collision.gameObject.tag == "Player")
        {
            hitPlayer = true;
        }
    }
}
