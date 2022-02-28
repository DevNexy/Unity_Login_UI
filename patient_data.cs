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
    
    //white 스크롤뷰
    public GameObject w_list_prefab; //list 프리팹
    public Transform w_list_prefab_parent; //list 프리팹 부모(content)
    public Text w_number_text; // 리스트에 추가된 number
    public Text w_name_text; //추가된 name
    public Text w_birth_text; //추가된 birth
    public Text w_date_text; //date

    //blue 스크롤뷰
    public GameObject b_list_prefab;
    public Transform b_list_prefab_parent;
    public Text b_number_text;
    public Text b_name_text;
    public Text b_birth_text;
    public Text b_date_text;

    public Text created_text;
    public Text updated_text;
    int num = 0;

    //프리팹 배열 공간
    GameObject[] patient_item = new GameObject[100];

    //list
    List<int> numbers = new List<int> (); //환자 번호
    List<string> names = new List<string>(); //환자 이름
    List<string> births = new List<string>(); //환자 생년월일
    List<string> dates = new List<string>(); //방문 시간 현재 시간으로
   
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        current_time.text = GetCurrentDate(); //상단에 현재 시간 표시
    }
    //Name 이나 Date Of Birth 에 값을 입력 후
    //Search 버튼 클릭하면 Patient List에 환자 정보 갱신
    public void SearchBtn()
    {
        for(int i = 0; i< patient_item.Length; i++)
        {
            Destroy(patient_item[i]); //배열에 담긴 모든 프리팹 삭제
        }
        int names_idx = names.IndexOf(search_name.text); //검색한 이름 인덱스 찾기
        int birth_idx = births.IndexOf(search_birth.text); //검색한 생년월일 인덱스 찾기
        
        //검색한 이름의 프리팹 생성
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
        //환자 정보 리스트로 추가
        numbers.Add(num+1);
        names.Add(generate_name.text);
        births.Add(generate_birth.text);
        dates.Add(GetVisitedDate());

        Debug.Log(numbers[num]);
        Debug.Log(names[num]);
        Debug.Log(births[num]);
        Debug.Log(dates[num]);
        
        //스크롤 뷰 아이템의 색상을 번갈아가며 보여주기 위함
        //ex.. 첫 번째는 하얀색, 두 번째는 하늘색. 번갈아서
        if (num % 2 == 0)
        {
            //아이템에 해당되는 텍스트
            //No., Name, Data Of Birth, Last Visited At
            w_number_text.text = numbers[num].ToString();
            w_name_text.text = names[num];
            w_birth_text.text = births[num];
            w_date_text.text = dates[num];
            created_text.text = "Created At | " +GetVisitedDate();
            updated_text.text = "Updated At | " +GetVisitedDate();
            patient_item[num] = Instantiate(w_list_prefab, w_list_prefab_parent); //프리팸으로 생성
        }
        else
        {
            b_number_text.text = numbers[num].ToString();
            b_name_text.text = names[num];
            b_birth_text.text = births[num];
            b_date_text.text = dates[num];
            created_text.text = "Created At | " + GetVisitedDate();
            updated_text.text = "Updated At | " + GetVisitedDate();
            patient_item[num] = Instantiate(b_list_prefab, b_list_prefab_parent); //프리팹으로 생성
        }
        
        num++; // 버튼 누른 횟수
    }
    //각 Item 의 Edit, Del 버튼 클릭 시 Debug에 버튼 이름과 Item 정보 표시
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