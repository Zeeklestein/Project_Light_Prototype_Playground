using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour

{
    private Transform player;
    private Vector3 tempPos;


    [SerializeField]
    private float minX, maxX;
    [SerializeField]
    private float yOffset;

    private string PLAYER_TAG = "Player";
    
        
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y + yOffset; 

        /* The camera will only follow the player until it reaches the min or 
         * max limits. */
        if (minX != 0 || maxX != 0)
        {
            if (tempPos.x < minX)
                tempPos.x = minX;

            if (tempPos.x > maxX)
                tempPos.x = maxX;
        }
        
        transform.position = tempPos;
    }
}
