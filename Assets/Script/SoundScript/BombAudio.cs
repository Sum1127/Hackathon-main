using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAudio : MonoBehaviour
{
    private AudioSource Audio;//AudioSource������
    bool isAudioPlay = false; //�Đ������ǂ����̔���
    void Start()
    {
        Audio = GetComponent<AudioSource>();//AudioSource�̎擾
        Audio.Play();//AudioSource���Đ�
        isAudioPlay = true;//���ʉ��̍Đ��𔻒�
    }
    void Update()
    {
        if (!Audio.isPlaying && isAudioPlay)
        //�Ȃ��Đ�����Ă��Ȃ����A���ʉ����Đ�����Ă��鎞
        {
            Destroy(gameObject);//�I�u�W�F�N�g������
        }
    }
}
