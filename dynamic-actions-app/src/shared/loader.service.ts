import { EventEmitter, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {

  private loading: boolean = false;
  public loading$: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() { }

  setLoading(loading: boolean) {
    this.loading = loading;
    this.loading$.next(loading);
  }

  getLoading(): boolean {
    return this.loading;
  }
}