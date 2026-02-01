using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class IconImage : MonoBehaviour
{
    public IconType type;
    public TMP_Text amountText;

    private void Update()
    {
        CheckModifier();
        UpdateAmount();
    }

    public void CheckModifier()
    {
        bool destroy = false;

        if(type == IconType.Poison && GetComponentInParent<Poison>() == null )
        {
            destroy = true;
        }

        if (type == IconType.Laugh && GetComponentInParent<Laugh>() == null)
        {
            destroy = true;
        }

        if (type == IconType.Thorns && GetComponentInParent<Thorns>() == null)
        {
            destroy = true;
        }

        if (type == IconType.Bandages && GetComponentInParent<Bandages>() == null)
        {
            destroy = true;
        }

        if(destroy)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateAmount()
    {
        if(type == IconType.Poison)
        {
            Poison poison = GetComponentInParent<Poison>();
            if(poison == null)
            {
                return;
            }
            amountText.text = poison.poisonStacks.ToString();
        }
        if (type == IconType.Thorns)
        {
            Thorns thorns = GetComponentInParent<Thorns>();
            if(thorns == null)
            {
                return;
            }
            amountText.text = thorns.thornsStack.ToString();
        }
        if (type == IconType.Bandages)
        {
            Bandages bandages = GetComponentInParent<Bandages>();
            if(bandages == null)
            {
                return;
            }
            amountText.text = bandages.bandagesStack.ToString();
        }
    }
}
