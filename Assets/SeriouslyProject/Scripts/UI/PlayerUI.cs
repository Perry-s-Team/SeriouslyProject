using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private List<Tongue> tongues;

    public void OpenPlayerUI()
    {
        for (int i = 0; i < tongues.Count; i++)
        {
            tongues[i].index = i;
            tongues[i].Init(OnTongueSelected);
        }

        if (tongues.Count > 0)
        {
            SelectTongue(0);
            tongues[0].PlaySelectAnimation();
        }
    }

    private void OnTongueSelected(int selectedIndex)
    {
        SelectTongue(selectedIndex);
    }

    private void SelectTongue(int selectedIndex)
    {
        for (int i = 0; i < tongues.Count; i++)
        {
            tongues[i].IsSelected = (i == selectedIndex);
        }
    }
}
