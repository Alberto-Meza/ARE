using System;
using ARE.Shared.Entities;

namespace ARE.Shared.Utils
{
    public static class Converter
    {


        public static List<TDestino>? CopyTo<TOrigen,TDestino>(this List<TOrigen> Origens,TDestino type) where TDestino : class
        {

            List<TDestino> Destins = new List<TDestino>();

            Origens.ForEach(row => {

                var Item = Activator.CreateInstance(type.GetType());

                Item.GetType().GetProperties().ToList().ForEach(prop => {

                    var PropAdd = row.GetType().GetProperty(prop.Name);
                    if (PropAdd != null)
                    {
                        Item.GetType().GetProperty(prop.Name).SetValue(Item, PropAdd.GetValue(row), null);

                    }
                });

                Destins.GetType().GetMethod("Add").Invoke(Destins, new[] { Item });

            });


            return Destins;
        }


        /*public static List<TDestino> ConvertTo<TOrigen,TDestino>(this List<TOrigen> Origens)
        {
            var Destins = new List<TDestino>();
            var properties = Origens[0].GetType().GetProperties();
            
            var Item = Activator.CreateInstance(Destins.GetType());
           var ItemTest = Destins.FirstOrDefault().GetType().GetProperties();
            var ItenNew = Activator.CreateInstance(Destins.FirstOrDefault().GetType());

            Origens.ForEach(row => {

                properties.ToList().ForEach(prop => {

                });

            });

        

            return Destins;
        }
        */


    }
}

