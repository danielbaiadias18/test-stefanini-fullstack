import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { iPersonPhone } from 'src/models/PersonPhone';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Test-stefanini';
  readonly apiURL: string;
  personPhones: iPersonPhone[] = [];
  personPhone: iPersonPhone = null;
  form: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder, private toastr: ToastrService) {
    this.apiURL = 'http://localhost:5000';
    this.form = this.fb.group({
      businessEntityID: [{ value: '', disabled: true }],
      name: [{ value: '', disabled: true }],
      phoneNumber: ['', Validators.required],
      phoneNumberTypeID: ['', Validators.compose([Validators.required, Validators.min(1)])],
    });
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.http.get(`${this.apiURL}/api/personphone`)
      .subscribe((response: any) => {
        this.personPhones = response.data.personPhoneObjects;
      });
  }

  getById(phoneNumberTypeID: number, phoneNumber: string) {
    this.http.get(`${this.apiURL}/api/personphone/${phoneNumber}/${phoneNumberTypeID}`)
      .subscribe((response: any) => {
        this.personPhone = response.data.personPhoneObject;
        this.form.controls.businessEntityID.disable();
        this.form.controls['phoneNumber'].setValue(this.personPhone.phoneNumber);
        this.form.controls['businessEntityID'].setValue(this.personPhone.businessEntityID);
        this.form.controls['name'].setValue(this.personPhone.person.name);
        this.form.controls['phoneNumberTypeID'].setValue(this.personPhone.phoneNumberTypeID);
      });
  }

  save() {
    
    this.personPhones.forEach(element => {
      if(element.phoneNumber == this.form.controls.phoneNumber.value && element.businessEntityID == this.form.controls.businessEntityID.value){
        this.form.setErrors({notUnique: true})
      }
    });

    if(this.form.getError('notUnique')){
      this.toastr.error("Este registro já existe!");
    }

    if (this.form.valid) {

      this.form.controls.businessEntityID.enable();
      this.form.controls.businessEntityID.setValue(1);
      this.http.post(`${this.apiURL}/api/personphone`, this.form.value)
        .subscribe((response: any) => {
          if (response.success) {
            this.getAll();
            this.clearForm();
            this.toastr.success("Salvo com sucesso!");
          } else {
            this.toastr.error("Não foi possível salvar esse registro!");
          }
        });

    } else {
      this.markFormGroupTouched(this.form);
    }
  }

  change() {
    if (this.form.valid) {

      this.form.controls.businessEntityID.enable();
      this.http.post(`${this.apiURL}/api/personphone/${this.personPhone.phoneNumber}/${this.personPhone.phoneNumberTypeID}`, this.form.value)
        .subscribe((response: any) => {
          if (response.success) {
            this.getAll();
            this.clearForm();
            this.toastr.success("Alterado com sucesso!");
          } else {
            this.toastr.error("Não foi possível alterar esse registro!");
          }
        });

    } else {
      this.markFormGroupTouched(this.form);
    }
  }

  clearForm() {
    this.form.reset();
    this.personPhone = null;
  }

  delete(phoneNumberTypeID: number, phoneNumber: string) {
    if (confirm("Tem certeza que deseja deletar o telefone " + phoneNumber + "?")) {
      this.http.delete(`${this.apiURL}/api/personphone/${phoneNumber}/${phoneNumberTypeID}`)
        .subscribe(() => {
            this.getAll();
            this.toastr.success("Deletado com sucesso!");
        });
    }

  }

  markFormGroupTouched(formGroup: FormGroup) {
    (<any>Object).values(formGroup.controls).forEach((control: FormGroup) => {
      control.markAsTouched();
      control.markAsDirty();

      if (control.controls) {
        this.markFormGroupTouched(control);
      }
    });
  }
}
