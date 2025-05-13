using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public Material characterMaterial; //캐릭터 머티리얼(적용 값)
    public List<Texture2D> textures;   //스킨 목록

    public Renderer SelectCharacter;   //화면에서 보이는 캐릭터
    public Button LButton, RButton, CButton; //버튼 연결(리스너 스크립트)

    private int idx = 0; //리스트의 인덱스 표현

    private void Start()
    {
        Apply(idx);

        LButton.onClick.AddListener(OnLButtonEnter);
        RButton.onClick.AddListener(OnRButtonEnter);
        CButton.onClick.AddListener(OnCButtonEnter);
    }

    public void OnLButtonEnter()
    {
        if(idx > 0)
        {
            idx--;
            Apply(idx);
            OnLRButtonExit();
        }
        else
        {
            Debug.Log("범위 이탈");
        }
    }

    private void OnLRButtonExit()
    {
        LButton.interactable = idx > 0;
        RButton.interactable = idx < textures.Count - 1;
    }

    public void OnRButtonEnter()
    {
        if (idx < textures.Count-1)
        {
            idx++;
            Apply(idx);
            OnLRButtonExit();
        }
        else
        {
            Debug.Log("범위 이탈");
        }
    }

    public void OnCButtonEnter()
    {
        characterMaterial.SetTexture("_BaseMap", textures[idx]);
        SceneManager.LoadScene("GameScene");
    }

    private void Apply(int index)
    {
        SelectCharacter.material.SetTexture("_BaseMap", textures[index]);
    }

}
