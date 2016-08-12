using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboBears.DataContracts;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Year
    {
        [Key]
        public int YearId { get; set; }

        public ICollection<Competition> Competitions { get; set; }

        public Game Game { get; set; }
        public ICollection<Member> Members { get; set; }

        public static explicit operator DataContracts.Year(Year value)
        {
            return new DataContracts.Year()
            {
                YearId = value.YearId,
                Competitions = value.Competitions.Select(c => (DataContracts.Competition)c),
                Game = (DataContracts.Game)value.Game
            };
        }

        public static explicit operator Year(DataContracts.Year value)
        {
            return new Year()
            {
                YearId = value.YearId,
                Competitions = value.Competitions.Select(c => (Competition)c).ToArray(),
                Game = (Game)value.Game
            };
        }
    }
}
