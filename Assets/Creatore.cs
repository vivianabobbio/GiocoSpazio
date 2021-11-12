using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatore : MonoBehaviour
{
    // Start is called before the first frame update

    public Nemico nemico;

    public float tempoDiCreazione;
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        tempoDiCreazione = 1;
        InvokeRepeating("GeneraNemico", 2, 4);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void GeneraNemico()
    {
        if (gameManager.possoMandareUnNuovoNemico())
        {

            Vector2 posizioneSprite = transform.position;
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            float larghezzaCreatore = renderer.bounds.size.x;
            float maxX = larghezzaCreatore / 2;
            float minX = -maxX;
            float xLancio = Random.Range(minX, maxX);
            Vector2 posizioneDiLancio = Vector2.zero;
            posizioneDiLancio.x = xLancio;
            posizioneDiLancio.y = posizioneSprite.y;
            Instantiate(nemico, posizioneDiLancio, Quaternion.identity);
            gameManager.aumentaNemici();
        }
    }
}
