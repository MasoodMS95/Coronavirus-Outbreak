using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
  public float speed = 3.5f;
  public float health = 100f;
  public GameObject blood, bullet;
  public float horizontalInput;
  public float verticalInput;
  public AudioClip hit;
  private AudioSource hitsound;
  private float xRange = 10f;
  private float zRange = 10f;
  // Start is called before the first frame update
  void Start()
  {
      hitsound = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
      // if(health < 0)
      // {
      //     health = 0;
      // }
      //Provided by https://answers.unity.com/questions/653798/character-always-facing-mouse-cursor-position.html
      //The following code makes the player aim at the mouse.
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hit, 100))
      {
          transform.LookAt(hit.point);
      }

      //The following code makes sure the player does not go over map.
      // if (transform.position.x < -xRange)
      // {
      //     transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
      // }
      // if (transform.position.x > xRange)
      // {
      //     transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
      // }
      // if(transform.position.z < -zRange)
      // {
      //     transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
      // }
      // if(transform.position.z > zRange)
      // {
      //     transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
      // }

      //Shooting Mechanics
      if (Input.GetMouseButtonDown(0))
      {
          GameObject pew = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
      }

      //The following code ensures the player moves around despite direction it faces (which is towards mouse)
      horizontalInput = Input.GetAxisRaw("Horizontal");
      verticalInput = Input.GetAxisRaw("Vertical");
      transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput, Space.World);
      transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput, Space.World);
  }
  void OnCollisionEnter(Collision collision)
  {
      if (collision.gameObject.name.StartsWith("Zombie"))
      {
          health = health - Random.Range(1, 3);
          GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
          Destroy(oof, 3);
          float x = Random.Range(0, 3);
          if(x == 1)
          {
              hitsound.PlayOneShot(hit, 1.0f);
          }
      }
  }
  // public void Awake()
  // {
  //     gameManager.player = this;
  // }
  // public float getHealth()
  // {
  //     return health;
  // }
}
