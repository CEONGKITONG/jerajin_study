using System;


class PassMethodAsParameter
{
    static int StringLength(string data) => data.Length;

    static void StringLengthPrint(Func<string, int> stringlength, string message) => Console.WriteLine($"메시지의 크기는 {stringlength(message)} 입니다.");

    static void Main() => StringLengthPrint(StringLength, "안녕하세요.");

    /*
        static void StringLengthPrint(Func<string, int> stringlength, string message)
	  => 첫번째 파라미터에 int 형을 리턴하는 함수를 넘기기 가능
		Func<string, int> stringlength = data.Length;  와 같은 표현

        StringLengthPrint(StringLength, "안녕하세요.");
     */

}