using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CustomSpawner : MonoBehaviour
{
    private GameObject instantiatedObject;
    public GameObject enemyObstacle;
    public GameObject enemyBg;
    public GameObject enemyBg1;
    public TextAsset obstacleJson;
    public TextAsset bgJson;
    public TextAsset bgJson1;
    JSONNode obstacleData;
    JSONNode bgData;
    JSONNode bgData1;

    public float speed;
    private float waitTime;
    private float timer = 0.0f;
    int size;
    int counter;

    private IEnumerator coroutine;

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

        waitTime = 1f/speed;
}

    // Update is called once per frame
    void Update()
    {
        LineByLine();
    }

    //nämä omiksi methodeikseen että saa asetettua waitTimen
    private void LineByLine()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {

            for (int j = 0; j < bgData1[size].Count; j++)
            {
                if (bgData1[size][j])
                {
                    instantiatedObject = Instantiate(enemyBg1, new Vector3((j - bgData1[j].Count / 2) + 0.5f, 14, 0), Quaternion.identity);
                    instantiatedObject.GetComponent<Enemy>().speed = speed/2f;
                    coroutine = instantiatedObject.GetComponent<Enemy>().WaitAndMove(obstacleData.Count / (speed / 2f), 14);
                    StartCoroutine(coroutine);
                    counter = counter + 1;
                }
            }

            for (int j = 0; j < bgData[size].Count; j++)
            {
                if (bgData[size][j])
                {
                    instantiatedObject = Instantiate(enemyBg, new Vector3((j - bgData[j].Count / 2) + 0.5f, 14, 0), Quaternion.identity);
                    instantiatedObject.GetComponent<Enemy>().speed = speed/3f;
                    coroutine = instantiatedObject.GetComponent<Enemy>().WaitAndMove(obstacleData.Count / (speed/3f), 14);
                    StartCoroutine(coroutine);
                    counter = counter + 1;
                }
            }

            for (int j = 0; j < obstacleData[size].Count; j++)
            {
                if (obstacleData[size][j])
                {
                    instantiatedObject= Instantiate(enemyObstacle, new Vector3((j - obstacleData[j].Count / 2) + 0.5f, 14, 0), Quaternion.identity);
                    instantiatedObject.GetComponent<Enemy>().speed = speed;
                    //instantiatedObject.GetComponent<Enemy>().Destroy(1f);
                    coroutine = instantiatedObject.GetComponent<Enemy>().WaitAndMove(obstacleData.Count/speed, 14);
                    StartCoroutine(coroutine);
                    counter = counter + 1;
                }
            }

            size = size - 1;
            timer = timer - waitTime;
        }
        /*
        if (size == obstacleData.Count*-1)
        {
            size = obstacleData.Count;
        }*/

        //Debug.Log("counter " + counter);
    }
}