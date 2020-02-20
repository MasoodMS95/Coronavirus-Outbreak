using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
  private float xRange = 10f;
  private float zRange = 10f;
  //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //The following code makes sure the player does not go over map.
      if (transform.position.x < -xRange)
      {
          transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
      }
      if (transform.position.x > xRange)
      {
          transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
      }
      if(transform.position.z < -zRange)
      {
          transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
      }
      if(transform.position.z > zRange)
      {
          transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
      }
    }
}
