using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2UIManager : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Level1()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void main()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}