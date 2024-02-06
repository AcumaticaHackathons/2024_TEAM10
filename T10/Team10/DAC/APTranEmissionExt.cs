using PX.Data;

namespace Team10
{
    public sealed class APTranEmissionExt : PXCacheExtension<PX.Objects.AP.APTran>
    {

        #region UsrEmissionID
        [PXDBInt]
        [PXSelector(
            typeof(EmissionType.emissionID),
            typeof(EmissionType.emissionCD),
            SubstituteKey = typeof(EmissionType.emissionCD)
            )]
        [PXUIField(DisplayName = "Emission ID")]
        public int? UsrEmissionID { get; set; }
        public abstract class usrEmissionID : PX.Data.BQL.BqlInt.Field<usrEmissionID> { }
        #endregion

        #region UsrEmissionUOM
        [PXDBString]
        [PXUIField(DisplayName = "Emission UOM")]
        public string UsrEmissionUOM { get; set; }
        public abstract class usrEmissionUOM : PX.Data.BQL.BqlString.Field<usrEmissionUOM> { }
        #endregion

        #region UsrEmissionValue
        [PXDBDecimal(2)]
        [PXUIField(DisplayName = "Emission Value")]
        public decimal? UsrEmissionValue { get; set; }
        public abstract class usrEmissionValue : PX.Data.BQL.BqlDecimal.Field<usrEmissionValue> { }
        #endregion

        #region Qty
        public abstract class qty : PX.Data.BQL.BqlDecimal.Field<qty> { }
        #endregion

        #region UsrExtEmissionValue
        [PXDBDecimal(2)]
        [PXUIField(DisplayName = "Ext. Emission Value")]

        [PXFormula(typeof(Mult<qty, usrEmissionValue>))]
        public decimal? UsrExtEmissionValue { get; set; }
        public abstract class usrExtEmissionValue : PX.Data.BQL.BqlDecimal.Field<usrExtEmissionValue> { }
        #endregion
    }
}