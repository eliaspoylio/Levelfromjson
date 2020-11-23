using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed;

    private float attackTimer = 0.01f;
    private float currentAttackTimer;
    private bool canAttack;
    private int bulletStash;

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private Text bulletText;


    // Start is called before the first frame update
    void Start()
    {
        currentAttackTimer = attackTimer;
        boxCollider = GetComponent<BoxCollider2D>();
        //bulletText.text = bulletStash.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        //Shoot();
    }

    public void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDelta = new Vector3(speed * x, speed * y, 0);
        //Vector3 playerScale = transform.localScale;

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Wall"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Wall"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }

    void Shoot()
    {


        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer && bulletStash > 0)
        {
            canAttack = true;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (canAttack)
            {
                canAttack = false;
                attackTimer = 0f;
                GetComponent<FireBullets>().Fire();
                bulletStash = bulletStash - 1;
                bulletText.text = bulletStash.ToString();
                //sound fx
            }

        }
        */
    }

}
