using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject main;
    public GameObject inst;
    // Start is called before the first frame update
    public void Start()
    {
        main.SetActive(true); 
        inst.SetActive(false);
    }

    public void Instruction() {
        main.SetActive(false);
        inst.SetActive(true);
    }

    public void Game() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Level1() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Level2() {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
}
