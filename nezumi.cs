using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーンの切り替えに必要

public class nezumi : MonoBehaviour
{
    public string sceneName; // 読み込むシーン名

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {




       

        if (collision.gameObject.tag == "Finish")
        {
            GameOver();
        }




    }



    // ゲームオーバー
    public void GameOver()
    {


        Load(); // ゲーム停止


    }
    
    // シーンを読み込む
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}


