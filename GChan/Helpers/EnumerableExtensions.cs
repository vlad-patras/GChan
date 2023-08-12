﻿using GChan.Models;
using System;
using System.Collections.Generic;

namespace GChan.Helpers
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static IEnumerable<ImageLink> MaybeRemoveAlreadySavedLinks(
            this IEnumerable<ImageLink> links,
            bool includeAlreadySaved,
            SavedIdsCollection savedIds
            )
        {
            foreach (var link in links)
            {
                var alreadySaved = savedIds.Contains(link.Tim);

                if (includeAlreadySaved || !alreadySaved)
                {
                    yield return link;
                }
            }
        }
    }
}
