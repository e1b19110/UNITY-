uusing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class majo : MonoBehaviour
{

    Rigidbody2D rbody;// Rigidbody2D 型の変数(majo)
    float Bottun = 0.0f;             // 入力
    public float speed = 6.0f;      // 移動速度






    //ゲーム開始時に一度だけ行う処理
    void Start()
    {
        // Rigidbody2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>();
    }





    //フレームごとに行う関数(時間間隔は不均一)
    void Update()
    {

        // 水平方向の入力をチェックする
        Bottun = Input.GetAxisRaw("Horizontal");
        // 向きの調整
        if (Bottun > 0.0f)
        {

            transform.localScale = new Vector2(1, 1);
        }
        else if (Bottun < 0.0f)
        {

            transform.localScale = new Vector2(-1, 1);   // 左右反転させる
        }


    }

    //フレームごとに行う関数(時間間隔は均一)
    void FixedUpdate()
    {


        if (Bottun != 0)
        {

            // 速度を更新する
            rbody.velocity = new Vector2(speed * Bottun, rbody.velocity.y);
        }

    }





}

