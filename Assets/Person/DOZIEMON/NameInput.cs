using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI text;
    public string name;

    void Start()
    {
        inputField = inputField.GetComponent<TMP_InputField>();
        text = text.GetComponent<TextMeshProUGUI>();
        inputField.onEndEdit.AddListener(OnInputEnd);
    }

    // Update is called once per frame
    public void OnInputEnd(string inputField) { 
        text.text = inputField;
        name = inputField;
        Debug.Log("ユーザーが入力したテキスト: " + inputField);
    }
}
