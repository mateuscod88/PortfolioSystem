using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers.Calculator.Interfaces
{
    public interface IAgregationCalculation
    {
        Dictionary<string, float> DoCalculation(string ISIN, DateTime date);
    }
}
