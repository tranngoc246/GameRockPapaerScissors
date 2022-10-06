using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImage : Singleton<RandomImage>
{
    public Sprite rockImg;
    public Sprite paperImg;
    public Sprite scissorImg;
    Image m_image;
    public override void Awake()
    {
        MakeSingleton(false);
    }
    public override void Start()
    {
        base.Start();
        m_image = GetComponent<Image>();
    }
    public void SetImages(int n)
    {
        if (n == 0 && rockImg)
            m_image.sprite = rockImg;
        else if (n == 1 && paperImg)
            m_image.sprite = paperImg;
        else if(scissorImg)
            m_image.sprite = scissorImg;
    }
}
