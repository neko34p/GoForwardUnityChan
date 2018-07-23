using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    /// <summary>キューブの移動速度</summary>
    private float speed = -0.2f;
    /// <summary>消滅位置</summary>
    private float deadline = -10;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;
    }

    // Update is called once per frame
    void Update () {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);
        //画面外に出たら破棄する
        if(transform.position.x < this.deadline)
        {
            Destroy(gameObject);
        }
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "UnityChanTag")
        {
            audioSource.volume = 0;
        }
        else if (other.gameObject.tag == "CubeTag"
            || other.gameObject.tag == "GroundTag")
        {
            audioSource.Play();
        }
    }
}
