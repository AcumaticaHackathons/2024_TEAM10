import {
	BaseViewModel,
	PXFieldState, 
} from "client-controls";

export class SSPOSetup extends BaseViewModel {
	ExtConsignPOAccrualAcctID: PXFieldState;
	IntConsignPOAccrualAcctID: PXFieldState;
	InternalCustomerClassID: PXFieldState;
	InternalIMMClassID: PXFieldState;
	BuyerRoleName: PXFieldState;
	ForceUpdateBaseCost: PXFieldState;
}
