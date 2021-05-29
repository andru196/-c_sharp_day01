using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using d01_ex00.Models;

namespace d01_ex00
{
	public class Exchanger
	{
		public ExchangeSum InputSum {get; private set;}
		List<ExchangeRate> Rates;

		public Exchanger(string path, string input)
		{
			var inps = input.Split(' ');
			InputSum = new ExchangeSum(inps[1], double.Parse(inps[0]));
			Rates = new List<ExchangeRate>();
			foreach (var filepath in Directory.GetFiles(path))
			{
				var file = new FileInfo(filepath);
				var from = new ExchangeSum(
					$"{file.Name.Replace(file.Extension, "")}:1");
				var lines = File.ReadAllLines(file.FullName);
				foreach (var line in lines)
				{
					var rate = new ExchangeRate()
					{
						From = from,
						To = new ExchangeSum(line)
					};
					Rates.Add(rate);
				}
			}
		}

		public IEnumerator GetEnumerator()
		{
			var resultList = new List<ExchangeRate>();
			foreach (var rate in Rates)
			{
				if (rate.From.Identificator == InputSum.Identificator)
					resultList.Add(new ExchangeRate()
					{
						From = InputSum,
						To = rate.To
					});
			}
			if (resultList.Count == 0)
				foreach (var rate in Rates)
				{
					if (rate.To.Identificator == InputSum.Identificator)
						resultList.Add(new ExchangeRate()
						{
							From = InputSum,
							To = new ExchangeSum(rate.From.Identificator,
								1 / rate.To.Sum)
						});
				}

			foreach (var rate in resultList)
				yield return rate.ToString();
		}
	}
}