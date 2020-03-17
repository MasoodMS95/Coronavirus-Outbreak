using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float posy = 5f;
    private float finalposx = 8f;
    public float diffx = 0;
    public float spotangle = 0;

    void Start()
    {
      diffx = (finalposx - transform.position.x);
      spotangle = 50 + (diffx*4);
    }

    void Update()
    {
      transform.position = new Vector3(player.transform.position.x, player.transform.position.y + posy, player.transform.position.z);
      diffx = (finalposx - transform.position.x);
      spotangle = 50 + (diffx*4);
    }
}
