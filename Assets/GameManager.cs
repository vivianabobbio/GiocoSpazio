using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerEnergy;
    public int punti;
    public int nemici;
    public int maxNemici;
    public Text testoPunti;
    public Text testoEnergia;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        punti = 0;
        nemici = 0;
        maxNemici = 5;
        playerEnergy = 100;
    }
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void aggiungiPunti(int nuoviPunti)
    {
        punti = punti + nuoviPunti;
        testoPunti.text=("punti:" + punti);
    }
    public void aumentaNemici()
    {
        nemici++;
    }
    public void diminuisciNemici()
    {
        nemici--;
    }
    public void aumentaEnergia(int nuovaEnergia)
    {
        playerEnergy=playerEnergy+nuovaEnergia;
        testoEnergia.text = "Energia: " + playerEnergy;
    }
    public void diminuisciEnergia(int energiaPersa)
    {
        playerEnergy = playerEnergy - energiaPersa;
        testoEnergia.text = "Energia: " + playerEnergy;
    }
    public bool ilGiocatoreèVivo()
    {
        if (playerEnergy>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool possoMandareUnNuovoNemico()
    {
        if (nemici<maxNemici)
        {
                return true;
        }
            else
            {
                return false;
            }
    }
}
