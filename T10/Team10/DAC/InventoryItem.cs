using PX.Data;

namespace Team10
{
    public sealed class InventoryItemEmissionExt : PXCacheExtension<PX.Objects.IN.InventoryItem>
    {

        #region UsrCustomField
        [PXDBInt]
        [PXUIField(DisplayName = "Emission ID")]
        [PXSelector(
            typeof(EmissionType.emissionID),
            typeof(EmissionType.emissionCD),
            SubstituteKey = typeof(EmissionType.emissionCD)
            )]
        public int? UsrEmissionID { get; set; }
        public abstract class usrEmissionID : PX.Data.BQL.BqlInt.Field<usrEmissionID> { }
        #endregion
    }
}