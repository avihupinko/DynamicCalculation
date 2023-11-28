import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, Subject, debounceTime, delay, switchMap, tap } from "rxjs";
import { ActionsService } from "src/shared/actions.service";
import { LoaderService } from "src/shared/loader.service";
import { DynamicActionHistory } from "src/shared/models/dynamic-action";

interface State {
    dynamicActionId: number;
}


@Injectable({
    providedIn: 'root',
})
export class TableService {

    private _search$ = new Subject<void>();
    private _data$ = new BehaviorSubject<DynamicActionHistory[]>([]);
    private _dynamicActionId: number = 0;
    constructor(private service: ActionsService,
        private loader: LoaderService) {
        this._search$
            .pipe(
                tap(() => this.loader.setLoading(true)),
                debounceTime(200),
                switchMap(() => this._search()),
                delay(200),
            )
            .subscribe((result) => {
                this._data$.next(result);
                this.loader.setLoading(false)
            });

        this._search$.next();
    }

    get data$() {
        return this._data$.asObservable();
    }

    public set dynamicActionId(dynamicActionId: number){
        this._dynamicActionId = dynamicActionId;
    }

    private _set(patch: Partial<State>) {
        Object.assign(patch);
        this._search$.next();
    }

    public refresh(){
        this._search$.next();
    }

    private _search(): Observable<DynamicActionHistory[]> {
        return this.service.history(this._dynamicActionId);
    }
}