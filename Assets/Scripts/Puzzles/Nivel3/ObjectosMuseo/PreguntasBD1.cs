using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
/*
 Clase pregunta BD PARA puzzle
 Autor: Roberto Valdez Jasso
 */
public class PreguntasBD1 : MonoBehaviour
{
    [SerializeField] private List<pregunta1> listapregunta = null;

    private List<pregunta1> M_Backup = null;

    private void Awake()
    {
        M_Backup = listapregunta.ToList();
    }

    // Removiendo la preguntas de la BD
    public pregunta1 GETRandom(bool remove = true)
    {
        if (listapregunta.Count == 0)
        {
            RestoreBackup();
        }

        int index = Random.Range(0, listapregunta.Count);
        //print(index);
        //print(listapregunta.Count);
        if (!remove)
        {
            return listapregunta[index];
        }

        pregunta1 q = listapregunta[index];
        //print(q.texto);
        listapregunta.RemoveAt(index);
        return q;
    }

    private void RestoreBackup()
    {
        listapregunta = M_Backup.ToList();
    }
}
