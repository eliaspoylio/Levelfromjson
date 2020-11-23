using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObstacle;
    public GameObject enemyBg;
    public GameObject enemyBg1;
    public TextAsset obstacleJson;
    public TextAsset bgJson;
    public TextAsset bgJson1;
    JSONNode obstacleData;
    JSONNode bgData;
    JSONNode bgData1;

    private float waitTime = 1.0f;
    private float timer = 0.0f;
    int size;

    // Start is called before the first frame update
    void Start()
    {
        string obstacleString = obstacleJson.text;
        obstacleData = JSON.Parse(obstacleString);
        string bgString = bgJson.text;
        bgData = JSON.Parse(bgString);
        string bgString1 = bgJson1.text;
        bgData1 = JSON.Parse(bgString1);

        size = obstacleData.Count;
        Debug.Log("size " + size);

        //Debug.Log(obstacleData.Count);
        //Debug.Log(obstacleData[0].Count);
        /*
        for (int i = 0; i < obstacleData.Count; i++)
        {

            for (int j = 0; j < obstacleData[i].Count; j++)
            {
                if (obstacleData[i][j])
                {
                    Instantiate(enemyObstacle, new Vector3((j- obstacleData[j].Count/2)+0.5f, obstacleData.Count+14 - i, 0), Quaternion.identity);
                }
            }

        }

        for (int i = 0; i < bgData.Count; i++)
        {
            for (int j = 0; j < bgData[i].Count; j++)
            {
                if (bgData[i][j])
                {
                    Instantiate(enemyBg, new Vector3((j - bgData[j].Count / 2) + 0.5f, bgData.Count + 14 - i, 0), Quaternion.identity);
                }
            }

        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        LineByLine();
    }

    private void LineByLine()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Debug.Log(obstacleData[size]);

            for (int j = 0; j < bgData1[size].Count; j++)
            {
                if (bgData1[size][j])
                {
                    Instantiate(enemyBg1, new Vector3((j - bgData1[j].Count / 2) + 0.5f, 14, 0), Quaternion.identity);
                }
            }

            for (int j = 0; j < bgData[size].Count; j++)
            {
                if (bgData[size][j])
                {
                    Instantiate(enemyBg, new Vector3((j - bgData[j].Count / 2) + 0.5f, 14, 0), Quaternion.identity);
                }
            }

            for (int j = 0; j < obstacleData[size].Count; j++)
            {
                if (obstacleData[size][j])
                {
                    Instantiate(enemyObstacle, new Vector3((j - obstacleData[j].Count / 2) + 0.5f, 14, 0), Quaternion.identity);
                }
            }

            size = size-1;
            Debug.Log("size " + size);
            timer = timer - waitTime;
        }
    }
}
