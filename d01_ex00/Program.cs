using System;
using d01_ex00;

if (args.Length != 2)
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    return;
}
try
{
    var exchanger = new Exchanger(args[1], args[0]);
    Console.WriteLine(
        $"Сумма в исходной валюте: {exchanger.InputSum.Sum} {exchanger.InputSum.Identificator}");
    foreach (var str in exchanger)
        Console.WriteLine(str);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
}