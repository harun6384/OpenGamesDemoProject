using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//namespace gatherMech
//{


public class Gathering : MonoBehaviour
{
    private float odun = 0;
    private float tas = 0;
    private float kulce = 0;
    private bool hasCoroutineStarted = false;
    [SerializeField] private TMP_Text _wood;
    [SerializeField] private TMP_Text _rock;
    [SerializeField] private TMP_Text _gold;


    private int buildingCount = 1;
    [SerializeField] GameObject _temel;
    [SerializeField] GameObject _orta;
    [SerializeField] GameObject _son;
    [SerializeField] GameObject _alan;
    [SerializeField] private TMP_Text _malzeme;
    [SerializeField] GameObject _uAlan;
    [SerializeField] private TMP_Text _uMalzeme;   
    private int gerekliMalzeme = 6;
    private int oGerekliMalzeme = 4;
    private int x = 0;

    public List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] GameObject _okcu;

    private int buildingCounty = 1;
    [SerializeField] GameObject _mtemel;
    [SerializeField] GameObject _morta;
    [SerializeField] GameObject _mson;
    [SerializeField] GameObject _malan;
    [SerializeField] private TMP_Text _mmalzeme;
    [SerializeField] GameObject _muAlan;
    [SerializeField] private TMP_Text _muMalzeme;
    private int mgerekliMalzeme = 6;
    private int mGerekliMalzeme = 4;
    private int y = 0;

    private int archerCount = 0;
    private int lancerCount = 0;

    public List<Transform> spawnPointsy = new List<Transform>();
    [SerializeField] GameObject _mizrakli;

    [SerializeField] GameObject _gameOver;
    [SerializeField] GameObject _fadePanel;


    private void Awake()
    {
        _malzeme.text = "Odun " + gerekliMalzeme.ToString();
        _uMalzeme.text = "Odun " + oGerekliMalzeme.ToString() + " Altin " + oGerekliMalzeme.ToString();
        _mmalzeme.text = "Tas " + mgerekliMalzeme.ToString();
        _muMalzeme.text = "Tas " + mGerekliMalzeme.ToString() + " Altin " + mGerekliMalzeme.ToString();
    }


    // Collider içinde durduðu süre boyunca her saniye malzeme topla
    private void  OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("AgacAlan") && ! hasCoroutineStarted)
        {
            hasCoroutineStarted = true;
            log = StartCoroutine(GatherLog());
            
            
        }
        if (collision.gameObject.CompareTag("KayaAlan") && !hasCoroutineStarted)
        {
            hasCoroutineStarted = true;
            rock = StartCoroutine(GatherRock());

        }
        if (collision.gameObject.CompareTag("AltinAlan") && !hasCoroutineStarted)
        {
            hasCoroutineStarted = true;
            gold = StartCoroutine(GatherGold());

        }
        // Alanýn üstüne gelindiðinde maddelerin deðeri sýfýra eþitleniyor.
        if (collision.gameObject.CompareTag("Copluk"))
        {
            odun = 0;
            tas = 0;
            kulce = 0;
            //Debug.Log("Odun " + odun + " Tas " + tas + " Altin " + kulce);           
            _wood.gameObject.SetActive(false);
            _rock.gameObject.SetActive(false);
            _gold.gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("OkcuBina"))
        {

             
            if (buildingCount > 0 && buildingCount <= 1 && odun >= 2)
            {
                buildingCount++;
                odun = odun - 2;
                gerekliMalzeme = gerekliMalzeme - 2;
                _wood.text = odun.ToString();
                _temel.gameObject.SetActive(true);
                _malzeme.text = "Odun " + gerekliMalzeme.ToString();
            }
            if (buildingCount > 1 && buildingCount <= 2 && odun >=2)
            {
                buildingCount++;
                odun = odun - 2;
                gerekliMalzeme = gerekliMalzeme - 2;
                _wood.text = odun.ToString();
                _orta.gameObject.SetActive(true);
                _malzeme.text = "Odun " + gerekliMalzeme.ToString();
            }
            if (buildingCount > 2 && buildingCount <= 3 && odun >=2)
            {
                buildingCount++;
                odun = odun - 2;
                gerekliMalzeme = gerekliMalzeme - 2;
                _wood.text = odun.ToString();
                _son.gameObject.SetActive(true);
                _alan.gameObject.SetActive(false);
                _malzeme.gameObject.SetActive(false);
                _uAlan.gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("OkcuUret") && !hasCoroutineStarted)
        {

            
                //instantiate

            
            
                    hasCoroutineStarted = true;
                    archer = StartCoroutine(ArcherIns());

            


            //Debug.Log("okcu üretildi");

        }
        if (collision.gameObject.CompareTag("MizrakBina"))
        {

            if (buildingCounty > 0 && buildingCounty <= 1 && tas >= 2)
            {
                buildingCounty++;
                tas = tas - 2;
                mgerekliMalzeme = mgerekliMalzeme - 2;
                _rock.text = tas.ToString();
                _mtemel.gameObject.SetActive(true);
                _mmalzeme.text = "Tas " + mgerekliMalzeme.ToString();
            }
            if (buildingCounty > 1 && buildingCounty <= 2 && tas >= 2)
            {
                buildingCounty++;
                tas = tas - 2;
                mgerekliMalzeme = mgerekliMalzeme - 2;
                _rock.text = tas.ToString();
                _morta.gameObject.SetActive(true);
                _mmalzeme.text = "Odun " + mgerekliMalzeme.ToString();
            }
            if (buildingCounty > 2 && buildingCounty <= 3 && tas >= 2)
            {
                buildingCounty++;
                tas = tas - 2;
                mgerekliMalzeme = mgerekliMalzeme - 2;
                _rock.text = tas.ToString();
                _mson.gameObject.SetActive(true);
                _malan.gameObject.SetActive(false);
                _mmalzeme.gameObject.SetActive(false);
                _muAlan.gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("MizrakUret") && !hasCoroutineStarted)
        {


            //instantiate



            hasCoroutineStarted = true;
            lancer = StartCoroutine(LancerIns());


           

            

        }
        if (collision.gameObject.CompareTag("OyunSonu"))
        {
            
                
                StartCoroutine(Fade());
            
        }
    }

    // Coroutine durdurma
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("AgacAlan"))
        {
            hasCoroutineStarted = false;
            StopCoroutine(log);

        }
        if (collision.gameObject.CompareTag("KayaAlan"))
        {
            hasCoroutineStarted = false;
            StopCoroutine(rock);

        }
        if (collision.gameObject.CompareTag("AltinAlan"))
        {
            hasCoroutineStarted = false;
            StopCoroutine(gold);

        }
        if (collision.gameObject.CompareTag("OkcuUret"))
        {
            hasCoroutineStarted = false;
            StopCoroutine(archer);
        }
        if (collision.gameObject.CompareTag("MizrakUret"))
        {
            hasCoroutineStarted = false;
            StopCoroutine(lancer);
        }

    }
    // Coroutine durdurmak için tanýmlanmalý
    Coroutine log;
    Coroutine rock;
    Coroutine gold;
    Coroutine archer;
    Coroutine lancer;

    IEnumerator GatherLog()
    {
        while (true)
        {
            odun++;
            _wood.gameObject.SetActive(true);
            _wood.text = "Odun " + odun.ToString();
            //Debug.Log("Odun = " + odun);
            hasCoroutineStarted = false;
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator GatherRock()
    {
        while (true)
        {
            tas++;
            _rock.gameObject.SetActive(true);
            _rock.text = "Taþ " + tas.ToString();
            //Debug.Log("Taþ = " + tas);
            hasCoroutineStarted = false;
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator GatherGold()
    {
        while (true)
        {
            kulce++;
            _gold.gameObject.SetActive(true);
            _gold.text = "Altýn " + kulce.ToString();
            //Debug.Log("Altin = " + kulce);
            hasCoroutineStarted = false;
            yield return new WaitForSeconds(0.2f);
        }
    }
    
    IEnumerator ArcherIns()
    {
        while (true)
        {

            if (odun >= 4 && kulce >= 4)
            {
                odun -= 4;
                kulce -= 4;
                _wood.text = odun.ToString();
                _gold.text = kulce.ToString();
                Instantiate(_okcu, spawnPoints[x].position, spawnPoints[x].rotation);
                x++;
                archerCount += 1;
                //Debug.Log(x);
                hasCoroutineStarted = false;
                if (x >= 3)
                {
                    _uAlan.gameObject.SetActive(false);
                }
            
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator LancerIns()
    {
        while (true)
        {

            if (tas >= 4 && kulce >= 4)
            {
                tas -= 4;
                kulce -= 4;
                _rock.text = tas.ToString();
                _gold.text = kulce.ToString();
                Instantiate(_mizrakli, spawnPointsy[y].position, spawnPointsy[y].rotation);
                y++;
                lancerCount += 1;
                Debug.Log(lancerCount);
                hasCoroutineStarted = false;
                if (y >= 3)
                {
                    _muAlan.gameObject.SetActive(false);
                }

            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Fade()
    {
        if (archerCount == 3 && lancerCount == 3)
        {
            _gameOver.SetActive(true);
            _fadePanel.SetActive(true);
            yield return new WaitForSeconds(1.6f);
            Time.timeScale = 0;
        }
    }

}

//}
