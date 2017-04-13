using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject baggage;

    [SerializeField]
    private float interval = 1F;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var hoge1 = baggage.transform.position.x - player1.transform.position.x;
        var hoge2 = baggage.transform.position.x - player2.transform.position.x;

        //プレイヤー同士のX軸がオブジェクトのX軸と近ければ動く
        if((hoge1 >= -interval && hoge1 <= interval) && (hoge2 >= -interval && hoge2 <= interval))
        {
            baggage.transform.position = new Vector3(player1.transform.position.x, 0F, -1F);
        }
	}

    private void OnGoal() {
        Debug.Log("Goal");
    }
}
