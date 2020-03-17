using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BombZombie : MonoBehaviour
{
  private float speed = 2f;
  public GameObject player;
  private NavMeshAgent nma = null;
  public GameObject explosionparticle, blood;
  public GameObject money;
  public AudioClip boom;
  private AudioSource explosion_sound;
  private GameObject explosion_particle;
  private float health = 100f;

  // Start is called before the first frame update
  void Start()
  {
      explosion_sound = GetComponent<AudioSource>();
      player = GameObject.Find("Player");
      nma = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    // timer += Time.deltaTime;
      nma.SetDestination(player.transform.position);
      if (health < 0)
      {
          Destroy(gameObject);
      }
  }
  private void OnCollisionEnter(Collision other)
  {
      if (other.gameObject.name.StartsWith("Player"))
      {
          //yield return new WaitForSeconds(1);
          Vector3 explosion_pos = new Vector3(transform.position.x, 1.94f, transform.position.z);
          GameObject explosion_particle = (GameObject)Instantiate(explosionparticle, explosion_pos, Quaternion.identity);
          explosion_sound.PlayOneShot(boom, 1.0f);
          Destroy(explosion_particle, 1);
          Destroy(gameObject);
      }
  }

  private void OnTriggerEnter(Collider other)
  {
        if (other.gameObject.name.Contains("Bullet"))
        {
            float x = Random.Range(1, 10);
            if (x == 1)
            {
                explosion_sound.PlayOneShot(boom, 2.0f);
            }
            health -= Random.Range(10, 40);

            if (other.gameObject.name.Contains("GreenBullet"))
            {
                health -= 10;
            }
            else if (other.gameObject.name.Contains("RedBullet"))
            {
                health -= 20;
            }

            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
        }
    }

  private void OnDestroy()
  {
      GameObject goldcoin = (GameObject)Instantiate(money, transform.position, money.transform.rotation);
      Destroy(goldcoin, 5);
  }
}
