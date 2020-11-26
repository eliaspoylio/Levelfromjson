using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + -speed * Time.deltaTime);
    }

    public void Destroy(float delay)
    {
        Destroy(gameObject, delay);
    }

    public IEnumerator WaitAndMove(float delay, float yPos)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            MoveUp(yPos);
        }
    }

    private void MoveUp(float yPos)
    {
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

}
