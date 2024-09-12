using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Slider healthBar;
    [SerializeField] Slider energyBar;

    PlayerAvatar player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindAnyObjectByType<PlayerAvatar>();
        }
        else
        {
            healthBar.value = player.GetHealthRatio();
            energyBar.value = player.GetEnergyRatio();
        }
    }
}
