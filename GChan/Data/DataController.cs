﻿using EFCore.BulkExtensions;
using GChan.Data.Models;
using GChan.Models.Trackers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChan.Data
{
    public static class DataController
    {
        /// <summary> 
        /// Make sure this is called before any other data access.
        /// </summary>
        public static async Task EnsureCreatedAndMigrate()
        {
            using var context = NewContext();
            await context.Database.MigrateAsync();
        }

        /// <summary>
        /// Saves the thread and board lists to disk.
        /// </summary>
        public static async Task Save(IList<Thread> threads, IList<Board> boards)
        {
            var threadData = threads.Select(t => new ThreadData(t));
            var boardData = boards.Select(b => new BoardData(b));

            await using var context = NewContext();

            await context.BulkInsertOrUpdateAsync(boardData);
            await context.BulkInsertOrUpdateAsync(threadData);

            await context.SaveChangesAsync();
        }

        public static async Task<(IReadOnlyList<ThreadData> ThreadData, IReadOnlyList<BoardData> BoardData)> Load()
        {
            await using var context = NewContext();

            var threadData = await context.ThreadData.ToArrayAsync();
            var boardData = await context.BoardData.ToArrayAsync();

            return (threadData, boardData);
        }

        public static async Task RemoveBoard(IEnumerable<Board> boards)
        {
            var boardDatas = boards.Select(b => new BoardData(b));
            await using var context = NewContext();

            try
            {
                context.BoardData.RemoveRange(boardDatas);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex) when (ex.Message.Contains("affected") && ex.Message.Contains("row(s)")) // E.g. "Affected 0 row(s)".
            {
                // Swallow exceptions when we delete but there was nothing in the database to be deleted.
                // This will happen if a board is added and removed before being saved to database. We don't care.
            }
        }

        public static async Task RemoveThreads(IEnumerable<Thread> threads)
        {
            var threadDatas = threads.Select(t => new ThreadData(t));
            await using var context = NewContext();

            try
            {
                context.ThreadData.RemoveRange(threadDatas);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex) when (ex.Message.Contains("affected") && ex.Message.Contains("row(s)")) // E.g. "Affected 0 row(s)".
            {
                // Swallow exceptions when we delete but there was nothing in the database to be deleted.
                // This will happen if a thread is added and removed before being saved to database. We don't care.
            }
        }

        public static async Task RemoveAllBoards()
        {
            await using var context = NewContext();
            await context.BoardData.ExecuteDeleteAsync();
        }

        public static async Task RemoveAllThreads()
        {
            await using var context = NewContext();
            await context.ThreadData.ExecuteDeleteAsync();
        }

        private static DataContext NewContext()
        {
            return new DataContext();
        }
    }
}
