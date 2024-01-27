using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialLerps : MonoBehaviour
{

    [SerializeField] private Transform m_point0;
    [SerializeField] private Transform m_point1;
    [SerializeField] private Transform m_point2;

    [SerializeField] private Transform m_enemyRoot;
    [SerializeField] private float m_time;

    private bool m_tutorialStarted;
    bool segment1, segment2;

    float m_currentTime;

    public delegate void ExecuteTutorial();
    public static ExecuteTutorial StartTutorial;
    void Awake()
    {
        m_tutorialStarted = false;
        path1 += LerpSeg1;
        path2 += LerpSeg2;
    }

    // Start is called before the first frame update
    void Start()
    {
        segment1 = false;
        StartTutorial +=StartTut;
        m_time = 10;
    }
     void StartTut()
     {
        m_tutorialStarted = true;
     }

    void Update()
    {
        if(m_tutorialStarted)
        {
        StartCoroutine(LerpMotion());
        }
    }
    
   IEnumerator LerpMotion()
    {


        private delegate void SegmentCheck();
    	private static SegmentCheck() path1;
    	private static SegmentCheck() path2;

                m_currentTime += Time.deltaTime;
                var PercentTIme = m_currentTime /m_time;
                var newPercentime = PercentTIme/m_time;


                //var seg1 = BezierCurve.LinearLerp(m_point0.position, m_point1.position, PercentTIme);
                //m_enemyRoot.position = seg1;

                var seg1 = BezierCurve.LinearLerp(m_point0.position, m_point1.position, PercentTIme);
                var seg2 = BezierCurve.LinearLerp(m_point1.position, m_point2.position, PercentTIme);
    			RunLerps();

    }

    Void RunLerps(){

        if(!segment1)
    	{
    			LerpSeg1?.Invoke();
    			yield return new WaitForSeconds(1);
    		} 
    		else if(segment1)
    		{
    			LerpSeg2?.Invoke();
    		}  
    		
    	}      

    IEnumerator LerpSeg1()
    {
    	var seg1 = BezierCurve.LinearLerp(m_point0.position, m_point1.position, PercentTIme);
    }

    IEnumerator LerpSeg2()
    {
		var seg2 = BezierCurve.LinearLerp(m_point1.position, m_point2.position, PercentTIme);
    }

	}
}
