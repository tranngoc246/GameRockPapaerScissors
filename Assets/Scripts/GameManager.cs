using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public Sprite rockImg;
    public Sprite paperImg;
    public Sprite scissorImg;
    public TextMeshProUGUI resultText;

    int m_imageId;

    public override void Awake()
    {
        MakeSingleton(false);
    }
    public override void Start()
    {
        base.Start();

        AudioController.Ins.PlayBackgroundMusic();
    }
    public void RandomImages(int n)
    {
        m_imageId = Random.Range(0, 3);
        RandomImage.Ins.SetImages(m_imageId);
        resultText.gameObject.SetActive(true);
        if (resultText)
        {
            int result = CheckResult(n, m_imageId);
            if (result == 0)
            {
                resultText.text = "Draw";
                AudioController.Ins.PlaySound(AudioController.Ins.drawSound);
            }
            else if (result == 1)
            {
                resultText.text = "You win";
                AudioController.Ins.PlaySound(AudioController.Ins.winSound);
            }
            else
            {
                resultText.text = "You lose";
                AudioController.Ins.PlaySound(AudioController.Ins.loseSound);
            }
        }
    }

    public int CheckResult(int a, int b)
    {
        int result;

        if (a == 0)
        {
            if (b == 0)
                result = 0;
            else if(b==1)
                result = -1;
            else
                result = 1;
        }
        else if (a == 1)
        {
            if (b == 0)
                result = 1;
            else if (b == 1)
                result = 0;
            else
                result = -1;
        }
        else 
        {
            if (b == 0)
                result = -1;
            else if (b == 1)
                result = 1;
            else
                result = 0;
        }
        return result;
    }
}
