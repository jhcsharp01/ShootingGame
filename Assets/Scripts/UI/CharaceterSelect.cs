using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterTYPE
{
    RED, BLUE, GREEN, ORANGE
}


public class CharaceterSelect : MonoBehaviour
{
    public GameObject selectCharacter;
    public GameObject prefab;
    public Texture2D[] Texture2D;

    public CharacterTYPE characterType;

    public GameObject LButton;
    public GameObject RButton;

    public void onRButtonClick()
    {
        characterType++;
        selectCharacter.GetComponent<Material>().SetTexture("_BaseMap", Texture2D[(int)characterType]);
    }
    private void Start()
    {
        RButton.GetComponent<Button>().onClick.AddListener(onRButtonClick);
    }
    // Update is called once per frame
    void Update()
    {
                
    }
}
