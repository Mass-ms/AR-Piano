using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleDetector : MonoBehaviour
{
    public ScaleManager scaleManager;
    public string scaleName = "";
    public string degreeName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectScale(ushort currentBit)
    {
        foreach (Scale scale in scaleManager.scaleList)
        {
            if (scale.ChordNote == currentBit)
            {
                scaleName = scale.ScaleName;
                degreeName = scale.DegreeName;
                Debug.Log($"Scale: {scale.ScaleName}, Degree:{scale.DegreeName}");
            }
        }
        
    }
}
