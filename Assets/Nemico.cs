using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemico : MonoBehaviour
{
    public float accelerazione;
    public float velocit‡;
    private Vector2 direzione;
    private Rigidbody2D rb2d;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        velocit‡ =2f;
        accelerazione = 50f;
        Invoke("Autodistruzione", 10);
        direzione = Vector2.zero;
        direzione.y = -1;
        direzione.x = Random.Range(-1f, +1f);
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
              
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 posizioneRispettoAllaCamera = Camera.main.WorldToViewportPoint(rb2d.position);
        posizioneRispettoAllaCamera.x = Mathf.Clamp01(posizioneRispettoAllaCamera.x);
        posizioneRispettoAllaCamera.y = Mathf.Clamp01(posizioneRispettoAllaCamera.y);
        Vector3 velocit‡Attuale = rb2d.velocity;

        if (posizioneRispettoAllaCamera.x == 0 || posizioneRispettoAllaCamera.x == 1)
        {

            velocit‡Attuale.x = -velocit‡Attuale.x;

        }
        if (posizioneRispettoAllaCamera.y == 0 || posizioneRispettoAllaCamera.y == 1)
        {

            velocit‡Attuale.y = -velocit‡Attuale.y;

        }
        rb2d.velocity = velocit‡Attuale;

        rb2d.position = Camera.main.ViewportToWorldPoint(posizioneRispettoAllaCamera);
    }
    private void FixedUpdate()
    {
        Vector2 forza = direzione * accelerazione * Time.fixedDeltaTime;
        rb2d.AddForce(forza);
    }
    void Autodistruzione()
    {
        gameManager.diminuisciNemici();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.aggiungiPunti(2);
        gameManager.aumentaEnergia(2);
        Autodistruzione();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Proiettile(Clone)"))
        {
            gameManager.aggiungiPunti(2);
            Autodistruzione();
        }
    }

}
