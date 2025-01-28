using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] StateEffect stateEffect;
    [SerializeField] float blinkDelaySeconds = 0.5f;

    [Header("HealthBar")]
    public Slider healthBar;
    public Gradient healthGgradient;
    public Image fill;

    public bool IsBlinking { get; set; } = true;

    public string Name { get;  set; }
    public string Description { get;  set; }

    public Image Sprite { get;  set; }

    public int Damage { get; set; }
    public int Heal { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Priority { get; set; }

    public void TakeDamage(int _damage)
    {
        Health -= _damage;
        healthBar.value = Health;
        SetGradient(healthBar.normalizedValue);
        Death();
    }

    internal void SetGradient(float _value)
    {
        fill.color = healthGgradient.Evaluate(_value);
    }

    public int GiveHeal()
    {
        return Heal;
    }

    public int GiveDamage()
    {
        return Damage;
    }

    public void Death()
    {
        if (Health <= 0)
        {
            Health = 0;
            Debug.Log(Name + ": Was Killed");
        }
    }

    public void TakeHeal(int _heal)
    {
        if (Health < MaxHealth)
        {
            Health += _heal;
            healthBar.value = Health;
            SetGradient(healthBar.normalizedValue);
        }
        else Health = MaxHealth;
    }

    public IEnumerator Blinking()
    {
        IsBlinking = true;
        Color color = Sprite.color;

        while (IsBlinking)
        {
            for (float i = 0; i < blinkDelaySeconds; i += Time.deltaTime)
            {
                color.a = Mathf.Lerp(1f, 0.5f, i / blinkDelaySeconds);
                Sprite.color = color;
                yield return null;
            }

            for (float i = 0; i < blinkDelaySeconds; i += Time.deltaTime)
            {
                color.a = Mathf.Lerp(0.5f, 1f, i / blinkDelaySeconds);
                Sprite.color = color;
                yield return null;
            }
        }
    }

    public enum StateEffect
    {
        None,
        Fire,
        Water,
        Air,
        Ground
    }
}
