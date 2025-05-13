using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public Material characterMaterial;
    public List<Texture2D> textures;

    public Renderer SelectCharacter;
    public Button LButton, RButton, CButton;

    private int idx = 0;

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
            Debug.Log("¹üÀ§ ÀÌÅ»");
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
            Debug.Log("¹üÀ§ ÀÌÅ»");
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
