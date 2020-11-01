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
        //string JSONToParse = "{\"values\":" + jsonString + "}";
        //Debug.Log(JSONToParse);
        //CRoot root = JsonUtility.FromJson<CRoot>(JSONToParse);
        //Debug.Log(data[1][6]);
        //JSONArray yarray = data.AsArray;
        //Debug.Log(yarray[1][6]);
        //Debug.Log(yarray[1][6]);
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
        //int sizeX = data[0].Count;
        //int sizeY = data.Count;
        //Tiles(sizeX, sizeY);
        //ReadString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Tiles(){
        // Instantiate at position (0, 0, 0) and zero rotation.
        for (int i = 0; i < 10; i++)
        {
            Instantiate(myPrefab, new Vector3(i, 0, 0), Quaternion.identity);
        }

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
