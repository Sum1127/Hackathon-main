using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushToLoadScene : MonoBehaviour
{
    [SerializeField] string _sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _ChangeScene()
    {
        SceneManager.LoadScene( _sceneName );
    }
}
