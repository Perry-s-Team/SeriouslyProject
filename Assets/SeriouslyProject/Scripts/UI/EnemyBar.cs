public class EnemyBar : Bar
{
    private void Start()
    {
        GetEnemyComponent();

        GetImageHealthComponent();
        GetImageManaComponent();
    }

    private void FixedUpdate()
    {
        ChangeHealthAmount();
        ChangeManaAmount();
    }

    private void ChangeHealthAmount()
    {
        imageToHealth.fillAmount = enemy.Health;
    }

    private void ChangeManaAmount()
    {
        imageToMana.fillAmount = enemy.Mana;
    }
}
