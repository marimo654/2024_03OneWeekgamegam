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
        [SerializeField] float span = 1.0f;
        [SerializeField] float delta = 0;
        [SerializeField] float saikinAge = 0;
        MarimoCounterScript countScript;
        [SerializeField] int saikinLimit;
        bool isKokin;
        [SerializeField] LayerMask layerMask;
        [SerializeField] GameManager gameManager;
        float temperaturePercentage;

        // Start is called before the first frame update
        void Start()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 0.8f, layerMask);
            if(collider2Ds.Length > 0)
            {
                Destroy(gameObject);
            }
            delta = 0;
            countScript = GameObject.FindWithTag("saikinCounter").GetComponent<MarimoCounterScript>();
        }

        // Update is called once per frame
        void Update()
        {
            temperaturePercentage = GetComponent<GameManager>().temperaturePercentage;
            span /= temperaturePercentage;
            delta += Time.deltaTime;   //経過時間deltaをフレーム毎に大きくしていく
            //saikinAge += Time.deltaTime;
            if (delta > span)  //deltaがspanより大きくなったら
            {
                if (countScript.saikinCount < saikinLimit)
                {
                    float x = Random.Range(-4f, 4f);
                    float y = Random.Range(-4f, 4f);
                    while (x * x + y * y > 16)
                    {
                        x = Random.Range(-4f, 4f);
                        y = Random.Range(-4f, 4f);
                    }

                    Instantiate(original: bacteriaPrefab, new Vector2(x, y), bacteriaPrefab.transform.rotation);
                    countScript.saikinCount += 1;
                }

                delta = 0; //経過時間リセット
            }
        }

        void OnDestroy()
        {
            countScript.saikinCount -= 1;
        }
    }
}