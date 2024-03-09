using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacteriaGenerator : MonoBehaviour
{
    public GameObject bacteriaPrefab;
    GameObject alcohol;
    public float span = 0.5f;
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
            Instantiate(bacteriaPrefab, new Vector3(x,y,z), bacteriaPrefab.transform.rotation);

            this.delta = 0; //経過時間リセット
        }

        /*if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 pos = GetComponent<alcoholScript>().alcoholPosition;
            float alx = pos.x;
            float aly = pos.y;
            if (alx*alx + aly*aly > 16)
            {
                if()
            }
        }*/
    }
}
