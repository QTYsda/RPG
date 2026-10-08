using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }
    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }
    private void HandleAbilityPointSpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;
        switch(skillName)
        {
            case "MaxHealthBoost":
                数值管理器.Instance.UpdateMaxHealth(1);
                break;
            default:
                Debug.LogWarning("未知技能" + skillName);
                break;
        }
    }
}
