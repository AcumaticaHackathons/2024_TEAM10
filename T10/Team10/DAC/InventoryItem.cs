using PX.Common;
using PX.Data.BQL.Fluent;
using PX.Data.BQL;
using PX.Data.EP;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.Common.Extensions;
using PX.Objects.Common;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.DR;
using PX.Objects.EP;
using PX.Objects.GL;
using PX.Objects.IN.Matrix.Attributes;
using PX.Objects.IN.Matrix.Graphs;
using PX.Objects.IN;
using PX.Objects.TX;
using PX.Objects;
using PX.TM;
using SelectParentItemClass = PX.Data.BQL.Fluent.SelectFrom<PX.Objects.IN.INItemClass>.Where<PX.Objects.IN.INItemClass.itemClassID.IsEqual<PX.Objects.IN.InventoryItem.itemClassID.FromCurrent>>;
using SelectParentPostClass = PX.Data.BQL.Fluent.SelectFrom<PX.Objects.IN.INPostClass>.Where<PX.Objects.IN.INPostClass.postClassID.IsEqual<PX.Objects.IN.InventoryItem.postClassID.FromCurrent>>;
using System.Collections.Generic;
using System;

namespace Team10
{
  public class InventoryItemEmissionExt : PXCacheExtension<PX.Objects.IN.InventoryItem>
  {
    #region UsrCustomField
    [PXDBString]
    [PXUIField(DisplayName="Emission ID")]
    [PXSelector(typeof(EmissionType.emissionID), DescriptionField = typeof(EmissionType.emissionCD))]
    public virtual string UsrEmissionID { get; set; }
    public abstract class usrEmissionID : PX.Data.BQL.BqlString.Field<usrEmissionID> { }
    #endregion
  }
}