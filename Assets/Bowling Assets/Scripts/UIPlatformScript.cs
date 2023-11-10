using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlatformScript : MonoBehaviour
{
    [SerializeField] TMP_Text instructionText;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID || UNITY_IOS

#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDI
     instructionText.text = "Press A to Mobe LEFT and D to move RIGHT.\nHit the SPACE button to throw ball. to throw ball";

#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
