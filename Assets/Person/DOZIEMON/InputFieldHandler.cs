using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    public InputField inputField; // Input Fieldの参照を保持

    void Start()
    {
        // コードでイベントハンドラを登録
        inputField.onEndEdit.AddListener(OnInputEnd);
    }

    // ユーザーがテキストを入力確定した時に呼ばれる
    void OnInputEnd(string inputText)
    {
        Debug.Log("ユーザーが入力したテキスト: " + inputText);
    }
}
