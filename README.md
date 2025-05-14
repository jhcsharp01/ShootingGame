![image](https://github.com/user-attachments/assets/8cbf0eb2-7965-4725-94cf-d387fe975216)![image](https://github.com/user-attachments/assets/0d20be69-e803-4367-ac94-7599fe1f8e67)# ShootingGame
3D ShootingGame

# 목차
1. [1일차](#1일차)
2. [2일차](#2일차)

4. [사용 에셋](#사용-에셋)
5. [추가 공부 내역](#추가-공부-내역)

# 1일차
---
1) 큐브 생성 , 플레이어 움직임 기능 추가
   1) Create -> 3D -> Cube
   2) Create -> MonoBehaviour Script -> PlayerMovement.cs
   3) Cube -> Add Component(PlayerMovement.cs)
![image](https://github.com/user-attachments/assets/311210ec-5626-4c81-987f-d444a8bbb792)
<br><br><br>
2) 총알 생성
![image](https://github.com/user-attachments/assets/07653625-4716-4224-9321-243a02b9dbd1)
<br><br><br>

  총알 계층 구조
![image](https://github.com/user-attachments/assets/5f6115e8-ccd3-41b6-9807-fa19731f7791)
<br><br><br>

총알, 실린더 트랜스폼
![image](https://github.com/user-attachments/assets/ec1ef03a-8d56-4e84-a9c1-ecd73fea6ce6)
<br><br><br>
![image](https://github.com/user-attachments/assets/df376a7d-d2d6-4eee-ac58-acfbcf92ca4f)


 BulletIn(Material)
 ![image](https://github.com/user-attachments/assets/fe467e6c-f6b1-48a0-9775-2354c52b7473)
<br><br><br>

3) 총알 발사대 구현
   1) Player
        -> Fire
   2) Player -> AddComponent -> PlayerFire.cs
      
![image](https://github.com/user-attachments/assets/7a73c998-c631-4dfe-b271-7ec50a2f673a)
<br><br><br>
에셋 적용 후
![image](https://github.com/user-attachments/assets/3865d76f-ac36-441c-9170-933a9036c4f4)

<br><br><br>
4) 레이어 설정
   ![image](https://github.com/user-attachments/assets/ad6e94e6-fc63-4033-b4bc-ff9c18803cb9)
<br><br><br>

6) 레이어 충돌 매트릭스 설정
![image](https://github.com/user-attachments/assets/c515b11f-8d18-454e-88cb-d590b58f456c)
<br><br><br>


# 사용 에셋
## 캐릭터
https://assetstore.unity.com/packages/3d/vehicles/air/awesome-cartoon-airplanes-56715
## 배경
https://assetstore.unity.com/packages/2d/textures-materials/space-star-field-backgrounds-109689

# 추가 공부 내역
2025-05-14
```cs
using System;
using UnityEngine;

[Serializable] //클래스나 구조체를 인스펙터에 표시합니다.
public class Data
{
    [Range(1,5)] public int value;    // 범위를 설정합니다. (슬라이더 형식으로 표현)
    [Multiline(5)] public string s;   // 문자열 작성의 라인 수를 증가시켜줍니다.
    [TextArea(3, 5)] public string s2; //문자열 작성의 최소 라인과 최대 라인을 설정합니다.
    
    [SerializeField] float f; //필드를 인스펙터에 표시합니다.
    
    [Tooltip("게임 오브젝트")] public GameObject gameObject; //변수에 마우스를 가져다대면 툴팁이 뜸.
}
public class NotSerial
{
    [Range(1, 5)] public int value;    // 범위를 설정합니다. (슬라이더 형식으로 표현)
    [Multiline(5)] public string s;   // 문자열 작성의 라인 수를 증가시켜줍니다.
    [TextArea(3, 5)] public string s2; //문자열 작성의 최소 라인과 최대 라인을 설정합니다.
    [Multiline(3)][ContextMenuItem("SetStory", "setStroy")] public string s3;
    [SerializeField] float f; //필드를 인스펙터에 표시합니다.
    [Space(10)] public bool ischeck; //적은 숫자만큼 간격을 가진 뒤 필드 표현
    [Tooltip("게임 오브젝트")] public GameObject gameObject; //변수에 마우스를 가져다대면 툴팁이 뜸.
}


//플래그 속성이 들어간 enum은 복수 선택이 가능합니다.
//ex) 카메라의 CullingMask를 보면 Everything, None , 여러개 선택 등을 할 수 있는데
//이 기능이 포함되서 가능하다.
//플래그 설정이 된 값들은 비트 연산을 통해서 칸 이동이 가능합니다.
[Flags]
public enum TYPE
{
    물 = 1,
    풀 = 2,
    전기 = 4,
    화염 = 8,
    고스트 = 16,
    에스퍼 = 32
}

//Add Component 버튼을 이용한 추가 기능 만들어짐
//메뉴의 Component 기능에 추가됩니다.
[AddComponentMenu("Sample/Sample")]
public class Sample : MonoBehaviour
{
    public Data data;
    public NotSerial serial;

    public TYPE type;

    [Multiline(3)][ContextMenuItem("SetStory", "setStory")] public string s3; 
    [Space(10)] public bool ischeck; //적은 숫자만큼 간격을 가진 뒤 필드 표현
    public void setStory()
    {
        s3 = "오늘은 날씨가 습하고 덥고 미치겠습니다.";
    }

    [ContextMenu("BoolCheck")]
    public void boolCheck()
    {
        if (ischeck)
        {
            ischeck = false;
        }
        else
        {
            ischeck = true;
        }
    }
}
```
