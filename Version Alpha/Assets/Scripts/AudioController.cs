using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource BGM;
    public Collider2D coll;
    public LayerMask ground;
    public bool AudioPlaying ;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        //test = coll.IsTouchingLayers(ground);
        BGMstart();

    }

    void BGMstart()
    {
        if(coll.IsTouchingLayers(ground) && (!AudioPlaying))
        {
            BGM.Play();
            AudioPlaying = true;
        }
    }
}
