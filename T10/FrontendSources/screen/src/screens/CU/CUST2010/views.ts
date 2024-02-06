import {
	PXView,
	PXFieldState, 
	PXActionState
} from "client-controls";

export class EmissionType extends PXView {
	MakeApi: PXActionState;

	EmissionID: PXFieldState;
	EmissionCD: PXFieldState;
	ActivityID: PXFieldState;
	Source: PXFieldState;
	RegionName: PXFieldState;
	UnitType: PXFieldState;
	Year: PXFieldState;
	Name: PXFieldState;
	Category: PXFieldState;
	Sector: PXFieldState;
	Description: PXFieldState;
	Unit: PXFieldState;
	Co2e: PXFieldState;
	Co2eUnit: PXFieldState;

}

export class EmissionTran extends PXView {
	EmissionID: PXFieldState;
	RefNbr: PXFieldState;
	LineNbr: PXFieldState;
	InventoryID: PXFieldState;
	Qty: PXFieldState;
	EmissionValue: PXFieldState;
	ExtEmissionValue: PXFieldState;
}
