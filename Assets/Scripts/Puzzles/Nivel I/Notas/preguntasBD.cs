using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
/*
 Clase pregunta BD
 Autor: Roberto Valdez Jasso
 */
public class preguntasBD : MonoBehaviour
{
    [SerializeField] private List<pregunta> listapregunta = null;

    private List<pregunta> M_Backup = null;

    private void Awake()
    {
        M_Backup = listapregunta.ToList();
    }

    // Removiendo la preguntas de la BD
    public pregunta GETRandom(bool remove = true) 
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

        pregunta q = listapregunta[index];
        //print(q.texto);
        listapregunta.RemoveAt(index);
        return q;
    }

    private void RestoreBackup()
    {
        listapregunta = M_Backup.ToList();
    }
}
