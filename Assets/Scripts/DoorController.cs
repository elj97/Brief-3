using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DoorController : MonoBehaviour
{
    public int id;

    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
    }

    private void OnDoorwayClose (int id)
    {
        if (id == this.id)
        {
            LeanTween.moveLocalZ(gameObject, 0.4f, 1f).setEaseInQuad();
        }
    }
    private void OnDoorwayOpen(int id)
    {
        if (id == this.id)
        {
            LeanTween.moveLocalZ(gameObject, 1.6f, 1f).setEaseOutQuad();
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit -= OnDoorwayClose;
    }
}

