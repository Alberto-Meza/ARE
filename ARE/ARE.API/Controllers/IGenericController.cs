using Microsoft.AspNetCore.Mvc;

namespace ARE.API.Controllers
{
	public interface IGenericController<T> where T : class
	{
        Task<ActionResult> GetAsync();

        //Task<ActionResult> GetAllAsync();

        Task<ActionResult> GetAsync(int id);

        Task<ActionResult> PostAsync(T model);

        Task<ActionResult> PutAsync(T model);

        Task<ActionResult> DeleteAsync(int id);

    }
}

