using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using System.Collections;
using UnityEngine.SceneManagement;


public class login_ctrl : MonoBehaviour
{
    public InputField inputField_ID;
    public InputField inputField_PW;
   
    public Text forget_text;

    //ID, PW
    private string user = "song";
    private string password = "1234";
    // Start is called before the first frame update
    void Start()
    {
        forget_text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //맞는 id, pw 입력 후 Login 버튼 클릭시, 디버그창에 "id, pw 로그인 성공" 표시
    public void LoginBtn()
    {
        if (inputField_ID.text == user && inputField_PW.text == password)
        {
            Debug.Log("id, pw 로그인 성공!");
            SceneManager.LoadScene("main"); //main 씬으로 씬 전환
        }
        else
        {
            Debug.Log("로그인 실패");
            forget_text.gameObject.SetActive(true); //'Forgot username or password?' 표시
        }
    }
    //Register 버튼 클릭 시, 인터넷브라우저 창 열고 google.com 띄우기
    public void RegisterBtn()
    {
        Application.OpenURL("https://www.google.co.kr/");
    }
}
