using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public Text textoenergias;

    // Start is called before the first frame update
    void Start()
    {
        int numenergy = PlayerPrefs.GetInt("puntaje",3);
        textoenergias.text = numenergy.ToString();
        MueveBola.instance.puntaje = numenergy;
    }
    private void Awake()
    {
        instance = this;
    }
    public void ActualizaEnergias()
    {
        textoenergias.text = MueveBola.instance.puntaje.ToString();
    }
}
