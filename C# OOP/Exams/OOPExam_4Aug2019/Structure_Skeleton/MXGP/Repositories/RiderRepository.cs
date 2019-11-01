﻿namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }
        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders.AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            return this.riders.FirstOrDefault(r => r.Name == name);
        }

        public bool Remove(IRider model)
        {
            return this.riders.Remove(model);
        }
    }
}
