using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class patient_data : MonoBehaviour
{
    public InputField search_name;
    public InputField search_birth;
    public InputField generate_name;
    public InputField generate_birth;
    public Text current_time;
    
    //white ��ũ�Ѻ�
    public GameObject w_list_prefab; //list ������
    public Transform w_list_prefab_parent; //list ������ �θ�(content)
    public Text w_number_text; // ����Ʈ�� �߰��� number
    public Text w_name_text; //�߰��� name
    public Text w_birth_text; //�߰��� birth
    public Text w_date_text; //date

    //blue ��ũ�Ѻ�
    public GameObject b_list_prefab;
    public Transform b_list_prefab_parent;
    public Text b_number_text;
    public Text b_name_text;
    public Text b_birth_text;
    public Text b_date_text;

    public Text created_text;
    public Text updated_text;
    int num = 0;

    //������ �迭 ����
    GameObject[] patient_item = new GameObject[100];

    //list
    List<int> numbers = new List<int> (); //ȯ�� ��ȣ
    List<string> names = new List<string>(); //ȯ�� �̸�
    List<string> births = new List<string>(); //ȯ�� �������
    List<string> dates = new List<string>(); //�湮 �ð� ���� �ð�����
   
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        current_time.text = GetCurrentDate(); //��ܿ� ���� �ð� ǥ��
    }
    //Name �̳� Date Of Birth �� ���� �Է� ��
    //Search ��ư Ŭ���ϸ� Patient List�� ȯ�� ���� ����
    public void SearchBtn()
    {
        for(int i = 0; i< patient_item.Length; i++)
        {
            Destroy(patient_item[i]); //�迭�� ��� ��� ������ ����
        }
        int names_idx = names.IndexOf(search_name.text); //�˻��� �̸� �ε��� ã��
        int birth_idx = births.IndexOf(search_birth.text); //�˻��� ������� �ε��� ã��
        
        //�˻��� �̸��� ������ ����
        if (names_idx % 2 == 0 || birth_idx % 2 == 0)
        {
            patient_item[names_idx] = Instantiate(w_list_prefab, w_list_prefab_parent);
        }
        else
        {
            patient_item[names_idx] = Instantiate(b_list_prefab, b_list_prefab_parent);
        }
    }
    public void GenerateBtn()
    {
        //ȯ�� ���� ����Ʈ�� �߰�
        numbers.Add(num+1);
        names.Add(generate_name.text);
        births.Add(generate_birth.text);
        dates.Add(GetVisitedDate());

        Debug.Log(numbers[num]);
        Debug.Log(names[num]);
        Debug.Log(births[num]);
        Debug.Log(dates[num]);
        
        //��ũ�� �� �������� ������ �����ư��� �����ֱ� ����
        //ex.. ù ��°�� �Ͼ��, �� ��°�� �ϴû�. �����Ƽ�
        if (num % 2 == 0)
        {
            //�����ۿ� �ش�Ǵ� �ؽ�Ʈ
            //No., Name, Data Of Birth, Last Visited At
            w_number_text.text = numbers[num].ToString();
            w_name_text.text = names[num];
            w_birth_text.text = births[num];
            w_date_text.text = dates[num];
            created_text.text = "Created At | " +GetVisitedDate();
            updated_text.text = "Updated At | " +GetVisitedDate();
            patient_item[num] = Instantiate(w_list_prefab, w_list_prefab_parent); //���������� ����
        }
        else
        {
            b_number_text.text = numbers[num].ToString();
            b_name_text.text = names[num];
            b_birth_text.text = births[num];
            b_date_text.text = dates[num];
            created_text.text = "Created At | " + GetVisitedDate();
            updated_text.text = "Updated At | " + GetVisitedDate();
            patient_item[num] = Instantiate(b_list_prefab, b_list_prefab_parent); //���������� ����
        }
        
        num++; // ��ư ���� Ƚ��
    }
    //�� Item �� Edit, Del ��ư Ŭ�� �� Debug�� ��ư �̸��� Item ���� ǥ��
    public void WEditBtn()
    {
        Debug.Log("Info: Edit Button" +
            ",  Number :" + w_number_text.text +
            ",  Name : " + w_name_text.text +
            ",  Date Of Birth : " + w_birth_text.text +
            ",  Last Visited At : " + w_date_text.text);
    }
    public void WDelBtn()
    {
        Debug.Log("Info: Del Button" + 
            ",  Number :" + w_number_text.text + 
            ",  Name : "+w_name_text.text +
            ",  Date Of Birth : " +w_birth_text.text +
            ",  Last Visited At : "+ w_date_text.text);
    }
    public void BEditBtn()
    {
        Debug.Log("Info: Edit Button" +
            ",  Number :" + b_number_text.text +
            ",  Name : " + b_name_text.text +
            ",  Date Of Birth : " + b_birth_text.text +
            ",  Last Visited At : " + b_date_text.text);
    }
    public void BDelBtn()
    {
        Debug.Log("Info: Del Button" +
            ",  Number :" + b_number_text.text +
            ",  Name : " + b_name_text.text +
            ",  Date Of Birth : " + b_birth_text.text +
            ",  Last Visited At : " + b_date_text.text);
    }
    public string GetVisitedDate()
    {
        return DateTime.Now.ToString(("yyyy-MM-dd tt HH:mm:ss"));
    }
    public string GetCurrentDate()
    {
        return DateTime.Now.ToString(("yyyy.MM.dd | tt HH:mm:ss"));
    }
}