using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalCompanionApp
{
    public class GridControlModel
    {
        public RawData Data { get; set; }
        public Config Config { get; set; }
        public ContactInfo Contact { get; set; }
        public int IncidentCount { get; set; }
        public int RowIndex { get; set; }
    }
}
