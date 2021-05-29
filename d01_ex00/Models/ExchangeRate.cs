namespace d01_ex00.Models
{
	public class ExchangeRate
	{
		public ExchangeSum From {get; init;}
		public ExchangeSum To {get; init;}

		public override string ToString()
			=> $"Сумма в {To.Identificator}: {From.Sum * To.Sum:0.00} {To.Identificator}";
	}
}