using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    [SerializeReference]
    private GameObject door;
    [SerializeReference]
    private GameObject text;
    bool keyDown;
    bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (playerInRange)
        {
            text.SetActive(true);
        } else
        {
            text.SetActive(false);
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if(door != null)
            {
                Destroy(door);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerInRange = true;
             
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerInRange = false;
    }
}
