using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float rotaionForce = 200;
    private GameManager manager;

    public ParticleSystem explosionParticle;
    private void Start()
    {
        manager = GameManager.Instance;
    }
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * rotaionForce);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sowrd"))
        {
            //float swordForce = 2000;
            //if (swordForce>1000)
            //{
                Debug.Log("BOMB");
                manager.lives--;
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            //}
        }
    }
}
