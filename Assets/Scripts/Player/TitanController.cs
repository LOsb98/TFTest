using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanController : MonoBehaviour
{
    public GameObject pilot;
    public Transform disembarkPos;
    public Transform embarkPos;
    private PlayerController playerController;
    public bool embarked;
    public bool Embarked
    {
        get { return embarked; }
        set
        {
            embarked = value;
            if (embarked)
            {
                playerController.enabled = true;
                pilot.GetComponent<CapsuleCollider>().enabled = false;
                return;
            } 
            playerController.enabled = false;
            pilot.transform.position = disembarkPos.position;
            pilot.GetComponent<CapsuleCollider>().enabled = true;
        }
    }

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        if (embarked)
        {
            playerController.enabled = true;
            return;
        }
        playerController.enabled = false;
    }

    void Update()
    {
        if (embarked)
        {
            pilot.transform.position = embarkPos.position;
            gameObject.transform.rotation = pilot.transform.rotation;
        }


        if (Input.GetKeyDown("e")) Embarked = !Embarked;
    }
}
