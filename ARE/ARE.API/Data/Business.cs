using System;
using ARE.Shared.DTOs;
using ARE.API.Helpers;
using ARE.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using ARE.Shared.Enums;

namespace ARE.API.Data
{
	public class Business
	{
        private readonly DataContext _context;

        public Business(DataContext context)
		{
            _context = context;
        }


        #region Combos

        internal List<ItemCombo> GetCombo(string name)
		{
			List<ItemCombo> LstResult = new List<ItemCombo>();

			switch (name.ToUpper())
			{
				
                case "BLOODTYPE":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Tipo Sangineo --" });
                    _context.BloodTypes.ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "CIVILSTATUS":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Estado Civil --" });
                    _context.CivilStatuses.ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "DEPARTMENTS":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Departamento --" });
                    _context.Departments.ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "GENDER":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Genero --" });
                    LstResult.Add(new ItemCombo() { Value = "M", Text = " M " });
                    LstResult.Add(new ItemCombo() { Value = "F", Text = " F " });
                    break;
                case "PAIS":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Pais --" });
                    _context.Countries.ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "SCHOOLGRADES":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Grado --" });
                    _context.SchoolGrades.ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "STUDENTS":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Alumno --" });
                    _context.Students.ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "STUDENTTYPES":
                    //LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Grado --" });
                    _context.StudentTypes.ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "TYPEOFCHARGES":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Tipo Cobro --" });
                    _context.TypeOfCharges.ToList().ForEach(x => {
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
                case "CITY":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Ciudad --" });
                    _context.Cities.AsQueryable().WhereCondition(Filters, new City()).ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
                case "SUBTYPEOFCHARGES":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Sub Tipo --" });
                    _context.SubTypeOfCharges.AsQueryable().WhereCondition(Filters, new State()).ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name, Value2 = x.Price.ToString() });
                    });
                    break;
                case "STATE":
                    LstResult.Add(new ItemCombo() { Value = "0", Text = "-- Selecciona Estado --" });
                    _context.States.AsQueryable().WhereCondition(Filters,new State()).ToList().ForEach(x => {
                        LstResult.Add(new ItemCombo() { Value = x.Id.ToString(), Text = x.Name });
                    });
                    break;
               
                default:
                    break;
            }


            return LstResult;
        }
        #endregion


        #region Asistencias
        internal async Task<Assistance> CheckAlumno(Assistance model)
        {
            var entity = _context.Assistances.FirstOrDefaultAsync(x => x.StudentId == model.StudentId && x.EntryDate!.Value.Date == model.EntryDate!.Value.Date);

            if (entity.Result == null)//CHECADA ENTRADA
            { 

                var DateCharge =  _context.ChargeDates.Where(x => model.EntryDate!.Value.Date >= x.StartDate && model.EntryDate.Value.Date <= x.EndDate
                                            && x.ChargeDetail.Charge.StudentId == model.StudentId).FirstOrDefault();



                Assistance Check = new Assistance() { StudentId = model.StudentId
                                         , EntryDate = model.EntryDate
                                         , Status = (DateCharge == null ? AssistsStatusType.Inicial : AssistsStatusType.Pagado)
                                         , ChargeId = (DateCharge == null ? null: DateCharge.ChargeDetailId)
                };

                _context.Add(Check);
            }
            else if (entity.Result != null && model.EntryDate > entity.Result.EntryDate!.Value.AddMinutes(30)) //CHECADA SALIDA
            { 
                entity.Result.ExitDate = model.EntryDate;
                _context.Update(entity.Result);
            }


            await _context.SaveChangesAsync();

            return entity.Result;
        }
        #endregion



    }
}

