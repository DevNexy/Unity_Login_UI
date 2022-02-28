# Unity_Login_UI

유니티 버전 2020.3.xx 이상 무관
UI 는 주모니터에 표시
화면비율 16:9
화면해상도 사용자 해상도에 맞춤,
현재 화면비율이 16:9가 아닐 시, UI 비율은 16:9 로 고정하고, 가로 세로에 여백 추가

화면1.splash 
4초후 자동으로 화면2.login 로 전환

화면2.login
id, pw 하드코딩하여,
맞는 id, pw 입력 후 Login 버튼 클릭시, 디버그창에 "id, pw 로그인 성공" 표시하고, 화면3.main 으로 전환
잘못된 id, pw 입력 시 Forgot username or password? 밑에 정보 표시
Register 버튼 클릭 시, 인터넷브라우저 창 열고 google.com 띄우기
Forgot username or password? 텍스트 클릭 시, 인터넷브라우저 창 열고 google.com 띄우기

화면3.main
Patient List Item 및 Assessment Data List 의 데이터는 휘발성으로(저장x)
Patient List, Assessment Data List 는 동적 리스트스크롤 형태로 생성
Generate Patient에 이름 생년월일 입력 후, Generate 버튼 누르면 Patient List에 입력한 환자 정보로 Item 생성, Patient List 갱신
Search Patient에 이름이나 생년월일로 검색하면 Patient List 갱신
Patient List Item 선택 시 해당하는 Assessment Data List 갱신
Assessment Data List에 Generate 버튼 추가, Generate 버튼 누르면 새 Assessment Data List Item생성, 
새 Assessment Data List Item 생성 시, Assessment Data Info 는 랜덤으로 체크,
Assessment Data List Item 선택 시 Assessment Data Info에 체크된 항목 o표시
각 Item 의 Edit, Del 버튼 클릭 시 Debug에 버튼 이름과 Item 정보 표시
