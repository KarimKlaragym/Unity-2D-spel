using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] GameObject highlighter;

    GameObject currentTarget;
    public void Highlight(GameObject target)
    {
        if (currentTarget == target)
        {
            return;
        }
        currentTarget = target;
        Vector3 postion= target.transform.position + Vector3.up * 0.8f;
        Highlight(postion);
    }

    public void Highlight(Vector3 postion)
    { 
    
        highlighter.SetActive(true);
        highlighter.transform.position = postion;
    }

    public void Hide()
    {
        currentTarget = null;
        highlighter.SetActive(false);
    }
}
