using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixeye.Unity;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [Foldout("Health Setting", true)]
    [SerializeField] int health;
    [SerializeField] int maxHealth = 100;
    [SerializeField] bool gameOver;

    [Foldout("Keys Settings", true)]
    [SerializeField] KeyCode healKey = KeyCode.C;
    [SerializeField] KeyCode increaseHealthKey = KeyCode.D;
    [SerializeField] KeyCode takeDamageKey = KeyCode.X;

    Slider healthBar;

    public static HealthBar instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        healthBar = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("MaxHp"))
        {
            maxHealth = (int)PlayerPrefs.GetFloat("MaxHp");
            healthBar.maxValue = maxHealth;
        }
        else
        {
            healthBar.maxValue = maxHealth;
        }

        health = maxHealth;
    }

    void Update()
    {
        healthBar.value = health;

        if (Input.GetKeyDown(healKey))
        {
            Heal(10);
        }
        else if (Input.GetKeyDown(takeDamageKey))
        {
            TakeDamage(10);
        }else if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseMaxHP(10);
        }

        if(health <= 0)
        {
            health = 0;
            gameOver = true;
        }else if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Heal(int heal)
    {
        health += heal;
    }

    public void IncreaseMaxHP(int hpToAdd)
    {
        maxHealth += hpToAdd;
        healthBar.maxValue = maxHealth;
        PlayerPrefs.SetFloat("MaxHp", maxHealth);
    }
}
