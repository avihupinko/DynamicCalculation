import { Component, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ActionsService } from 'src/shared/actions.service';
import { LoaderService } from 'src/shared/loader.service';
import { DynamicAction, DynamicActionCalculateResult } from 'src/shared/models/dynamic-action';

@Component({
  selector: 'calculate',
  templateUrl: './calculate.component.html',
  styleUrls: ['./calculate.component.css']
})
export class CalculateComponent {
  public form?: FormGroup;
  public actions$?: Observable<DynamicAction[]>;
  public result?: DynamicActionCalculateResult;
  @Input() reload$: EventEmitter<number> = new EventEmitter<number>();
  constructor(
    private service: ActionsService,
    private formBuilder: FormBuilder,
    private loader: LoaderService,
  ) {
    this.actions$ = this.service.get();
    this.form = this.formBuilder.group({
      'dynamicActionId': this.formBuilder.control('', {
        validators: [Validators.required, Validators.maxLength(250), Validators.pattern('[0-9]*')]
      }),
      'x': this.formBuilder.control('', {
        validators: [Validators.required, Validators.maxLength(250)]
      }),
      'y': this.formBuilder.control('', {
        validators: [Validators.required, Validators.maxLength(250)]
      }),
    });
  }



  submit() {
    if (this.form?.valid) {
      this.loader.setLoading(true);
      this.service.calculate(this.form.getRawValue()).subscribe(res => {
        this.loader.setLoading(false);
        this.result = res;
        this.reload$.next(this.form?.controls['dynamicActionId'].value);
      }, err => {
        window.alert(err.error);
        this.result = undefined;
        this.loader.setLoading(false);
      })
    } else {
      window.alert('Please fix form errors');
    }
  }
}
