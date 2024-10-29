using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    public InputField inputField; // Input Field�̎Q�Ƃ�ێ�

    void Start()
    {
        // �R�[�h�ŃC�x���g�n���h����o�^
        inputField.onEndEdit.AddListener(OnInputEnd);
    }

    // ���[�U�[���e�L�X�g����͊m�肵�����ɌĂ΂��
    void OnInputEnd(string inputText)
    {
        Debug.Log("���[�U�[�����͂����e�L�X�g: " + inputText);
    }
}
