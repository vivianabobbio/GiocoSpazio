using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 movimento;
    public float velocitą;
    public float accellerazione;
    public Proiettile proiettile;
    public float frequenzaDiSparo;
    private float tempoDiSparo;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {/* tutte le inizializzazioni le faccio nello start*/
        rb2d = GetComponent<Rigidbody2D>();
        movimento = Vector2.zero;
        velocitą = 12F;
        accellerazione = 90F;
        frequenzaDiSparo = 0.5f;
        tempoDiSparo = 0;
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // movimento.y=Input.GetAxisRaw("Vertical");


        //movimento.x = Input.GetAxisRaw("Horizontal");
        //  //Debug.Log("Movimento su asse verticale:" + movimentoAsseVerticale);
        movimento.x = 0;
        movimento.y = 0;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimento.x--; 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movimento.x++;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movimento.y++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movimento.y--;
        }
        tempoDiSparo = tempoDiSparo + Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)&& tempoDiSparo>frequenzaDiSparo)
        {
            tempoDiSparo = 0;
            Instantiate(proiettile, transform.position, Quaternion.identity);
        }
        //Vector2 movimentoInBaseAllaVelocitą = movimento * velocitą * Time.deltaTime;
        //transform.Translate(movimentoInBaseAllaVelocitą);
        Vector3 posizioneRispettoAllaCamera=Camera.main.WorldToViewportPoint(rb2d.position);
        posizioneRispettoAllaCamera.x = Mathf.Clamp01(posizioneRispettoAllaCamera.x);
        posizioneRispettoAllaCamera.y = Mathf.Clamp01(posizioneRispettoAllaCamera.y);
        Vector3 velocitąAttuale = rb2d.velocity;
        
        if (posizioneRispettoAllaCamera.x==0 || posizioneRispettoAllaCamera.x==1)
        {
            
         velocitąAttuale.x = - velocitąAttuale.x;

        }
        if (posizioneRispettoAllaCamera.y== 0 || posizioneRispettoAllaCamera.y == 1)
        {

            velocitąAttuale.y = - velocitąAttuale.y;

        }
        rb2d.velocity = velocitąAttuale;

    }

    void FixedUpdate()
    {
        Vector2 forza = movimento * accellerazione * Time.fixedDeltaTime;
        rb2d.AddForce(forza);
        //

        //Vector2 spostamento = rb2d.position + movimentoInBaseAllaVelocitą;

        //rb2d.MovePosition(spostamento);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Proiettile(Clone)"))
        {

        }
        else
        {
            gameManager.diminuisciEnergia(20);
            if (!gameManager.ilGiocatorečVivo())
            {
                Autodistruzione();

            }
            
        }
        
    }
    void Autodistruzione()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
