using System;
using System.IO;
using UnityEngine;
//Json ����
//������Ʈ�� ������ "key" , "value"�� ���·� �����ؼ� �������ִ� ����(format)[����]

//������ �������δ� json vs xml

public class JsonExample : MonoBehaviour
{

    [Serializable]
    //Json -> class�� ���·� �о ����
    public class ExampleData
    {
        public int idx;
        public string contents;
        public string desc;
        public string[] items;
    }

    [Serializable]
    public class Tip
    {
        public int idx;
        public string contents;
        public string desc;
    }

    [Serializable]
    public class TipData
    {
        public Tip[] tip;   
    }


    public ExampleData data;
    public TipData tipData;

    [ContextMenu("�� �ε�")]
    public void LoadTips()
    {
        //string path = "Assets/Resources/data.json";
        //string json = File.ReadAllText(path);
        //tipData = JsonUtility.FromJson<TipData>(json);

        //���ҽ� ���� ��ġ���� �ε��ϱ�
        var jsonFile = Resources.Load<TextAsset>("data");
        //json ������ Assets���� TextAsset�� ó���˴ϴ�.
        tipData = JsonUtility.FromJson<TipData>(jsonFile.text);

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this); //����Ƽ �����Ϳ����� ���� ���� ����
        #endif


    }



    [ContextMenu("������ ���̺�")]
    //Ŭ���� �����͸� Json ���Ͽ� �����մϴ�.
    void SaveData()
    {
        //JsonUtility�� ����Ƽ���� �������ִ� Json �۾��� ����
        //����ϴ� Ŭ�����Դϴ�.
        string jsonData = JsonUtility.ToJson(data,true);
        //��� ����
        //Application.dataPath (������Ʈ�� ���� ����)
        //Application.streamingAssetsPath(Assets + StreamingAssets)
        //Application.persistentDataPath : �� �ü������ ����ϴ� �б�/���� ������ ������ ���
        //�ַ� �ȵ���̵尰�� ����� ȯ�濡�� ���⸦ �����ؾ��ϴ� ��� ���� ���Ǵ� ���

        string path = Path.Combine(Application.dataPath + "/Data", "data.json");
         
        //���� ��ü �ۼ�
        File.WriteAllText(path, jsonData);

        Debug.Log("�ۼ��� �����Ͱ� �������ϴ�.");
    }
    [ContextMenu("������ �ε�")]
    //Json ������ �̿��� Ŭ���� ������ �ε��մϴ�.
    void LoadData()
    {
        string path = Path.Combine(Application.dataPath + "/Data", "data.json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<ExampleData>(jsonData);
    }

}
