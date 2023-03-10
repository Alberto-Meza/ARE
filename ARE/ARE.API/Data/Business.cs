using System;
using ARE.Shared.DTOs;
using ARE.API.Helpers;
using ARE.Shared.Entities;

namespace ARE.API.Data
{
	public class Business
	{
        private readonly DataContext _context;

        public Business(DataContext context)
		{
            _context = context;
        }

		internal List<ItemCombo> GetCombo(string name)
		{
			List<ItemCombo> LstResult = new List<ItemCombo>();

			switch (name.ToUpper())
			{
				case "PAIS":
					LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Pais --" });
					_context.Countries.ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
					break;
				default:
					break;
			}


			return LstResult;
		}


        internal List<ItemCombo> GetComboByFilter(string name, List<FilterDTO> Filters)
        {
            List<ItemCombo> LstResult = new List<ItemCombo>();

            switch (name.ToUpper())
            {
                case "STATE":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Estado --" });
                    _context.States.AsQueryable().WhereCondition(Filters,new State()).ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "CITY":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Ciudad --" });
                    _context.Cities.AsQueryable().WhereCondition(Filters, new City()).ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                default:
                    break;
            }


            return LstResult;
        }


       

    }
}

