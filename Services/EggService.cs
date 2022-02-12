using Blazored.LocalStorage;

namespace BlazorSandbox.Services
{
	public class EggService
	{
		public event Action OnChange;

		private readonly ILocalStorageService _localStorageService;

		public EggService(ILocalStorageService localStorageService)
		{
			this._localStorageService = localStorageService;
		}

		public async Task<int> GetEggs()
		{
			int currentEggs =  await _localStorageService.GetItemAsync<int>("Eggs");
			return currentEggs;
		}

		public async Task AddEgg()
		{
			int newEggs = await GetEggs();
			if (newEggs == null)
			{
				newEggs = 0;
			} else
            {
				newEggs += 1;
            }
			await _localStorageService.SetItemAsync("Eggs", newEggs);
			OnChange?.Invoke();
		}
	}
}
