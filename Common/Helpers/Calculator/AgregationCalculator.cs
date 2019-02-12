using Common.Helpers.Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers
{
    public class AgregationCalculator
    {
        enum DataToAgregate { Currencys,Countrys,Types}
        private  IAgregationCalculation _agregationCalculation;
        public AgregationCalculator(IAgregationCalculation agregationCalculation)
        {
            this._agregationCalculation = agregationCalculation;
        }
        public void SetCalculation(IAgregationCalculation agregationCalculation)
        {
            this._agregationCalculation = agregationCalculation;
        } 
        public Dictionary<string,float> Calculate(string isin,DateTime date)
        {
            return this._agregationCalculation.DoCalculation(isin,date);
        }
    }
}
