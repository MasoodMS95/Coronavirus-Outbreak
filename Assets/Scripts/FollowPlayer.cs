using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float posy = 3f;
    private float finalposx = 8f;
    public float diffx = 0;
    public float spotangle = 0;
    Light lt;

    void Start()
    {
      lt = GetComponent<Light>();
      diffx = (finalposx - transform.position.x);
      spotangle = 90 + (diffx*4);
      lt.spotAngle = spotangle;
    }

    void Update()
    {
      transform.position = new Vector3(player.transform.position.x, player.transform.position.y + posy, player.transform.position.z);
      diffx = (finalposx - transform.position.x);
      spotangle = 90 + (diffx*4);
      lt.spotAngle = spotangle;
    }
}
