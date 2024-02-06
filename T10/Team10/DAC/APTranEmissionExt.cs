using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.AP;
using PX.Objects.CM.Extensions;
using PX.Objects.Common.Discount.Attributes;
using PX.Objects.Common.Discount;
using PX.Objects.Common;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.DR;
using PX.Objects.EP;
using PX.Objects.FA;
using PX.Objects.GL.DAC.Abstract;
using PX.Objects.GL;
using PX.Objects.IN.Attributes;
using PX.Objects.IN;
using PX.Objects.PM;
using PX.Objects.PO;
using PX.Objects.TX;
using PX.Objects;
using System.Collections.Generic;
using System;

namespace Team10
{
    public class APTranEmissionExt : PXCacheExtension<PX.Objects.AP.APTran>
    {
        #region UsrEmissionID
        [PXDBInt]
        [PXUIField(DisplayName = "Emission ID")]
        public virtual int? UsrEmissionID { get; set; }
        public abstract class usrEmissionID : PX.Data.BQL.BqlInt.Field<usrEmissionID> { }
        #endregion

        #region UsrEmissionUOM
        [PXDBString]
        [PXUIField(DisplayName = "Emission UOM")]
        public virtual int? UsrEmissionUOM { get; set; }
        public abstract class usrEmissionUOM : PX.Data.BQL.BqlInt.Field<usrEmissionUOM> { }
        #endregion

        #region UsrEmissionValue
        [PXDBDecimal(19)]
        [PXUIField(DisplayName = "Emission Value")]
        public virtual int? UsrEmissionValue { get; set; }
        public abstract class usrEmissionValue : PX.Data.BQL.BqlDecimal.Field<usrEmissionValue> { }
        #endregion

        #region Qty
        public abstract class qty : PX.Data.BQL.BqlDecimal.Field<qty> { }
        #endregion

        #region UsrExtEmissionValue
        [PXDBDecimal(19)]
        [PXUIField(DisplayName = "Ext. Emission Value")]

        [PXFormula(typeof(Mult<qty, usrEmissionValue>))]
        public virtual int? UsrExtEmissionValue { get; set; }
        public abstract class usrExtEmissionValue : PX.Data.BQL.BqlDecimal.Field<usrExtEmissionValue> { }
        #endregion
    }
}