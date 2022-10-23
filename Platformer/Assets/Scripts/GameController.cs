using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Image[] _images = new Image[3];
    [SerializeField] private Sprite[] _textures = new Sprite[2];
    [SerializeField] private GameObject _door;

    private void Start()
    {
        _door.SetActive(false);
    }

    private void Update()
    {
        CountOFKeysChange();
        DoorActive();
    }

    void DoorActive()
    {
        if (_playerController.countOfKeys == 3)
        {
            _door.SetActive(true);
        }
    }
    void CountOFKeysChange()
    {
        switch (_playerController.countOfKeys)
        {
            case 1:
                _images[0].sprite = _textures[1]; 
                break;
            case 2:
                _images[1].sprite = _textures[1]; 
                break;
            case 3: 
                _images[2].sprite = _textures[1]; 
                break;
        }
    }
}
