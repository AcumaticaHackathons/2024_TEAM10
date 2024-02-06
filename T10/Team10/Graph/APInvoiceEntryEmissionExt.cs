using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.AP;
using PX.Objects.CN.Common.Extensions;
using PX.Objects.CN.Compliance.PO.CacheExtensions;
using PX.Objects.Common.GraphExtensions.Abstract.DAC;
using PX.Objects.IN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PX.Data.BQL.BqlPlaceholder;
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

        //protected virtual void _(Events.RowPersisting<APTran> e, PXRowPersisting baseEvent)
        //{
        //    if (baseEvent != null) baseEvent.Invoke(e.Cache, e.Args);

        //    APTran row = e.Row;
        //    APTranEmissionExt rowExt = row.GetExtension<APTranEmissionExt>();

        //    if (rowExt.UsrEmissionID != null && Base.Document.Current.Status == APDocStatus.Balanced)
        //    {
        //        EmissionTran item = (EmissionTran)EmissionTrans.Cache.CreateInstance();

        //        //item.EmissionID = e.Row.GetExtension<APTranEmissionExt>().UsrEmissionID;
        //        item.EmissionID = rowExt.UsrEmissionID;
        //        item.RefNbr = row.RefNbr;
        //        item.LineNbr = row.LineNbr;
        //        item.InventoryID = row.InventoryID;
        //        item.Qty = row.Qty;
        //        item.EmissionValue = rowExt.UsrExtEmissionValue;
        //        item.ExtEmissionValue = rowExt.UsrExtEmissionValue;

        //        EmissionTrans.Cache.Insert(item);
        //    }
        //}

        #region PersistDelegate
        public delegate void PersistDelegate();
        [PXOverride]
        public void Persist(PersistDelegate baseMethod)
        {

            if (baseMethod != null) baseMethod();

            if(Base.Document.Current.Status == APDocStatus.Balanced)
            {
                EmissionTypeMaint graph = PXGraph.CreateInstance<EmissionTypeMaint>();

                foreach (APTran row in Base.Transactions.Select())
                {
                    APTranEmissionExt rowExt = row.GetExtension<APTranEmissionExt>();

                    if (rowExt.UsrEmissionID != null && Base.Document.Current.Status == APDocStatus.Balanced)
                    {
                        graph.Clear();
                        graph.Emission.Current = graph.Emission.Search<EmissionType.emissionID>(rowExt.UsrEmissionID);

                        //EmissionTran item = (EmissionTran)EmissionTrans.Cache.CreateInstance();
                        EmissionTran item = new EmissionTran();

                        //item.EmissionID = e.Row.GetExtension<APTranEmissionExt>().UsrEmissionID;
                        item.EmissionID = rowExt.UsrEmissionID;
                        item.RefNbr = row.RefNbr;
                        item.LineNbr = row.LineNbr;
                        item.InventoryID = row.InventoryID;
                        item.Qty = row.Qty;
                        item.EmissionValue = rowExt.UsrExtEmissionValue;
                        item.ExtEmissionValue = rowExt.UsrExtEmissionValue;

                        graph.Transaction.Insert(item);
                        graph.Save.Press();

                    }
                }
            }
            
        }
        #endregion

    }
}
