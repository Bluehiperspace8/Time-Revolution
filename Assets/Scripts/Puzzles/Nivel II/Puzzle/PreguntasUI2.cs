using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/*
 Clase Pregunta UI control de la UI
 Autor: Roberto Valdez Jasso
 */

public class PreguntasUI2 : MonoBehaviour
{

    [SerializeField] private Text m_pregunta = null;
    [SerializeField] private List<BotonesOpciones2> m_listaBotones = null;

    public void Construct(pregunta2 q, Action<BotonesOpciones2> callback)
    {
        m_pregunta.text = q.texto;

        for (int n = 0; n < m_listaBotones.Count; n++)
        {
            m_listaBotones[n].Construct(q.opciones[n], callback);
        }
    }
}
