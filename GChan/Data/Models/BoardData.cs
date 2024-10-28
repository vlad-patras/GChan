﻿using GChan.Models.Trackers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

namespace GChan.Data.Models
{
    [PrimaryKey(nameof(Site), nameof(Code))]
    public class BoardData
    {
        public Site Site { get; set; }

        /// <summary>
        /// The code of the board with no slashes (e.g. "wsg").
        /// </summary>
        public string Code { get; set; }

        public long GreatestThreadId { get; set; }

        public DateTimeOffset? LastScrape { get; set; }

        /// <summary>
        /// Parameterless constructor for Entity Framework.
        /// </summary>
        public BoardData() { }

        public BoardData(Board board)
        {
            Site = board.Site;
            Code = board.BoardCode.Trim('/');
            GreatestThreadId = board.GreatestThreadId;
            LastScrape = board.LastScrape;
        }
    }
}
