import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseService } from '@service';
import IStoreState from '@interfaces/service/IStoreState';
import { Context } from '@nuxt/types';
import IAlert from '@interfaces/IAlert';

export class AlertService extends BaseService {
	public constructor() {
		super({
			stateSliceSelector: (state: IStoreState) => {
				return {
					alerts: state.alerts,
				};
			},
		});
	}

	public setup(nuxtContext: Context): void {
		super.setup(nuxtContext);
	}

	// region Alerts
	public getAlerts(): Observable<IAlert[]> {
		return this.stateChanged.pipe(map((state: IStoreState) => state?.alerts ?? []));
	}

	public showAlert(alert: IAlert): void {
		const alerts = this.getState().alerts;
		// Add unique id
		const id = (alerts.last()?.id ?? 0) + 1;
		this.setState({ alerts: [...alerts, ...[{ ...alert, id }]] });
	}

	public removeAlert(id: number): void {
		this.setState({ alerts: this.getState().alerts.filter((x) => x.id !== id) });
	}
	// endregion
}

const alertService = new AlertService();
export default alertService;
