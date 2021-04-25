using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/*
 Clase Pregunta UI control de la UI
 Autor: Roberto Valdez Jasso
 */
public class PreguntasUI1 : MonoBehaviour
{
    [SerializeField] private Text m_pregunta = null;
    [SerializeField] private List<BotonesOpciones1> m_listaBotones = null;

    public void Construct(pregunta1 q, Action<BotonesOpciones1> callback)
    {
        m_pregunta.text = q.texto;

        for (int n = 0; n < m_listaBotones.Count; n++)
        {
            m_listaBotones[n].Construct(q.opciones[n], callback);
        }
    }
}
