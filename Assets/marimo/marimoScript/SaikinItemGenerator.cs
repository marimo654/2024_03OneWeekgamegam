using UnityEngine;

namespace marimo
{

    public class SaikinItemGenerator : MonoBehaviour
    {
        public GameObject eiyouPrefab;
        public GameObject sizukuPrefab;
        public GameObject hueiseiPrefab;
        public float sItemSpan = 10.0f;
        public float sItemDelta = 0;
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
                    Instantiate(eiyouPrefab, new Vector3(x, y, z), Quaternion.identity);
                }
                else if (dice <= 2)
                {
                    Instantiate(sizukuPrefab, new Vector3(x, y, z), Quaternion.identity);
                }
                else
                {
                    Instantiate(hueiseiPrefab, new Vector3(x, y, z), Quaternion.identity);
                    
                }
                //item.transform.position = new Vector3(x, y, z);

                this.sItemDelta = 0; //経過時間リセット
            }
        }
    }
}