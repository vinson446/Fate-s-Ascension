using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
