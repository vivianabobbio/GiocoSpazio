using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiettile : MonoBehaviour
{
    public float velocità;
    // Start is called before the first frame update
    void Start()
    {
        velocità = 3f;
        Invoke("Autodistruzione", 1);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.up*velocità*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("StarShip"))
        {

        }
        else
        {
            Autodistruzione();
        }
        
    }
    void Autodistruzione()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
