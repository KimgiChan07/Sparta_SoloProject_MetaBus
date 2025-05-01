using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    public virtual void SetUIShow()
    {
        gameObject.SetActive(true);
    }

    public virtual void SetUIHide()
    {
        gameObject.SetActive(false);
    }

}
