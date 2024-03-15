using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace marimo
{
    public class AlcoholItemGenerator : MonoBehaviour
    {
        private GameObject item;
        public GameObject capsilePrefab;
        public GameObject rokeranPrefab;
        public GameObject kokinPrefab;
        public GameObject downPrefab;
        public float aItemSpan = 10.0f;
        public float aItemDelta = 0;
        [SerializeField] MarimoCounterScript marimoCounterScript;

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
                while (x * x + y * y > 16)
                {
                    x = Random.Range(-4f, 4f);
                    y = Random.Range(-4f, 4f);
                }

                int dice = Random.Range(1, 17);
                if (dice <= 1)
                {
                    item = Instantiate(capsilePrefab, new Vector2(x, y), Quaternion.identity);
                }
                else if (dice <= 6)
                {
                    item = Instantiate(rokeranPrefab, new Vector2(x, y), Quaternion.identity);
                }
                else if (dice <= 11)
                {
                    item = Instantiate(downPrefab, new Vector2(x, y), Quaternion.identity);
                }
                else
                {
                    item = Instantiate(kokinPrefab, new Vector2(x, y), Quaternion.identity);
                    marimoCounterScript.areaCount++;
                    item.GetComponent<SpriteRenderer>().sortingOrder += marimoCounterScript.areaCount;
                }
                
                Destroy(item, 10.0f);
                this.aItemDelta = 0; //経過時間リセット
            }
        }
    }
}