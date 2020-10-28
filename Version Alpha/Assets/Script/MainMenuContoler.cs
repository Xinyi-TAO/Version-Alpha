using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuContoler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel_1;

    public GameObject Panel_2;
    void Start()
    {
        Panel_2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickSelectLevel()
    {
        Panel_2.SetActive(true);
        Panel_1.SetActive(false);
    }

    public void onClickBack()
    {
        Panel_2.SetActive(false);
        Panel_1.SetActive(true);
    }

    public void onClickScene1()
    {
        SceneManager.LoadScene("Level 1");
    }

}
