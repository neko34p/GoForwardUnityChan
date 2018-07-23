using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
    Animator animator;
    Rigidbody2D rigid2D;
    /// <summary>地面の位置</summary>
    private float groundLevel = -3.0f;
    /// <summary>ジャンプの速度の減衰</summary>
    private float dump = 0.8f;
    /// <summary>ジャンプの速度</summary>
    float jumpVelocity = 20;
    /// <summary>ゲームオーバーになる位置</summary>
    private float deadLine = -9;

    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        // 走るアニメーションを再生するために、Animatorのパラメータを調整する
        this.animator.SetFloat("Horizontal", 1);
        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
        // ジャンプ状態のときはボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        // 着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        // クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
        //　デッドラインを超えた場合ゲームオーバーにする
        if(transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
        }
    }
}
