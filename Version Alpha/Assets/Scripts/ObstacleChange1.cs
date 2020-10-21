using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChange1 : MonoBehaviour
{
    public Transform ObstaclePostion;
    public AudioSource BGM;
    private bool down;
    private bool up;
    public float Rythme;
    // Start is called before the first frame update
    void Start()
    {
        down = true;
        up = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(BGM.isPlaying == true)
        {
            MoveWithRythme();
        }
        
    }

    void MoveWithRythme()
    {
        ObstaclePostion.position = new Vector2( ObstaclePostion.position.x, 12 + 2*Mathf.PingPong(Time.time, Rythme));
    }
}
