using System;
using System.ComponentModel;

namespace SweeneyVidyaGames.Web.Models
{
    public enum EGenreType
    {
        [Description("Action")]
        ACTION = 1,

        [Description("Indie")]
        INDIE = 2,

        [Description("Adventure")]
        ADVENTURE = 3,

        [Description("RPG")]
        RPG = 4,

        [Description("Strategy")]
        STRATEGY = 5,

        [Description("Shooter")]
        SHOOTER = 6,

        [Description("Casual")]
        CASUAL = 7,

        [Description("Simulation")]
        SIMULATION = 8,

        [Description("Arcade")]
        ARCADE = 9,

        [Description("Puzzle")]
        PUZZLE = 10,

        [Description("Platformer")]
        PLATFORMER = 11,

        [Description("Racing")]
        RACING = 12,

        [Description("Sports")]
        SPORTS = 13,

        [Description("MMO")]
        MMO = 14,

        [Description("Family")]
        FAMILY = 15,

        [Description("Fighting")]
        FIGHTING = 16,

        [Description("BoardGames")]
        BOARDGAMES = 17,

        [Description("Educational")]
        EDUCATIONAL = 18,

        [Description("Card")]
        CARD = 19
    }
}
