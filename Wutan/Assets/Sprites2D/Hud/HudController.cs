using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] Image HPBar;
    [SerializeField] Image Ability;

    [SerializeField] List<Sprite> Abilities;
    [SerializeField] TMPro.TMP_Text CDText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = (float)GameManager.Instance.PlayerScriptplayer.CurrentHp / (float)GameManager.Instance.PlayerScriptplayer.MaxHP;
        if (MagicMenuButtons.chosen != null)
        {
            Ability.sprite = Abilities[(int)MagicMenuButtons.chosen.ability];
            switch (MagicMenuButtons.chosen.ability)
            {
                case global::Abilities.Fire:
                    Ability.fillAmount = (Time.timeSinceLevelLoad - MagicMenu.instance.LastUseForFire) / (float)MagicMenu.instance.CDForFire;
                    break;
                case global::Abilities.Air:
                    Ability.fillAmount = (Time.timeSinceLevelLoad - MagicMenu.instance.LastUseForAir) / (float)MagicMenu.instance.CDForAir;
                    break;
                case global::Abilities.Light:
                    Ability.fillAmount = (Time.timeSinceLevelLoad - MagicMenu.instance.LastUseForLight) / (float)MagicMenu.instance.CDForLight;
                    break;
                case global::Abilities.Thunder:
                    Ability.fillAmount = (Time.timeSinceLevelLoad - MagicMenu.instance.LastUseForThunder) / (float)MagicMenu.instance.CDForThunder;
                    break;
            }
        }
    }
}
