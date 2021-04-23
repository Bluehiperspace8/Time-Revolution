using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image imagenFondo;


    // Start is called before the first frame update
    void Start()
    {
        imagenFondo.CrossFadeAlpha(1, 2, true);
    }

    
}
