using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_ctrl : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        StartCoroutine(ChangeLogin());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    IEnumerator ChangeLogin()
    {
        yield return new WaitForSeconds(4); //4�ʵڿ�
        SceneManager.LoadScene("login"); //�α��� ������ ����ȯ
    }
}
