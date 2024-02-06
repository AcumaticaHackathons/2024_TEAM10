using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.AP;
using PX.Objects.CN.Common.Extensions;
using PX.Objects.Common.GraphExtensions.Abstract.DAC;
using PX.Objects.IN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PX.Objects.AR.ARDocumentEnq;

namespace Team10
{
    public class APInvoiceEntryEmissionExt : PXGraphExtension<APInvoiceEntry>
    {
        public SelectFrom<EmissionTran>.View EmissionTrans;

        protected virtual void _(Events.FieldUpdated<APTran, APTran.inventoryID> e)
        {
            if (e.Row == null) return;

            InventoryItem inItem = InventoryItem.PK.Find(Base, e.Row.InventoryID);

            if (inItem != null && inItem.GetExtension<InventoryItemEmissionExt>().UsrEmissionID != null)
            {
                EmissionType emissionType = EmissionType.PK.Find(Base, inItem.GetExtension<InventoryItemEmissionExt>().UsrEmissionID);

                if (emissionType != null)
                {
                    e.Cache.SetValue<APTranEmissionExt.usrEmissionID>(e.Row, emissionType.EmissionID);
                    e.Cache.SetValue<APTranEmissionExt.usrEmissionUOM>(e.Row, emissionType.Co2eUnit);
                    e.Cache.SetValue<APTranEmissionExt.usrEmissionValue>(e.Row, emissionType.Co2e);
                }
            }
        }

        protected virtual void _(Events.RowPersisting<APTran> e)
        {
            if (Base.Document.Current.Status == APDocStatus.Balanced)
            {
                EmissionTran item = (EmissionTran)EmissionTrans.Cache.CreateInstance();

                item.EmissionID = e.Row.GetExtension<APTranEmissionExt>().UsrEmissionID;
                item.RefNbr = e.Row.RefNbr;
                item.LineNbr = e.Row.LineNbr;
                item.InventoryID = e.Row.InventoryID;
                item.Qty = e.Row.Qty;
                item.EmissionValue = e.Row.GetExtension<APTranEmissionExt>().UsrExtEmissionValue;
                item.ExtEmissionValue = e.Row.GetExtension<APTranEmissionExt>().UsrExtEmissionValue;

                EmissionTrans.Cache.Insert(item);
            }
        }
    }
}
