using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("ゲームオーバーまでの時間設定")]
    [SerializeField] float gameOverTime;
    [Header("タイマーの円")]
    [SerializeField] Image timerCircle;
    [Header("温度計のパラメータ")]
    [SerializeField] Image rightThermometer;
    [SerializeField] Image leftThermometer;
    float remainingTime;
    void Start()
    {
        remainingTime = gameOverTime;
    }

    void Update()
    {
        //残り時間を計算する式
        remainingTime -= Time.deltaTime;
        //表示角度を計算
        float timerRatio = remainingTime / gameOverTime;
        //タイマーの表示更新
        UpdateTimerDisplay(timerRatio);

        if (remainingTime == 0f) {
            gameOver();
        }
    }

    void UpdateTimerDisplay(float ratio)
    {
        timerCircle.fillAmount = ratio;
    }

    void UpdateThermometerDisplay(float temperaturePercentage) {
        rightThermometer.fillAmount = temperaturePercentage;
        leftThermometer.fillAmount = temperaturePercentage;
    }

    void gameOver() {
        Debug.Log("ゲームオーバーだよ");
    }
}
