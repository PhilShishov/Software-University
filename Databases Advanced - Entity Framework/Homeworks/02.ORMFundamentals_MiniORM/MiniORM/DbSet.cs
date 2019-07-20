﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
    // TODO: Create your DbSet class here.
    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {

        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();

            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }
        internal IList<TEntity> Entities { get; set; }

        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        public int Count
            => this.Entities.Count;
        public bool IsReadOnly 
            => this.Entities.IsReadOnly;

        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            this.Entities.Add(item);

            this.ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (this.Entities.Any())
            {
                var current = this.Entities.First();
                this.Remove(current);
            }
        }

        public bool Contains(TEntity item)
            => this.Entities.Contains(item);

        public void CopyTo(TEntity[] array, int arrayIndex)
            => this.Entities.CopyTo(array, arrayIndex);

        public bool Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            bool isRemoved = this.Entities.Remove(item);

            if (isRemoved)
            {
                this.ChangeTracker.Remove(item);
            }

            return isRemoved;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
        }

        public IEnumerator<TEntity> GetEnumerator()
            => this.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

    }
}