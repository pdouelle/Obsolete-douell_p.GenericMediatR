using System;

namespace douell_p.GenericMediatR
{
    public class GenericTypesForMediatR
    {
        public Type Entity { get; set; }
        
        public Type QueryList { get; set; }
        public Type QueryById { get; set; }
        public Type Create { get; set; }
        public Type Update { get; set; }
        public Type Delete { get; set; }
    }
}