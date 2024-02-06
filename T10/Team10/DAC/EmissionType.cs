using System;
using PX.Data;

namespace Team10
{
  [Serializable]
  [PXCacheName("Emission Type")]
  public class EmissionType : IBqlTable
  {
    #region EmissionID
    [PXDBIdentity(IsKey = true)]
    public virtual int? EmissionID { get; set; }
    public abstract class emissionID : PX.Data.BQL.BqlInt.Field<emissionID> { }
    #endregion

    #region EmissionCD
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Emission CD")]
    public virtual string EmissionCD { get; set; }
    public abstract class emissionCD : PX.Data.BQL.BqlString.Field<emissionCD> { }
    #endregion

    #region ActivityID
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Activity ID")]
    public virtual string ActivityID { get; set; }
    public abstract class activityID : PX.Data.BQL.BqlString.Field<activityID> { }
    #endregion

    #region Source
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Source")]
    public virtual string Source { get; set; }
    public abstract class source : PX.Data.BQL.BqlString.Field<source> { }
    #endregion

    #region RegionName
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Region Name")]
    public virtual string RegionName { get; set; }
    public abstract class regionName : PX.Data.BQL.BqlString.Field<regionName> { }
    #endregion

    #region UnitType
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Unit Type")]
    public virtual string UnitType { get; set; }
    public abstract class unitType : PX.Data.BQL.BqlString.Field<unitType> { }
    #endregion

    #region Year
    [PXDBInt()]
    [PXUIField(DisplayName = "Year")]
    public virtual int? Year { get; set; }
    public abstract class year : PX.Data.BQL.BqlInt.Field<year> { }
    #endregion

    #region Name
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Name")]
    public virtual string Name { get; set; }
    public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
    #endregion

    #region Category
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Category")]
    public virtual string Category { get; set; }
    public abstract class category : PX.Data.BQL.BqlString.Field<category> { }
    #endregion

    #region Sector
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Sector")]
    public virtual string Sector { get; set; }
    public abstract class sector : PX.Data.BQL.BqlString.Field<sector> { }
    #endregion

    #region Description
    [PXDBString(1024, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Description")]
    public virtual string Description { get; set; }
    public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
    #endregion

    #region Unit
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Unit")]
    public virtual string Unit { get; set; }
    public abstract class unit : PX.Data.BQL.BqlString.Field<unit> { }
    #endregion

    #region Co2e
    [PXDBDecimal()]
    [PXUIField(DisplayName = "Co2e")]
    public virtual Decimal? Co2e { get; set; }
    public abstract class co2e : PX.Data.BQL.BqlDecimal.Field<co2e> { }
    #endregion

    #region Co2eUnit
    [PXDBString(30, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Co2e Unit")]
    public virtual string Co2eUnit { get; set; }
    public abstract class co2eUnit : PX.Data.BQL.BqlString.Field<co2eUnit> { }
    #endregion

    #region Noteid
    [PXNote()]
    public virtual Guid? Noteid { get; set; }
    public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
    #endregion

    #region CreatedByID
    [PXDBCreatedByID()]
    public virtual Guid? CreatedByID { get; set; }
    public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
    #endregion

    #region CreatedByScreenID
    [PXDBCreatedByScreenID()]
    public virtual string CreatedByScreenID { get; set; }
    public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
    #endregion

    #region CreatedDateTime
    [PXDBCreatedDateTime()]
    public virtual DateTime? CreatedDateTime { get; set; }
    public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
    #endregion

    #region LastModifiedByID
    [PXDBLastModifiedByID()]
    public virtual Guid? LastModifiedByID { get; set; }
    public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
    #endregion

    #region LastModifiedByScreenID
    [PXDBLastModifiedByScreenID()]
    public virtual string LastModifiedByScreenID { get; set; }
    public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
    #endregion

    #region LastModifiedDateTime
    [PXDBLastModifiedDateTime()]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion

    #region Tstamp
    [PXDBTimestamp()]
    [PXUIField(DisplayName = "Tstamp")]
    public virtual byte[] Tstamp { get; set; }
    public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
    #endregion
  }
}