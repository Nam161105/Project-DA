using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDescription : MonoBehaviour
{
    [SerializeField] protected GameObject _descriptionSkill1;
    [SerializeField] protected GameObject _descriptionSkill2;
    [SerializeField] protected GameObject _descriptionSkill3;
    [SerializeField] protected GameObject _descriptionDash;
   
    public void Skill1Des()
    {
        _descriptionSkill1.SetActive(true);
    }

    public void Skill2Des()
    {
        _descriptionSkill2.SetActive(true);
    }

    public void Skill3Des()
    {
        _descriptionSkill3.SetActive(true);
    }

    public void SkillDash()
    {
        _descriptionDash.SetActive(true);
    }
}
