using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject door;
    
    void Update()
    {
        distance = playerCasting.targetDistance;

    }

    void OnMouseOver() {
        if(distance<=3) {
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
            if(Input.GetButtonDown("ActionKey")) {
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                door.GetComponent<Animator>().Play("slide");
            }
        }
    }

    void OnMouseExit() {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
