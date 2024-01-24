using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup UIPanel;

    [SerializeField] private bool m_fIn = false;
    [SerializeField] private bool m_fOut = false;

    public void FadeUI()
    {
        m_fIn = true;
    }

    void Update()
    {
        if(m_fIn)
        {
            if(UIPanel.alpha < 1)
            {
                UIPanel.alpha += Time.deltaTime;

                if(UIPanel.alpha >= 1)
                {
                    m_fIn = false;
                }
            }
        }

         if(m_fOut)
        {
            if(UIPanel.alpha >= 0)
            {
                UIPanel.alpha -= Time.deltaTime;

                if(UIPanel.alpha == 0)
                {
                    m_fOut = true;
                }
            }
        }
    }
    
}
