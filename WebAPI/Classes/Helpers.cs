using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Helpers;

namespace WebAPI.Classes
{
    public interface IHelpers
    {
        Dates getDatesFromToday(int days);
    }
    public class Helpers : IHelpers
    {
        public Dates getDatesFromToday(int days)
        {
            DateTime Today = DateTime.Today;
            DateTime Today_NextDays = Today.AddDays(Convert.ToDouble(days));

            return new Dates() { StartDate = Today, EndDate = Today_NextDays };
        }
    }
}
