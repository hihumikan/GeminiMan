using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    void Update()
    {
        //エンターキーが入力された場合「true」
        if (Input.GetKey(KeyCode.T)){
            //オブジェクトを削除
            SceneManager.LoadScene("TitleScene");
        }
    }
}
