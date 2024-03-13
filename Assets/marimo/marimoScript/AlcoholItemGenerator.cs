using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace marimo
{
    public class AlcoholItemGenerator : MonoBehaviour
    {
        public GameObject capsilePrefab;
        public GameObject rokeranPrefab;
        public GameObject kokinPrefab;
        public float aItemSpan = 10.0f;
        public float aItemDelta = 0;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            this.aItemDelta += Time.deltaTime;   //経過時間deltaをフレーム毎に大きくしていく
            if (this.aItemDelta > this.aItemSpan)  //deltaがspanより大きくなったら
            {
                float x = Random.Range(-4f, 4f);
                float y = Random.Range(-4f, 4f);
                float z = Random.Range(-4f, 4f);
                while (x * x + y * y > 16)
                {
                    x = Random.Range(-4f, 4f);
                    y = Random.Range(-4f, 4f);
                    z = Random.Range(-4f, 4f);
                }

                int dice = Random.Range(1, 4);
                if (dice <= 1)
                {
                    Instantiate(capsilePrefab, new Vector3(x, y, z), Quaternion.identity);
                }
                else if (dice <= 2)
                {
                    Instantiate(rokeranPrefab, new Vector3(x, y, z), Quaternion.identity);
                }
                else
                {
                    Instantiate(kokinPrefab, new Vector3(x, y, z), Quaternion.identity);
                    
                }
                //item.transform.position = new Vector3(x, y, z);

                this.aItemDelta = 0; //経過時間リセット
            }
        }
    }
}