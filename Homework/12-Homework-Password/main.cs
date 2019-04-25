using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(CheckPassword("test") == "Failed");             // CheckPassword Testcode
    print(CheckPassword("toolongteststring") == "Failed");
    print(CheckPassword("samelettertest") == "Failed");
    print(CheckPassword("nouppercase") == "Failed");
    print(CheckPassword("NOLOWERCASE") == "Failed");
    print(CheckPassword("White Space") == "Failed");
    print(CheckPassword("Nospecialchar") == "Failed");
    print(CheckPassword("Testcomplete!") == "Pass");
  }

  public static string CheckPassword(string password) {
    string passupper = password.ToUpper();
    string passlower = password.ToLower();
    string spchar = "!@#$%^&*()?/>.<,:;'\\|}]{[_~`+=\"-";
    int uexist = 0;   // Upper, Lower, Special Character Count
    int lexist = 0;
    int spexist = 0;

    if (password.Length < 6 || 14 < password.Length) {  // Length Fail
      return "Failed";
    }

    for (int i = 0; i < password.Length - 1; i++) {     // Same letters Fail
      if (password[i] == password[i + 1]){
        return "Failed";
      }
    }

    for (int i = 0; i < password.Length; i++) {
      if (password[i] == passupper[i])
        uexist++;
    }

    for (int i = 0; i < password.Length; i++) {
      if (password[i] == passlower[i])
        lexist++;
    }

    if (uexist == 0) {                                  // Upper and Lower Fail
      return "Failed";
    }

    if (lexist == 0) {
      return "Failed";
    }

    if (password.IndexOf(" ") != -1) {                  // Whitespace Fail
      return "Failed";
    }

    for (int i = 0; i < password.Length; i++) {
      for (int j = 0; j < spchar.Length; j++) {
        if (password[i] == spchar[j])
          spexist++;
      }
    }

    if (spexist == 0) {                                 // Special Character Fail
      return "Failed";
    }

    return "Pass";
  }
}

/*
Check password 함수
주어진 password 문자열에 다음 규칙을 만족하는지 알려주는 CheckPassword(string password) 작성
1. 6~14자리까지 가능
2. 연속으로 동일 문자가 나오면 안됨
3. 적어도 하나의 소문자 포함
4. 적어도 하나의 대문자 포함
5. 적어도 하나의 특문 !@#$%^&*()?/>.<,:;'\|}]{[_~`+="-
6. 공백 문자(white space) 포함 불가
*/
