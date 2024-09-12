using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerAvatar : BaseAvatar
{

    [SerializeField] float maxEnergy;
    float energy;
    bool burnout;
    ProjectileLauncher launcher;

    public delegate void OnDeathEvent();
    public static event OnDeathEvent onDeathEvent;

    private void Start()
    {
        launcher = GetComponent<ProjectileLauncher>();
        energy = maxEnergy;
        health = maxHealth;
        burnout = false;
        StartCoroutine(EnergyRegeneration());
    }

    IEnumerator EnergyRegeneration()
    {
        while (true)
        {
            if (burnout)
            {
                energy += 0.75f;
            }
            else if (!launcher.IsFiring())
            {
                energy += 1;
            }
            if (energy >= maxEnergy)
            {
                burnout = false;
                energy = maxEnergy;
            }
            if (energy <= 0)
            {
                burnout = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public bool IsBurnout()
    {
        return burnout;
    }

    public bool Cost(float amount)
    {
        if (energy < amount)
        {
            return false;
        }
        else
        {
            energy -= amount;
            return true;
        }
    }

    public float GetEnergyRatio()
    {
        return energy/maxEnergy;
    }

    protected override void Die()
    {
        onDeathEvent?.Invoke();
        Destroy(gameObject);
    }

}
