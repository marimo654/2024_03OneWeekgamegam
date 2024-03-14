using UnityEngine;

namespace marimo
{

    public class SaikinItemGenerator : MonoBehaviour
    {
        private GameObject item;
        public GameObject eiyouPrefab;
        public GameObject sizukuPrefab;
        public GameObject hueiseiPrefab;
        public GameObject upPrefab;
        public float sItemSpan = 10.0f;
        public float sItemDelta = 0;
        [SerializeField] MarimoCounterScript marimoCounterScript;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.sItemDelta += Time.deltaTime;   //経過時間deltaをフレーム毎に大きくしていく
            if (this.sItemDelta > this.sItemSpan)  //deltaがspanより大きくなったら
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
                    item = Instantiate(eiyouPrefab, new Vector2(x, y), Quaternion.identity);
                }
                else if (dice <= 6)
                {
                    item = Instantiate(sizukuPrefab, new Vector2(x, y), Quaternion.identity);
                }
                else if (dice <= 11)
                {
                    item = Instantiate(upPrefab, new Vector2(x, y), Quaternion.identity);
                }
                else
                {
                    item = Instantiate(hueiseiPrefab, new Vector2(x, y), Quaternion.identity);
                    marimoCounterScript.areaCount++;
                    item.GetComponent<SpriteRenderer>().sortingOrder += marimoCounterScript.areaCount;
                }
                Destroy(item, 10.0f);
                this.sItemDelta = 0; //経過時間リセット
            }
        }
    }
}