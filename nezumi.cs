using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���̐؂�ւ��ɕK�v

public class nezumi : MonoBehaviour
{
    public string sceneName; // �ǂݍ��ރV�[����

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



    // �Q�[���I�[�o�[
    public void GameOver()
    {


        Load(); // �Q�[����~


    }
    
    // �V�[����ǂݍ���
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}


