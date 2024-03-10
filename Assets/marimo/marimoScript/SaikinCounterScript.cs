using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaikinCounterScript : MonoBehaviour
{
    public string targetTag = "saikin"; // カウント対象のタグ名
    public int saikinCount;
    float saikinSpan = 1.0f;
    float saikinDelta = 0;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        /*saikinDelta += Time.deltaTime;
        if (saikinDelta > saikinSpan)
        {
            saikinCount = CountObjectsWithTag(targetTag);
            Debug.Log("エリア内の " + targetTag + " タグが付いているオブジェクトの数: " + saikinCount);
            saikinDelta = 0;
        }*/
    }

    /*int CountObjectsWithTag(string tag)
    {
        int count = 0;
        GameObject[] objectsInArea = GameObject.FindGameObjectsWithTag(tag); // 指定されたタグが付いているオブジェクトを取得

        foreach (GameObject obj in objectsInArea)
        {
            // ここで追加の条件を設定したり、処理をカスタマイズできます
            count++;
        }

        return count;
    }*/
}
