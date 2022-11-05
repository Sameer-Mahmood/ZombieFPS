using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerCasting : MonoBehaviour
{
    public static float targetDistance;
    public float toTarget;
    public float health = 100f;
    public GameObject healthUI;
    public static int score = 0;
    public GameObject winUI;
    public GameObject loseUI;
    public int winScore;
    public GameObject scoreUI;

    public void Hit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Time.timeScale = 0;
            loseUI.SetActive(true);
        }
    }

    void Start()
    {
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            toTarget = hit.distance;
            targetDistance = hit.distance;
        }
        healthUI.GetComponent<Text>().text = "Health: " + health;
        if (score >= winScore)
        {
            Time.timeScale = 0;
            winUI.SetActive(true);
        }
        scoreUI.GetComponent<Text>().text = "Score: " + score;
    }

}
