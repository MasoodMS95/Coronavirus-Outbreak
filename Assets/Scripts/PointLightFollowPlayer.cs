using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightFollowPlayer : MonoBehaviour
{
  public GameObject player;
  private float posy = 12.51f;
  Light lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(player.transform.position.x, posy, player.transform.position.z);

    }
}
