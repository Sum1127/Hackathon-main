using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        // �G�f�B�^��ł̓���
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // �r���h���ꂽ�Q�[���̏I��
        Application.Quit();
#endif
    }
}
