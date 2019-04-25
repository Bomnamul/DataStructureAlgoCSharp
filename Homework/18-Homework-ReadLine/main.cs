using System;

class MainClass {
  public static void Main (string[] args) {
    string a = "";
    string b = "";

    for (int i = 0; i < 2; i++) {
      Console.WriteLine("Input number.");
      string input = Console.ReadLine();
      if (i == 0) {
        a = input;
      } else {
        b = input;
      }
    }
    
    Console.WriteLine(Add(a, b));
  }

  public static string Add(string strA, string strB) {
    string temp;
    int ia;
    int ib;
    int carry = 0;
    int remainder = 0;
    string result = "";

    if (strB.Length > strA.Length) { // 긴 배열을 strA로 고정
      temp = strA;
      strA = strB;
      strB = temp;
    }

    int lengA = strA.Length;
    int lengB = strB.Length;

    for (int i = 0; i < lengA - lengB; i++) { // 배열의 길이를 비교하여 짧은 쪽의 앞부분에 0을 붙여 순서 보정 (Padding)
      strB = "0" + strB;
    }
    
    for (int i = strA.Length - 1; i > -1; i--) { // 배열의 뒤에서부터 정수타입으로 비교, carry가 1이면 포함하여 계산
      ia = int.Parse(strA[i].ToString());
      ib = int.Parse(strB[i].ToString());
      if (carry == 1) {
        remainder = carry + ia + ib > 9 ? carry + ia + ib - 10 : carry + ia + ib;
        carry = carry + ia + ib > 9 ? 1 : 0;
      } else {
        remainder = ia + ib > 9 ? ia + ib - 10 : ia + ib;
        carry = ia + ib > 9 ? 1 : 0;
      }
      result = remainder.ToString() + result; // 기존 결과값의 앞자리에 string타입으로 한자리씩 붙임
    }
    if (carry == 1) {
      result = carry.ToString() + result; // for문 이후에도 carry가 남아있을 경우 결과값의 맨 앞자리에 붙임
    }
    return result;
  }
}

/*
Add 함수 string타입 2개의 파라미터 받아서 carry remainder

string a, b를 받는다
a를 하나하나 int 타입으로 parse
b를 하나하나 int 타입으로 parse

끝에서부터 비교 후 더하기 승수 있으면 앞에 자리에 더하기 없으면 remainder저장
string result = @ + result

배열 길이 다를때 짧은 쪽은 0으로 나머지 채우기

*/

/*
for(int i = s1, j = s2; i >=0; i--, j--) {
  ...
}
이렇게 사용가능
삼항연산자로 j <= 0 ? ... 으로 Padding없이 할수있다
*/