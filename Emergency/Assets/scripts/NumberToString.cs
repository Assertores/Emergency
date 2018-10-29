using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumberToString {

    public static string MakeString(float num) {
        return MakeString((int)num);
    }

    public static string MakeString(uint num){
        return MakeString((int)num);
    }

    public static string MakeString(int num){
        string einheit;
        int temp = (int)Mathf.Log10(num) % 100;//dass stimmt irgendwie nicht
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
        num = (int)(num / 100);
        return num.ToString() + einheit;
    }
}
