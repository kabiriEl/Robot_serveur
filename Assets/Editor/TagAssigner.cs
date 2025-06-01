using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq; 

public class TagAssigner : MonoBehaviour
{
    [MenuItem("Tools/Tag All Objects As Obstacle")]
    static void TagAllObjectsAsObstacle()
    {
       
        if (!UnityEditorInternal.InternalEditorUtility.tags.Contains("Obstacle"))
        {
            Debug.LogError("Le tag 'Obstacle' n'existe pas. Va dans Tags & Layers et crée-le d'abord.");
            return;
        }

        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject obj in allObjects)
        {
            
            if (obj.hideFlags == HideFlags.None && obj.activeInHierarchy && obj.GetComponent<Comportement>() == null)
            {
                obj.tag = "Obstacle";
                count++;
            }
        }

        Debug.Log($"Tag 'Obstacle' appliqué à {count} objets.");
    }
}

