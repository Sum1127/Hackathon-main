using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAudio : MonoBehaviour
{
    private AudioSource Audio;//AudioSourceを入れる
    bool isAudioPlay = false; //再生中かどうかの判定
    void Start()
    {
        Audio = GetComponent<AudioSource>();//AudioSourceの取得
        Audio.Play();//AudioSourceを再生
        isAudioPlay = true;//効果音の再生を判定
    }
    void Update()
    {
        if (!Audio.isPlaying && isAudioPlay)
        //曲が再生されていない時、効果音が再生されている時
        {
            Destroy(gameObject);//オブジェクトを消す
        }
    }
}
