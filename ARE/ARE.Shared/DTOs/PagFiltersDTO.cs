using System;
namespace ARE.Shared.DTOs
{
	public class PagFiltersDTO
	{
		public PagFiltersDTO()
		{
			Pagination = new PaginationDTO();
			Filters = new List<FilterDTO>();
		}

		public PaginationDTO Pagination { get; set; }

		public List<FilterDTO> Filters { get; set; }
	}
}

