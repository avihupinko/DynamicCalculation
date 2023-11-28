import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { environment } from "src/environment";
import { DynamicAction, DynamicActionCalculate, DynamicActionCalculateResult, DynamicActionHistory } from "./models/dynamic-action";
import { Observable } from "rxjs";



@Injectable({
    providedIn: 'root',
})
export class ActionsService {
    private serverUrl: string;

    constructor(private httpClient: HttpClient) {
        this.serverUrl = environment.serverUrl;
    }

    public get(): Observable<DynamicAction[]> {
        return this.httpClient.get<DynamicAction[]>(`${this.serverUrl}/DynamicActions`);
    }

    public history(dynamicActionId: number): Observable<DynamicActionHistory[]> {
        return this.httpClient.get<DynamicActionHistory[]>(`${this.serverUrl}/DynamicActions/History`, { params: { dynamicActionId } });
    }

    public create(model: DynamicAction) {
        return this.httpClient.post<DynamicAction>(`${this.serverUrl}/DynamicActions`, model);
    }

    public calculate(model: DynamicActionCalculate) {
        return this.httpClient.post<DynamicActionCalculateResult>(`${this.serverUrl}/DynamicActions/Calculate`, model);
    }

}