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
        // 次のシーンの中にあるオブジェクトを取得
        // そのオブジェクトに付加されているスクリプトを取得
        var result = GameObject.Find("clearscore").GetComponent<result>();

        result.continue_count = continue_count;


        // イベントの削除
        SceneManager.sceneLoaded -= KeepScore;
    }
}
