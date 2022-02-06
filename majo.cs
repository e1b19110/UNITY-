using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class majo : MonoBehaviour
{

    Rigidbody2D rbody;// Rigidbody2D 型の変数(majo)
    Rigidbody2D body;//Rigidbody2D 型の変数(nezumi)
    float Bottun = 0.0f;             // 入力
    public float speed = 6.0f;      // 移動速度



    // アニメーション変数
    Animator animator; // アニメーター
    string moveAnime = "move";
    string stopAnime = "stop";
    string nowAnime = "";
    string oldAnime = "";

    //音声変数
    AudioSource sound;
    public AudioClip effect;


    //ゲーム開始時に一度だけ行う処理
    void Start()
    {
        // Rigidbody2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>();

        // Animator を取ってくる
        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;

        // AudioSource を取ってくる
        sound = GetComponent<AudioSource>();
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



        if (Bottun == 0)
        {
            nowAnime = stopAnime;       // 停止中
        }
        else
        {
            nowAnime = moveAnime;       // 移動
        }




        if (nowAnime != oldAnime)
        {
           
            oldAnime = nowAnime;
            animator.Play(nowAnime);        // アニメーション再生
        }
        
    }



    // 接触開始
    private void OnCollisionEnter2D(Collision2D collision)
    {



        //接触ゲームとのタグがnezumiなら以下の処理を行う
        if (collision.gameObject.tag == "nezumi")
        {   
            //nezumiの体をとってくる
            body = collision.gameObject.GetComponent<Rigidbody2D>();

            //nezumiの体に与える力(ベクトル)を設定
            Vector2 force = 150 * (collision.gameObject.transform.position - this.transform.position); 
            
            //nezumiの体に力(ベクトル)を与える
            body.AddForce(force, ForceMode2D.Impulse);

            //設定したサウンドを再生
            sound.PlayOneShot(effect);
        }




    }
}

    
  
  