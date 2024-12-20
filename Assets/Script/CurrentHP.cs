using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentHP : MonoBehaviour
{
    public PlayerHP playerHP;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP != null && _textMeshPro != null)
        {
            // PlayerHealthから現在のHPを取得して表示
            int currentHp = playerHP.GetCurrentHP();
            _textMeshPro.text = "現在のHP:" + currentHp.ToString();
        }
    }
}
