using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TwinkleScript : MonoBehaviour
{
    private float kokinPositionX;
    private float kokinPositionY;
    private float kirakiraDelta;
    [SerializeField] float kirakiraGenerateSpan;
    [SerializeField] float kirakiraLifeSpan;
    [SerializeField] GameObject kirakira;
    private GameObject cachedKirakira;

    // Start is called before the first frame update
    void Start()
    {
        kokinPositionX = transform.position.x;
        kokinPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        kirakiraDelta += Time.deltaTime;
        if (kirakiraDelta > kirakiraGenerateSpan)
        {
            float x = Random.Range(-1.5f, 1.5f);
            float y = Random.Range(-1.5f, 1.5f);

            while (x * x + y * y > 1.5f * 1.5f)
            {
                x = Random.Range(-1.5f, 1.5f);
                y = Random.Range(-1.5f, 1.5f);
            }

            cachedKirakira = Instantiate(kirakira, new Vector2(kokinPositionX + x, kokinPositionY + y), kirakira.transform.rotation);
            Destroy(cachedKirakira, kirakiraLifeSpan);
            kirakiraDelta = 0f;
        }

    }
}
