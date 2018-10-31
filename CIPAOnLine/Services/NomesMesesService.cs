using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Services
{
    public class NomesMesesService
    {
        private static Dictionary<int, string> _Meses = new Dictionary<int, string>
        {
            { 1, "Janeiro"},
            { 2, "Fevereiro" },
            { 3, "Março" },
            { 4, "Abril" },
            { 5, "Maio" },
            { 6, "Junho" },
            { 7, "Julho" },
            { 8, "Agosto" },
            { 9, "Setembro" },
            { 10, "Outubro" },
            { 11, "Novembro" },
            { 12, "Dezembro" }
        };

        public static string GetNomeMes(int num)
        {
            return _Meses[num];
        }
    }
}