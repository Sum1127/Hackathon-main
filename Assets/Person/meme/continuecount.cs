using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class continuecount : MonoBehaviour
{
    private int continue_count;

    
    // Start is called before the first frame update
    void Start()
    {
        continue_count = 1;
    }

    private void OnClickContinueButton()
    {
        continue_count++;
        Debug.Log("continue" + continue_count);
    }
    void KeepScore(Scene next, LoadSceneMode mode)
    {
        // ���̃V�[���̒��ɂ���I�u�W�F�N�g���擾
        // ���̃I�u�W�F�N�g�ɕt������Ă���X�N���v�g���擾
        var result = GameObject.Find("clearscore").GetComponent<result>();

        result.continue_count = continue_count;


        // �C�x���g�̍폜
        SceneManager.sceneLoaded -= KeepScore;
    }
}
