using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public Animator healthTextAnim;

    private void Start()
    {
        healthText.text = "HP:" + 数值管理器.Instance.currentHealth + "/" + 数值管理器.Instance.maxHealth;
    }
    public void ChangeHealth(int amount)
    {
        数值管理器.Instance.currentHealth += amount;
        healthTextAnim.Play("文本更新");
        healthText.text = "HP:" + 数值管理器.Instance.currentHealth + "/" + 数值管理器.Instance.maxHealth;
        if (数值管理器.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
