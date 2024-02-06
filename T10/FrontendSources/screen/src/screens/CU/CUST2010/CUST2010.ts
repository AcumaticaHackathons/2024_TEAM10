import {
	PXScreen,
	createSingle,
	createCollection,
	graphInfo,
	localizable,
	PXActionState
} from 'client-controls';

import {
	EmissionType,
	EmissionTran
} from './views';

@localizable
class TabHeaders {
	static GeneralSettings = "General";
	static Transactions = "Transactions"
}

@graphInfo({ graphType: 'Team10.EmissionTypeMaint', primaryView: 'Emission' })
export class CUST2010 extends PXScreen {
	
	TabHeaders = TabHeaders;

	MakeApi: PXActionState;

	Emission = createSingle(EmissionType);
	CurrentEmission = createSingle(EmissionType);
	Transaction = createCollection(EmissionTran);

}

