namespace d01_ex00.Models
{
	public struct ExchangeSum
	{
		public double Sum {get; init;}
		public string Identificator {get; init;}
		public ExchangeSum(string i, double sum)
		{
			Sum = sum;
			Identificator = i;
		}

		public ExchangeSum(string str)
		{
			var strs = str.Split(':');
			if (strs.Length != 2 || !double.TryParse(strs[1], out var sum) || sum <= 0)
			{
				if (!int.TryParse(strs[1], out var sumInt) || sumInt <= 0)
					throw new System.ArgumentException("Wrong string format");
				sum = sumInt;
			}
			Sum = sum;
			Identificator = strs[0];
		}
		public override string ToString() => $"{Identificator}:{Sum:0.00}";
	}
}