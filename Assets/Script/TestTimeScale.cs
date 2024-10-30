using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestTimeScale : MonoBehaviour
{
    public int continue_count;

    // Start is called before the first frame update
    void Start()
    {
        continue_count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.sceneLoaded += KeepCount;
    }

    public void OnClick()
    {
        continue_count++;
        Debug.Log("continue" + continue_count);
        Time.timeScale = 1.0f;
        Debug.Log("����߂���");
    }
    void KeepCount(Scene next, LoadSceneMode mode)
    {
        // ���̃V�[���̒��ɂ���I�u�W�F�N�g���擾
        // ���̃I�u�W�F�N�g�ɕt������Ă���X�N���v�g���擾
        if (GameObject.Find("clearscore") == null) return;
        var result = GameObject.Find("clearscore").GetComponent<result>();

        result.continue_count = continue_count;


        // �C�x���g�̍폜
        SceneManager.sceneLoaded -= KeepCount;
    }
}
