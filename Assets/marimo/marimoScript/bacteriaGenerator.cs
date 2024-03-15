using System.Collections;
using System.Collections.Generic;
using nuuspace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//using System.Single;

namespace marimo
{
    public class bacteriaGenerator : MonoBehaviour
    {
        [SerializeField] GameObject bacteriaPrefab;
        [SerializeField] float defaultSpan = 1.0f;
        private float span;
        [SerializeField] float delta = 0;
        [SerializeField] float saikinAge = 0;
        MarimoCounterScript countScript;
        
        bool isKokin;
        [SerializeField] LayerMask layerMask;
        public GameManager gameManagerScript;
        float temperaturePercentage;
        public BacteriaManager bacteriaManager;
        public SpriteRenderer bacteriaSpriteRenderer;
        [SerializeField] Sprite nattoSprite;

        // Start is called before the first frame update
        void Start()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 0.8f, layerMask);
            if (collider2Ds.Length > 0)
            {
                Destroy(gameObject);
            }
            delta = 0;
            countScript = GameObject.FindWithTag("saikinCounter").GetComponent<MarimoCounterScript>();
            delta = 0f;

            gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
            //Debug.Log(gameManagerScript);


            bacteriaManager = GameObject.Find("BacteriaManager").GetComponent<BacteriaManager>();

            bacteriaSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            temperaturePercentage = gameManagerScript.temperaturePercentage;
            span = defaultSpan * temperaturePercentage;

            delta += Time.deltaTime;   //経過時間deltaをフレーム毎に大きくしていく
            //saikinAge += Time.deltaTime;
            if (delta > span)  //deltaがspanより大きくなったら
            {
                if (gameManagerScript.bacteriaCounter < gameManagerScript.bacteriaLimit)
                {
                    float x = Random.Range(-4f, 4f);
                    float y = Random.Range(-4f, 4f);
                    while (x * x + y * y > 16)
                    {
                        x = Random.Range(-4f, 4f);
                        y = Random.Range(-4f, 4f);
                    }

                    bacteriaGenerator instantiatedBacteria = Instantiate(bacteriaPrefab, new Vector2(x, y), bacteriaPrefab.transform.rotation).GetComponent<bacteriaGenerator>();
                    instantiatedBacteria.bacteriaManager = bacteriaManager;
                    instantiatedBacteria.gameManagerScript = gameManagerScript;
                    if (gameManagerScript.isNattoTime)
                    {
                        instantiatedBacteria.GetComponent<SpriteRenderer>().sprite = nattoSprite;
                    }
                    gameManagerScript.bacteriaCounter += 1;
                    //Debug.Log(gameManagerScript.bacteriaCounter);
                    bacteriaManager.bacteriaGenerators.Add(instantiatedBacteria);
                }

                delta = 0; //経過時間リセット
            }
        }

        void OnDestroy()
        {
            gameManagerScript.bacteriaCounter -= 1;
        }
    }
}