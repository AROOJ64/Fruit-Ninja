using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gm;


    [SerializeField] private GameObject _slicedFruit;
    private float rotaionForce = 200;

    public int scorePoints;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * rotaionForce);
    }
    private void InstantiateSlicedFruit()
    {
        GameObject instantiatedFruit = Instantiate(_slicedFruit, transform.position, transform.rotation);

        Rigidbody[] slicedRb = instantiatedFruit.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody part in slicedRb)
        {
            part.AddExplosionForce(130f, transform.position, 10);
            part.velocity = rb.velocity * 1.2f;
        }
        Destroy(instantiatedFruit, 5);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Sowrd"))
        {
            gm.UpdateTheScore(scorePoints);
            InstantiateSlicedFruit();
            Destroy(gameObject);
        }
    }
}
