using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumberToString {

    public static string MakeString(float num) {
        return MakeString((uint)num);
    }

    public static string MakeString(int num){//überladung für andere zahlentypen
        return MakeString((uint)num);
    }

    public static string MakeString(uint num){
        if (num == 0)//sonst macht Log10 seltsame sachen
            return "0";

        string einheit;
        uint temp = (uint)Mathf.Log10(num)/3;//erechnet sich die tausender stellen (1.000, 1.000.000, usw)
        switch (temp) {
            case 1:
                einheit = "t";//tausend
                break;
            case 2:
                einheit = "M";//Million
                break;
            case 3:
                einheit = "B";//Billian
                break;
            case 4:
                einheit = "T";//Trillion
                break;
            case 5:
                einheit = "Qa";//Quadrillion
                break;
            case 6:
                einheit = "Qi";//Quintillion
                break;
            case 7:
                einheit = "Sx";//Sextillion
                break;
            case 8:
                einheit = "Sp";//Septillion
                break;
            case 9:
                einheit = "O";//Octillion
                break;
            case 10:
                einheit = "N";//Nonillion
                break;
            case 11:
                einheit = "D";//Decillion
                break;
            case 12:
                einheit = "Ud";//Undecillion
                break;
            case 13:
                einheit = "Dd";//Duodecillion
                break;
            case 14:
                einheit = "Td";//Tredecillion
                break;
            default:
                einheit = "";//default
                break;
        }
        num = (uint)((num/(Mathf.Pow(1000,temp)))+0.5f);//kürtzt die stellen hinten weck

        return num.ToString() + einheit;//setzt den string zusammen
    }
}
