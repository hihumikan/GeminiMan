using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    private bool first = false;
    public void PressStart()
    {
        Debug.Log("Start");
        if(!first)
        {
            Debug.Log("First");
            first = true;
            SceneManager.LoadScene("Setumei");
        }
    }
        void Update()
    {
        //エンターキーが入力された場合「true」
        if (Input.GetKey(KeyCode.Return)){
            //オブジェクトを削除
            SceneManager.LoadScene("Setumei");
        }
        if(Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Setumei");
    }
    public void EndGame()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
