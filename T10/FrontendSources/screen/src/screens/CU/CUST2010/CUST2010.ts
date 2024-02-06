import {
	ScreenBaseViewModel,
	createInstance,
	graphInfo,
	localizable
} from 'client-controls';

import {
	SSPOSetup
} from './views';

@localizable
class TabHeaders {
	static GeneralSettings = "General Settings";
}

@graphInfo({ graphType: 'SSCS.PO.SSPOSetupMaint', primaryView: 'Preferences' })
export class SS105000 extends ScreenBaseViewModel {
	TabHeaders = TabHeaders;

	Preferences = createInstance(SSPOSetup);

}

