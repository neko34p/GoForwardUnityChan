using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {
    /// <summary>キューブのPrefab</summary>
    public GameObject cubePrefab;
    /// <summary>時間計測用の変数</summary>
    private float delta = 0;
    /// <summary>キューブの生成間隔</summary>
    private float span = 1.0f;
    /// <summary>キューブの生成位置：X座標</summary>
    private float genPosX = 12;
    /// <summary>キューブの生成位置オフセットY</summary>
    private float offsetY = 0.3f;
    /// <summary>キューブの縦方向の間隔</summary>
    private float spaceY = 6.9f;
    /// <summary>キューブの生成位置オフセットX</summary>
    private float offsetX = 0.5f;
    /// <summary>キューブの縦方向の間隔</summary>
    private float spaceX = 0.4f;
    /// <summary>キューブの生成個数の上限</summary>
    private int maxBlockNum = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
        if(this.delta > this.span)
        {
            this.delta = 0;
            //生成するキューブ数をランダムに決める
            int n = Random.Range(1, maxBlockNum + 1);

            //指定した数だけキューブを生成する
            for (int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            //次のキューブまでの生成時間を決める
            this.span = this.offsetX + this.spaceX * n;
        }
    }
}
