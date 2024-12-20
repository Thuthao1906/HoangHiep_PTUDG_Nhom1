using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ThanhMau : MonoBehaviour
{
    public Image thanhMau;
    float mauHienTai;
    float mauBandau;
    public void CapNhatThanhMau(float mauHienTai,float mauBandau)
    {
        thanhMau.fillAmount= mauHienTai/mauBandau;
    }
}
