using System;

namespace FortnoxAccessToken.Dal
{
	public interface IDalManager : IDisposable
	{
		T GetProvider<T>() where T : class;
	}
}
