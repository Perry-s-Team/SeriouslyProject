public class CharacterBar : Bar
{
    private void Start()
    {
        GetCharacterComponent();

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
        imageToHealth.fillAmount = character.Health;
    }

    private void ChangeManaAmount()
    {
        imageToMana.fillAmount = character.Mana;
    }
}