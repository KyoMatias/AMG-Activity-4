using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTrack : MonoBehaviour
{


    [SerializeField] private Transform m_point0;
    [SerializeField] private Transform m_point1;
    [SerializeField] private Transform m_point2;

    [SerializeField] private Transform m_enemyRoot;
    [SerializeField] private float m_time;

    float m_currentTime;


    // Start is called before the first frame update
    void Start()
    {
        m_currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_point2 == null
                || m_point1 == null
                ||m_point0 == null
                ||m_enemyRoot == null) return;


                m_currentTime += Time.deltaTime;
                var PercentTIme = m_currentTime /m_time;
                var newPos = BezierCurve.QuadraticLerp(m_point0.position, m_point1.position, m_point2.position, PercentTIme);
                m_enemyRoot.position = newPos;
    }
}
