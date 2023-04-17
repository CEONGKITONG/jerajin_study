using System;

class DelegateParameter
{
    delegate void Runner();

    static void Main()
    {
        RunnerCall(new Runner(Go));
        RunnerCall(new Runner(Back));
    }

    static void RunnerCall(Runner runner) => runner();  // 넘어온 메서드 실행 (runner 가 어떤 메서드 이던간에 파라미터 형식과 리턴 형식만 맞으면 넘긴 메서드를 그대로 실행한다.)

    static void Go() => Console.WriteLine("직진");
    static void Back() => Console.WriteLine("후진");

}

