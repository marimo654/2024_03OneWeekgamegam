using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace marimo
{
    public class SaikinCounterScript : MonoBehaviour
    {
        public string targetTag = "saikin"; // カウント対象のタグ名
        public int saikinCount; //ここ大事！
        float saikinSpan = 1.0f;    //細菌の個数を1.0秒ごとに数える
        float saikinDelta = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}