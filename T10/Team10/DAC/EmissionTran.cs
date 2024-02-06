using System;
using PX.Data;

namespace Team10
{
    [Serializable]
    [PXCacheName("Emission Transaction")]
    public class EmissionTran : IBqlTable
    {

        #region TranID
        [PXInt]
        public virtual int? TranID { get; set; }
        public abstract class tranID : PX.Data.BQL.BqlInt.Field<tranID> { }
        #endregion

        #region EmissionID
        [PXInt]
        [PXUIField(DisplayName = "Emission ID")]
        [PXSelector(
            typeof(EmissionType.emissionID),
            typeof(EmissionType.emissionCD),
            SubstituteKey = typeof(EmissionType.emissionCD)
            )]
        public virtual int? EmissionID { get; set; }
        public abstract class emissionID : PX.Data.BQL.BqlInt.Field<emissionID> { }
        #endregion
    }
}
