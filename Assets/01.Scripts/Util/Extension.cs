using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public static class Extension
{
    public static string ConvertNumber(this TextMeshProUGUI text, string targetNumber)
    {
        char[] unitAlphabet = { 'K', 'M', 'B' };
        int unit = 0;
        float number = float.Parse(targetNumber);

        // 1000 이상일 때마다 단위를 올리고, 숫자를 1000으로 나눔
        while (number >= 1000 && unit < unitAlphabet.Length)
        {
            number *= 0.001f;
            unit++;
        }

        // 숫자가 100 이상이면 소수점 없이, 그 외는 소수점 한 자리까지 표시
        string formattedNumber;

        if (number >= 100)
        {
            formattedNumber = number.ToString("0");  // 소수점 없이 출력
        }
        else
        {
            formattedNumber = number.ToString("0.0");  // 소수점 한 자리까지 출력
        }

        // 단위가 있는 경우 붙여줌 (K, M, B)
        if (unit > 0)
        {
            formattedNumber += unitAlphabet[unit - 1];
        }

        // 최종 결과 반환
        return text.text = formattedNumber;
    }
}