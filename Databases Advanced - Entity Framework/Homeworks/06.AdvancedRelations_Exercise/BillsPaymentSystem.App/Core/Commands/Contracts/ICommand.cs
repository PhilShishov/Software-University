using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
