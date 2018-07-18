using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    public static scoreManager instance;
    public Text scoreText, HPText, TimeText;
    private int score = 0; //점수를 관리합니다.
    private int HP = 4;
    private string time;
    private string HPbar;
    void Awake()
    {
        if (!instance)
            instance = this;
    }
    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }
    public void DecreaseHP(int num)
    {
        HP -= num;
        HPbar = "";
        for (int i = 0; i < HP; i++)
            HPbar += "♥";
        HPText.text = HPbar;//"HP : " + HP;
    }
    public void IncreaseHP(int num)
    {
        HP += num;
        HPbar = "";
        for (int i = 0; i < HP; i++)
            HPbar += "♥";
        HPText.text = HPbar;
        //HPText.text = "HP : " + HP;
    }
    public void UpdateTime(float t)
    {
        int m = (int)t / 60;
        int s = (int)t % 60;
        time = m.ToString("00") + ":" + s.ToString("00");
        TimeText.text = time;
    }
}
