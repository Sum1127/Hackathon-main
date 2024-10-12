using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        Debug.Log("‚Â‚¬‚Ö");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
