﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.DoorwayTriggerEnter(id);
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.DoorwayTriggerExit(id);
    }
}