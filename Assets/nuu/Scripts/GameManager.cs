using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace nuuspace
{
    public class GameManager : MonoBehaviour
    {
        [Header("ゲームオーバーまでの時間設定")]
        [SerializeField] float gameOverTime;
        [Header("タイマーの円")]
        [SerializeField] Image timerCircle;
        [Header("温度計のパラメータ")]
        [SerializeField] Image rightThermometer;
        [SerializeField] Image leftThermometer;
        [Header("デフォルトの温度計の温度(割合)")]
        [SerializeField] float defaultTemperaturePercentage;
        [Header("温度の上昇率(0~1の小数)")]
        [SerializeField] float rateOfTempertureIncrease;
        [Header("温度の減少率(0~1の小数)")]
        [SerializeField] float rateOfTempertureDecrease;
        float remainingTime;
        float temperaturePercentage;
        [Header("細菌の数を数える変数(int型)")]
        public int bacteriaCounter = 1;
        [Header("カーソルの速度を管理する変数")]
        public float cursorSpeed;
        GameObject bacteriaWinResult;
        GameObject alcoholWinResult;
        GameObject darkVeil;
        AlocoholCursorControler alocoholCursorControler;
        BacteriaCursorControler bacteriaCursorControler;
        public bool isGameRunning = true;
        void Start()
        {
            remainingTime = gameOverTime;
            temperaturePercentage = defaultTemperaturePercentage;
            bacteriaWinResult = GameObject.Find("bacteriaWinResult");
            alcoholWinResult = GameObject.Find("alcoholWinResult");
            darkVeil = GameObject.Find("darkVeil");
            alocoholCursorControler = GameObject.Find("alcohol Cursor image").GetComponent<AlocoholCursorControler>();
            bacteriaCursorControler = GameObject.Find("bacteria Cursor image").GetComponent<BacteriaCursorControler>();
        }

        void Update()
        {
            if (isGameRunning)
            {
                //残り時間を計算する式
                remainingTime -= Time.deltaTime;
                //表示角度を計算
                float timerRatio = remainingTime / gameOverTime;
                //タイマーの表示更新
                UpdateTimerDisplay(timerRatio);
                //温度計の表示温度を更新
                UpdateThermometerDisplay(temperaturePercentage);
                if (remainingTime < 0f || bacteriaCounter == 0)
                {
                    //ゲームオーバー処理を呼び出す
                    GameOver();
                }
            }
        }

        void UpdateTimerDisplay(float ratio)
        {
            //タイマーの表示角度を更新
            timerCircle.fillAmount = ratio;
        }

        void UpdateThermometerDisplay(float temperaturePercentage)
        {
            //右の温度計の表示温度を更新
            rightThermometer.fillAmount = temperaturePercentage;
            //左の温度計の表示温度を更新
            leftThermometer.fillAmount = temperaturePercentage;
        }

        void GameOver()
        {
            isGameRunning = false;
            if (remainingTime < 0f)
            {
                bacteriaCounter = 128;
                bacteriaWinResult.transform.DOMoveY(0, 1.5f);
            }
            else
            {
                alcoholWinResult.transform.DOMoveY(0, 1.5f);
            }
            darkVeil.transform.position = Vector2.zero;
        }

        public void TemperatureIncrease()
        {
            temperaturePercentage += rateOfTempertureIncrease;
            if (temperaturePercentage >= 1f)
            {
                temperaturePercentage = 1f;
            }
        }

        public void TemperatureDecrease()
        {
            temperaturePercentage -= rateOfTempertureDecrease;
            if (temperaturePercentage <= 0f)
            {
                temperaturePercentage = 0f;
            }
        }
    }
}
