﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer4 : MonoBehaviour
{
    public GameObject player;
    public float posy = 55f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, posy, player.transform.position.z);
    }
}
