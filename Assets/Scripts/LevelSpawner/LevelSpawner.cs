using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using System.Linq;

public class LevelSpawner : MonoBehaviour
{
    public GameObject myPrefab;
    public TextAsset myJson;

    // Start is called before the first frame update
    void Start()
    {
        string jsonString = myJson.text;
        JSONNode data = JSON.Parse(jsonString);
        Debug.Log(data.Count);
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data[i].Count; j++)
            {
                Debug.Log(data[i][j]);
                if (data[i][j])
                {
                    Instantiate(myPrefab, new Vector3(j, data.Count-i, 0), Quaternion.identity);
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    static void ReadString()
    {
        string path = "Assets/LevelData/note.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}
