using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace Team10
{
  public class EmissionTypeMaint : PXGraph<EmissionTypeMaint, EmissionType>
  {
        public SelectFrom<EmissionType>.View Emissions; 


  }
}