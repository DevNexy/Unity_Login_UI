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
    //�´� id, pw �Է� �� Login ��ư Ŭ����, �����â�� "id, pw �α��� ����" ǥ��
    public void LoginBtn()
    {
        if (inputField_ID.text == user && inputField_PW.text == password)
        {
            Debug.Log("id, pw �α��� ����!");
            SceneManager.LoadScene("main"); //main ������ �� ��ȯ
        }
        else
        {
            Debug.Log("�α��� ����");
            forget_text.gameObject.SetActive(true); //'Forgot username or password?' ǥ��
        }
    }
    //Register ��ư Ŭ�� ��, ���ͳݺ����� â ���� google.com ����
    public void RegisterBtn()
    {
        Application.OpenURL("https://www.google.co.kr/");
    }
}
