using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetumeiButton : MonoBehaviour
{
    public void OnClickHogeButton()
    {
        SceneManager.LoadScene("hoge");
    }
    void Update()
    {
        //エンターキーが入力された場合「true」
        if (Input.GetKey(KeyCode.T)){
            //オブジェクトを削除
            SceneManager.LoadScene("hoge");
        }
    }
}
