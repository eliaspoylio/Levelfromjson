using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private Animator anim;
    //private AudioSource showSound;

    void Awake()
    {
    anim = GetComponent<Animator>();
    //showSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Flare"){
          anim.Play("Stone_show");
          //sound?
        }
    }
}
