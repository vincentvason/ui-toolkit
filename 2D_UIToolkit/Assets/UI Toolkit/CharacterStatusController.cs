using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Platformer.Mechanics;

public class CharacterStatusController : MonoBehaviour
{
    public GameObject player;

    void OnEnable()
    {
        VisualElement root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        root.Q<CharacterStatus>().dataSource = player.GetComponent<Health>();
    }
}
