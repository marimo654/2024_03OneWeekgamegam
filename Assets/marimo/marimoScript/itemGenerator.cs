using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerator : MonoBehaviour
{
    public GameObject item; 
    public GameObject capsilePrefab;
    public GameObject rokeranPrefab;
    public GameObject eiyouPrefab;
    public GameObject sizukuPrefab;
    public float span = 10.0f;
    public float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;   //経過時間deltaをフレーム毎に大きくしていく
        if(this.delta > this.span)  //deltaがspanより大きくなったら
        {
            float x = Random.Range(-4f, 4f);
            float y = Random.Range(-4f, 4f);
            float z = Random.Range(-4f, 4f);
            while(x*x + y*y > 16){
                x = Random.Range(-4f, 4f);
                y = Random.Range(-4f, 4f);
                z = Random.Range(-4f, 4f);
            }

            int dice = Random.Range(1,5);
            if(dice <= 1){
                item = Instantiate(capsilePrefab) as GameObject;
            }else if(dice <= 2){
                item = Instantiate(rokeranPrefab) as GameObject;
            }else if(dice <= 3){
                item = Instantiate(eiyouPrefab) as GameObject;
            }else{
                item = Instantiate(sizukuPrefab) as GameObject;
            }
            item.transform.position = new Vector3(x, y, z);

            this.delta = 0; //経過時間リセット
        }
    }
}